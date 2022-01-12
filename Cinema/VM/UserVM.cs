using Cinema.Model;
using System.Collections.ObjectModel;
using Cinema.VM;
using Cinema.Generation;
using Cinema.Dialog;
using System.Windows.Input;
using System.Windows;
using Cinema.Utils;

namespace Cinema
{
    internal class UserVM : VMBaseNotify
    {
        private User selectedUser;

        public ObservableCollection<User> Users { get; set; }

        public static ICommand UsersGenerator { get; set; }
        public static ICommand SaveUsers { get; set; }

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

            UsersGenerator = new RelayCommand(parameter =>
             UsersGenerator_Command());

            SaveUsers = new RelayCommand(parameter =>
              SaveUsers_Command());
        }

        private void UsersGenerator_Command()
        {
            AmountOfUsers amountOfUsers = new();
            amountOfUsers.ShowDialog();

            int amount;
            if (int.TryParse(amountOfUsers.count.Text, out int count))
            {
                amount = count;
            }
            else
            {
                MessageBox.Show("The input data must be a number!", "Incorrect value", MessageBoxButton.OK, MessageBoxImage.Warning);
                amount = 0;
            }

            for (var i=0; i<amount; i++)
            {
                Users.Add(Generator.GenerateUser());
            }
        }

        private void SaveUsers_Command()
        {
            //FileManager.SaveData(Movies, @"C:\Users\anna.moskalenko\Desktop\rrrre.txt");

            //var stream = Serialization.SerializeToXML(Movies);

            FileManager.SaveData(Serialization.SerializeToXML(Users), @"C:\Users\anna.moskalenko\Desktop\users.txt");

            MessageBox.Show("Changes saved successfully", "Saved", MessageBoxButton.OK);
        }

    }
}