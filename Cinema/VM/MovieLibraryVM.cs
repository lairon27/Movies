using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Cinema.VM;
using Cinema.View;
using System.Windows;
using Cinema.Utils;
using System.Windows.Input;
using Cinema.Service;
using Cinema.Dialog;

namespace Cinema
{ 
    public class MovieLibraryVM : VMBaseNotify
    {
        private Movie selectedMovie;

        public ObservableCollection<Movie> Movies { get; set; }
     
        public static ICommand EditMovieDialogCmd { get; set; }
        public static ICommand ShowRatingInfoCmd { get; set; }

        private IDataManager dataManager;

        public IDataManager DataManager
        {
            get { return dataManager; }
            set
            {
                dataManager = value;
                OnPropertyChanged("DataManager");
            }
        }

        internal bool AddMovie_CanExecute()
        {
            return true;
        }

        public Movie SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                selectedMovie = value;
                OnPropertyChanged("SelectedMovie");
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;

                view.Filter = (movie) => { return ((Movie)movie).MovieName.ToUpper().Contains(_searchText.ToUpper()); };

                OnPropertyChanged("SearchText");
            }
        }

        private ICollectionView view;
        public ICollectionView View
        {
            get { return view; }
            set
            {
                view = value;

                OnPropertyChanged("View");
            }
        }

        public MovieLibraryVM(IDataManager _dataManager)
        {
            dataManager = _dataManager;

            EditMovieDialogCmd = new RelayCommand(parameter =>
             EditMovieDialog_Command());

            ShowRatingInfoCmd = new RelayCommand(parameter =>
             ShowRatingInfo_Command());

            Movies = dataManager.GetMovies;
            view = CollectionViewSource.GetDefaultView(Movies);
        }

        private void ShowRatingInfo_Command()
        {
            var usersRatingDialog = new RatingsByUsers(SelectedMovie);
            usersRatingDialog.DataManager = dataManager;
            usersRatingDialog.ShowDialog();
        }

        public void SortBy_CommandExecute(string parameter)
        {
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(parameter, ListSortDirection.Descending));
        }

        public void SortByAsc_CommandExecute(string parameter)
        {
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(parameter, ListSortDirection.Ascending));
        }

        public void AddMovieDialog_Command()
        {
            var movie = new Movie();

            var movieDialog = new AddMovieDialog(movie);

            if (movieDialog.ShowDialog() == true)
            {
                dataManager.AddMovie(movie);
            }
        }

        private void EditMovieDialog_Command()
        {
            var copy = (Movie)SelectedMovie.Clone();
            var movieDialog = new AddMovieDialog(copy, true);

            if (movieDialog.ShowDialog() == true)
            {
                dataManager.UpdateMovie(copy, SelectedMovie);
            }
        }

        public void SaveAllChanges_Command()
        {
            dataManager.Save();

            MessageBox.Show(ConstClass.changesSaved, ConstClass.saved, MessageBoxButton.OK);
        }
    }
}