﻿using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Cinema.VM;
using Cinema.View;
using Cinema.Commands;
using System.Windows;
using Cinema.Dialog;

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

        private RelayCommand addMovieDialog;

        public RelayCommand AddMovieDialogCmd
        {
            get
            {
                return addMovieDialog ??
                  (addMovieDialog = new RelayCommand(obj =>
                  {
                      AddMovieDialog movieDialog = new();

                      if (movieDialog.ShowDialog() == true)
                      {
                          Movies.Insert(Movies.Count, (Movie)movieDialog.DataContext);
                      }
                      else
                      {
                          movieDialog.Close();
                      }
                  }));
            }
        }

        private RelayCommand editMovieDialog;
        public RelayCommand EditMovieDialogCmd
        {
            get
            {
                return editMovieDialog ??
                  (editMovieDialog = new RelayCommand(obj =>
                  {
                      EditMovieDialog editDialog = new();
                      editDialog.Show();
                      editDialog.DataContext = SelectedMovie;
                  }));
            }
        }

        private RelayCommand saveAllChanges;

        public RelayCommand SaveAllChanges
        {
            get
            {
                return saveAllChanges ??
                  (saveAllChanges = new RelayCommand(obj =>
                  {
                      Serialization.SerializeToXML(Movies, @"C:\Users\anna.moskalenko\Desktop\movies1.txt");
                      MessageBox.Show("Changes saved successfully", "Saved" , MessageBoxButton.OK);
                  }));
            }
        }

        //public RoutedCommand addNewWindow = new RoutedCommand("Open", typeof(MovieLibraryVM));
        public MovieLibraryVM()
        {
            Movies = Serialization.Deserialize<ObservableCollection<Movie>>(@"C:\Users\anna.moskalenko\Desktop\movies1.txt");
            view = CollectionViewSource.GetDefaultView(Movies);
        }
    }
}