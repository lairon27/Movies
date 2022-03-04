﻿using Cinema.Model;
using System.Collections.ObjectModel;
using Cinema.VM;
using Cinema.Generation;
using Cinema.Dialog;
using System.Windows.Input;
using System.Windows;
using Cinema.Utils;
using System.Linq;
using Cinema.Service;
using System;

namespace Cinema
{
    public class UserVM : VMBaseNotify
    {
        private User selectedUser;

        public ObservableCollection<User> Users { get; set; }

        private IDataManager dataManager;

        public IDataManager DataManager
        {
            get { return dataManager; }
            set { 
                dataManager = value;
                OnPropertyChanged("DataManager");           
            }
        }

        public static ICommand AddRatingCommand { get; set; }
        public static ICommand DeletePersonCommand { get; set; }

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        public UserVM(IDataManager _dataManager)
        { 
            dataManager = _dataManager;

            Users = new ObservableCollection<User>();

            AddRatingCommand = new RelayCommand(parameter =>
              AddRating_CommandExecute());

            Users = dataManager.GetUsers;
        }

        internal bool UserGenerator_CanExecute()
        {
            return true;
        }

        public void UsersGenerator_CommandExecute()
        {
            InputIntDialog dialog = new InputIntDialog("Amount of users", "Input number of users:");

            if (dialog.ShowDialog() == true)
            {
                var generator = new Generator();

                for (var i = 0; i < dialog.Number; i++)
                {
                    var user = generator.GenerateUser();
                    dataManager.AddUser(user);

                    var amount = user.AmountOfRatedFilms;
                    var selectedId = dataManager.GetMovies.Select(j => j.MovieId).ToList();
                    var listOfRatings = generator.GenerateRating(amount, selectedId);

                    foreach (var element in listOfRatings)
                    {
                        var movieById = dataManager.GetMovieById(element.MovieId);
                        dataManager.SetRating(movieById, user, element.UserRating);
                    }
                }
            }
        }

        public void AddRating_CommandExecute()
        {
            var addRating = new AddRatingDialog();
            if(addRating.ShowDialog() == true)
            {
                var movie = dataManager.GetMovies.Single(i => i.MovieName == addRating.MovieTitle);
                dataManager.SetRating(movie, selectedUser, addRating.Rating);
                selectedUser.AmountOfRatedFilms += 1;
            }
        }

        public void SaveUsers_CommandExecute()
        {
            dataManager.Save();

            MessageBox.Show(ConstClass.changesSaved, ConstClass.saved, MessageBoxButton.OK);
        }
    }
}