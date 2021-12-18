using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Cinema.VM;
using Cinema.View;
using System.Windows.Input;

namespace Cinema
{
    internal class MovieLibraryVM : VMBaseNotify
    {
        private Movie selectedMovie;

        public ObservableCollection<Movie> Movies { get; set; }

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

        private RelayCommand sortByName;
        public RelayCommand SortByName
        {
            get
            {
                return sortByName ??
                  (sortByName = new RelayCommand(obj =>
                  {
                   
                  }));
            }
        }

        private RelayCommand sortByYear;
        public RelayCommand SortByYear
        {
            get
            {
                return sortByYear ??= new RelayCommand(obj =>
                  {
                      view.SortDescriptions.Add(new SortDescription("Year", ListSortDirection.Descending));
                  });
            }
        }

        private RelayCommand sortByRating;
        public RelayCommand SortByRating
        {
            get
            {
                return sortByRating ??
                  (sortByRating = new RelayCommand(obj =>
                  {
                      view.SortDescriptions.Add(new SortDescription("Rating", ListSortDirection.Descending));
                  }));
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

        public bool AddMovie_CanExecute()
        {
            return true;
        }


        private RelayCommand addNew;
        public RelayCommand AddWindow
        {
            get
            {
                return addNew ??
                  (addNew = new RelayCommand(obj =>
                  {
                      AddMovie movie = new();
                      movie.Show();

                  }));
            }
        }


        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Movie movie = new();
                      Movies.Insert(0, movie);
                      SelectedMovie = movie;

                  }));
            }
        }
        public RoutedCommand addNewWindow = new RoutedCommand("Open", typeof(MovieLibraryVM));

        public MovieLibraryVM()
        {
            Movies = new ObservableCollection<Movie>
            {
                new Movie {MovieName="Avengers: Infinity War", Year=2018, Rating=8.4f, Genre="Fiction, Action, Adventure, Fantasy", Describe="The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe." , Time="2h 29m", Image="pack://application:,,,/Resources/avengers1.png"},
                new Movie {MovieName="Harry Potter and the Deathly Hallows: Part 2", Year=2011, Rating=8.1f, Genre="Adventure, Detective, Fantasy", Describe="Harry, Ron, and Hermione search for Voldemort's remaining Horcruxes in their effort to destroy the Dark Lord as the final battle rages on at Hogwarts.", Time="2h 10m", Image="pack://application:,,,/Resources/harry_potter.jpg" },
                new Movie {MovieName="No Time to Die", Year=2021, Rating=7.4f, Genre="Action, Adventure, Thriller", Describe="James Bond has left active service. His peace is short-lived when Felix Leiter, an old friend from the CIA, turns up asking for help, leading Bond onto the trail of a mysterious villain armed with dangerous new technology.", Time="2h 43m", Image="pack://application:,,,/Resources/no_time.png" },
                new Movie {MovieName="The Shawshank Redemption", Year=1994, Rating=6.2f, Genre="Drama, Crime", Describe="Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", Time="2h 22m", Image="pack://application:,,,/Resources/shawshank.jpeg" },
                new Movie {MovieName="The Dark Knight ", Year=2008, Rating=9.0f, Genre="Action, Crime, Fiction, Thriller", Describe="When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", Time="2h 32m", Image="pack://application:,,,/Resources/dark_knight.jpg" },
                new Movie {MovieName="Spotlight", Year=2015, Rating=4.0f, Genre="Thriller, Drama, Historical, Biographical", Describe="The true story of how the Boston Globe uncovered the massive scandal of child molestation and cover-up within the local Catholic Archdiocese, shaking the entire Catholic Church to its core.", Time="2h 9m", Image="pack://application:,,,/Resources/spotlight.jpg"},
                new Movie {MovieName="Joker", Year=2019, Rating=8.3f, Genre="Thriller, Drama, Crime", Describe="In Gotham City, mentally troubled comedian Arthur Fleck is disregarded and mistreated by society. He then embarks on a downward spiral of revolution and bloody crime. This path brings him face-to-face with his alter-ego: the Joker.", Time="2h 2m", Image="pack://application:,,,/Resources/joker.jpg" },
                new Movie {MovieName="Ford v Ferrari", Year=2019, Rating=8.1f, Genre="Drama, Biographical, Sports", Describe="American car designer Carroll Shelby and driver Ken Miles battle corporate interference and the laws of physics to build a revolutionary race car for Ford in order to defeat Ferrari at the 24 Hours of Le Mans in 1966.", Time="2h 32m", Image="pack://application:,,,/Resources/ford_v_ferrari.jpg" },
                new Movie {MovieName="Shang-Chi and the Legend of the Ten Rings", Year=2021, Rating=7.6f, Genre="Action, Adventure, Fantasy, Fantasy, Comedy", Describe="Shang-Chi, the master of weaponry-based Kung Fu, is forced to confront his past after being drawn into the Ten Rings organization.", Time="2h 12m", Image="pack://application:,,,/Resources/shang-chi.png" },
                new Movie {MovieName="Terminator 2: Judgment Day", Year=1991, Rating=8.5f, Genre="Fiction, Action, Thriller", Describe="A cyborg, identical to the one who failed to kill Sarah Connor, must now protect her ten-year-old son John from a more advanced and powerful cyborg.", Time="2h 17m", Image="pack://application:,,,/Resources/terminator2.jpg" },
                new Movie {MovieName="Dune", Year=2021, Rating=7.2f, Genre="Fiction, Adventure, Drama", Describe="Feature adaptation of Frank Herbert's science fiction novel about the son of a noble family entrusted with the protection of the most valuable asset and most vital element in the galaxy.", Time="2h 35m", Image="pack://application:,,,/Resources/dune.jpg" }
            };

            view = CollectionViewSource.GetDefaultView(Movies);
        }

       
    }
}
