using Cinema.Model;
using System.Collections.ObjectModel;
using Cinema.VM;
using Bogus;
using System.Collections.Generic;
using System.Linq;
using System;
using Cinema.Generation;
using System.ComponentModel;
using System.Windows.Data;
using Cinema.View;
using Cinema.Dialog;

namespace Cinema
{
    internal class UserVM : VMBaseNotify
    {
        private User selectedUser;

        public ObservableCollection<User> users { get; set; }
          
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        private RelayCommand usersGenerator;
        public RelayCommand UsersGenerator
        {
            get
            {
                return usersGenerator ??
                  (usersGenerator = new RelayCommand(obj =>
                  {
                      AmountOfUsers amountOfUsers = new();
                      amountOfUsers.ShowDialog();

                      var amount = int.Parse(amountOfUsers.count.Text);

                      var people = Generator.UsersGenerator().Generate(amount);

                      foreach (var user in people)
                      {
                          users.Add(user);
                      }

                  }));
            }
        }

        public UserVM()
        { 
            users = new ObservableCollection<User>();
        }
    } 
}