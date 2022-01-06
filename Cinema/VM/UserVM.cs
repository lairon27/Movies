using Cinema.Model;
using System.Collections.ObjectModel;
using Cinema.VM;
using Cinema.Generation;
using Cinema.Dialog;
using System.Windows.Input;
using System.Windows;

namespace Cinema
{
    internal class UserVM : VMBaseNotify
    {
        private User selectedUser;

        public ObservableCollection<User> users { get; set; }

        public static ICommand UsersGenerator { get; set; }

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
            users = new ObservableCollection<User>();

            UsersGenerator = new RelayCommand(parameter =>
             UsersGenerator_Command());
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
                MessageBox.Show("The input data must be a number!", "Incorect value", MessageBoxButton.OK);
                amount = 0;
            }

            var people = Generator.UsersGenerator().Generate(amount);

            foreach (var user in people)
            {
                users.Add(user);
            }
        } 
    } 
}