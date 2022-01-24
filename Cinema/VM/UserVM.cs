using Cinema.Model;
using System.Collections.ObjectModel;
using Cinema.VM;
using Cinema.Generation;
using Cinema.Dialog;
using System.Windows.Input;
using System.Windows;
using Cinema.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Cinema
{
    internal class UserVM : VMBaseNotify
    {
        private User selectedUser;

        public ObservableCollection<User> Users { get; set; }

        public static ICommand UsersGeneratorCommand { get; set; }
        public static ICommand SaveUsersCommand { get; set; }

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        public UserVM()
        { 
            Users = new ObservableCollection<User>();

            UsersGeneratorCommand = new RelayCommand(parameter =>
             UsersGenerator_CommandExecute());

            SaveUsersCommand = new RelayCommand(parameter =>
              SaveUsers_CommandExecute());

        }

        private void UsersGenerator_CommandExecute()
        {
            InputIntDialog dialog = new("Amount of users", "Input number of users:");

            if (dialog.ShowDialog() == true)
            {
                var generator = new Generator();

                for (var i = 0; i < dialog.Number; i++)
                {
                    Users.Add(generator.GenerateUser());

                    for(var j = 0; j < Users[i].AmountOfRatedFilms; j++)
                    {
                        Users[i].Ratings.Add(generator.GenerateRating());
                    }
                }
            }
        }

        private void SaveUsers_CommandExecute()
        {

            FileManager.SaveData(Serialization.SerializeToXML(Users), "users.xml");

            MessageBox.Show("Changes saved successfully", "Saved", MessageBoxButton.OK);
        }

    }
}