using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace Cinema
{
    internal class MovieLibraryViewModel : INotifyPropertyChanged
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

        public MovieLibraryViewModel()
        {
            Movies = new ObservableCollection<Movie>
            {
                new Movie {MovieName="Avangers: Infinity War", Year=2018, Rating=8.4f },
                new Movie {MovieName="Shang-Chi and the Legend of the Ten Rings", Year=2021, Rating=7.6f },
                new Movie {MovieName="No Time to Die", Year=2021, Rating=7.4f },
                new Movie {MovieName=" The Shawshank Redemption ", Year=1994, Rating=9.2f },
                new Movie {MovieName="The Dark Knight ", Year=2008, Rating=9.0f },
                new Movie {MovieName="Spotlight", Year=2015, Rating=8.0f },
                new Movie {MovieName=" Harry Potter and the Deathly Hallows: Part 2", Year=2011, Rating=8.1f },
                new Movie {MovieName="Ford v Ferrari", Year=2019, Rating=8.1f },
                new Movie {MovieName="Joker", Year=2019, Rating=8.3f },
                new Movie {MovieName="Terminator 2: Judgment Day", Year=1991, Rating=8.5f },
                new Movie {MovieName="Dune", Year=2021, Rating=8.2f }
            };


            view = CollectionViewSource.GetDefaultView(Movies);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
