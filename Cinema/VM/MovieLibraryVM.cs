using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Cinema.VM;
using Cinema.View;
using System.Windows;
using Cinema.Utils;
using System.Windows.Input;
using Bogus;
using System.Linq;
using System.IO;

namespace Cinema
{
    internal class MovieLibraryVM : VMBaseNotify
    {
        private Movie selectedMovie;

        public ObservableCollection<Movie> Movies { get; set; }
        public static ICommand SortByYear { get; set; }
        public static ICommand SortByRating { get; set; }
        public static ICommand SortByName { get; set; }
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

                view.Filter = (movie) => { return ((Movie)movie).MovieName.Contains(_searchText, StringComparison.InvariantCultureIgnoreCase); };

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
            //const string FileName = @"C:\Users\anna.moskalenko\Desktop\ko.txt";
            //Movies = Serialization.Deserialize<ObservableCollection<Movie>>(@"C:\Users\anna.moskalenko\Desktop\movies3.txt");

            SortByYear = new RelayCommand(parameter =>
             SortByYear_Command());

            SortByRating = new RelayCommand(parameter =>
             SortByRating_Command());

            SortByName = new RelayCommand(parameter =>
             SortByName_Command());

            AddMovieDialogCmd = new RelayCommand(parameter =>
             AddMovieDialog_Command());

            EditMovieDialogCmd = new RelayCommand(parameter =>
             EditMovieDialog_Command());

            SaveAllChanges = new RelayCommand(parameter =>
             SaveAllChanges_Command());

            //Movies = FileManager.LoadData<ObservableCollection<Movie>>(@"C:\Users\anna.moskalenko\Desktop\movie55.txt");
            FileManager fileManager = new();

            Movies = Serialization.Deserialize<ObservableCollection<Movie>>(FileManager.LoadData("moviesFile.xml"));

            //var stream = new FileStream(@"C:\Users\anna.moskalenko\Desktop\movie8.txt", FileMode.Open, FileAccess.Read);
            //Movies = Serialization.Deserialize<ObservableCollection<Movie>>(stream);

            view = CollectionViewSource.GetDefaultView(Movies);
        }

        private void SortByYear_Command()
        {
            view.SortDescriptions.Add(new SortDescription("Year", ListSortDirection.Descending));
        }

        private void SortByRating_Command()
        {
            view.SortDescriptions.Add(new SortDescription("Rating", ListSortDirection.Descending));
        }

        private void SortByName_Command()
        {
            view.SortDescriptions.Add(new SortDescription("MovieName", ListSortDirection.Descending));
        }

        private void AddMovieDialog_Command()
        {
            AddMovieDialog movieDialog = new();

            if (movieDialog.ShowDialog() == true)
            {
                Movies.Insert(Movies.Count, (Movie)movieDialog.DataContext);

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
            movieDialog.Show();
            movieDialog.Editor();
            movieDialog.DataContext = SelectedMovie;
        }

        private void SaveAllChanges_Command()
        {
            var stream = Serialization.SerializeToXML(Movies);

            FileManager.SaveData(stream, "moviesFile.xml");
            stream.Close();
            MessageBox.Show("Changes saved successfully", "Saved", MessageBoxButton.OK);
        }
    }
}