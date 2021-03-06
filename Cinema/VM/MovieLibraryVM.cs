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
using Cinema.Service;

namespace Cinema
{
    internal class MovieLibraryVM : VMBaseNotify
    {
        private Movie selectedMovie;

        public static ObservableCollection<Movie> Movies { get; set; }
        
        public static ICommand SortByCommand { get; set; }
        public static ICommand AddMovieDialogCmd { get; set; }
        public static ICommand EditMovieDialogCmd { get; set; }
        public static ICommand SaveAllChanges { get; set; }

        //private DataManager dataManager;

        private IDataManager dataManager;

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

        public FileManager fileManager = new FileManager(@"C:\Users\anna.moskalenko\source\repos\NewRepo\Cinema\bin\Debug\moviesFile.xml");

        //public RoutedCommand addNewWindow = new RoutedCommand("Open", typeof(MovieLibraryVM));
        public MovieLibraryVM(IDataManager _dataManager)
        {

            dataManager = _dataManager;

            SortByCommand = new RelayCommand(parameter =>
              SortBy_CommandExecute(parameter.ToString()));

            AddMovieDialogCmd = new RelayCommand(parameter =>
             AddMovieDialog_Command());

            EditMovieDialogCmd = new RelayCommand(parameter =>
             EditMovieDialog_Command());

            SaveAllChanges = new RelayCommand(parameter =>
             SaveAllChanges_Command());


            dataManager.Load();
            //var data = fileManager.LoadData();

            //if (data != null)
            //{
            //    Movies = Serialization.Deserialize<ObservableCollection<Movie>>(data);
            //}

            Movies = dataManager.GetMovies();
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
                // Movies.Add((Movie)movieDialog.DataContext);

                dataManager.AddMovie((Movie)movieDialog.DataContext);

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
            //AddMovieDialog movieDialog = new();

            //movieDialog.Editor();

            //var movie = SelectedMovie;

            //var copy = (Movie)movie.Clone();

            //movieDialog.DataContext = copy;

            //if (movieDialog.ShowDialog() == true)
            //{
            //    movie.MovieId = copy.MovieId;
            //    movie.MovieName = copy.MovieName;
            //    movie.Year = copy.Year;
            //    movie.Genre = copy.Genre;
            //    movie.Rating = copy.Rating;
            //    movie.Describe = copy.Describe;
            //    movie.Time = copy.Time;
            //    movie.Image = copy.Image;
            //}

            //movieDialog.DataContext = SelectedMovie;
            dataManager.UpdateMovie((Movie)SelectedMovie.Clone(), SelectedMovie);
        }

        private void SaveAllChanges_Command()
        {
            using (var stream = Serialization.SerializeToXML(Movies))
            {
                fileManager.SaveData(stream);
            }

            //dataManager.Save();

            MessageBox.Show("Changes saved successfully", "Saved", MessageBoxButton.OK);
        }
    }
}