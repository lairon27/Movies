using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Cinema.VM;
using Cinema.View;
using System.Windows;
using Cinema.Utils;
using System.Windows.Input;
using System.Windows.Controls;

namespace Cinema
{
    internal class MovieLibraryVM : VMBaseNotify
    {
        private Movie selectedMovie;

        public ObservableCollection<Movie> Movies { get; set; }
        
        public static ICommand SortByCommand { get; set; }
        public static ICommand AddMovieDialogCmd { get; set; }
        public static ICommand EditMovieDialogCmd { get; set; }
        public static ICommand SaveAllChanges { get; set; }

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


        //public RoutedCommand addNewWindow = new RoutedCommand("Open", typeof(MovieLibraryVM));
        public MovieLibraryVM()
        {
            SortByCommand = new RelayCommand(parameter =>
              SortBy_CommandExecute(parameter.ToString()));

            AddMovieDialogCmd = new RelayCommand(parameter =>
             AddMovieDialog_Command());

            EditMovieDialogCmd = new RelayCommand(parameter =>
             EditMovieDialog_Command());

            SaveAllChanges = new RelayCommand(parameter =>
             SaveAllChanges_Command());

            FileManager fileManager = new();

            Movies = Serialization.Deserialize<ObservableCollection<Movie>>(FileManager.LoadData("myTextFile.xml"));

            view = CollectionViewSource.GetDefaultView(Movies);

           
        }

        private void SortBy_CommandExecute(string parameter)
        {
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(parameter, ListSortDirection.Descending));
        }

        private void AddMovieDialog_Command()
        {
            AddMovieDialog movieDialog = new();

            if (movieDialog.ShowDialog() == true)
            {
                Movies.Add((Movie)movieDialog.DataContext);

                foreach (var movie in Movies)
                {
                    if (movie.MovieId == Guid.Empty)
                    {
                        movie.MovieId = Guid.NewGuid();
                    }
                }
            }
        }

        private void EditMovieDialog_Command()
        {
            AddMovieDialog movieDialog = new();

            movieDialog.Editor();
            movieDialog.DataContext = SelectedMovie;
            movieDialog.ShowDialog();

            //if(movieDialog.ShowDialog() == true)
            //{
            //    movieDialog.DataContext = SelectedMovie;
            //    //SelectedMovie = (Movie)movieDialog.DataContext;
            //}


            //movieDialog.Show();
            //movieDialog.Editor();
            //movieDialog.DataContext = SelectedMovie;
        }

        private void SaveAllChanges_Command()
        {
            using (var stream = Serialization.SerializeToXML(Movies))
            {
                FileManager.SaveData(stream, "myTextFile.xml");
            }

            MessageBox.Show("Changes saved successfully", "Saved", MessageBoxButton.OK);
        }
    }
}