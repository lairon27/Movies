using Cinema.Model;
using System.Collections.ObjectModel;
using Cinema.VM;
using Cinema.Generation;
using Cinema.Dialog;
using System.Windows.Input;
using System.Windows;
using Cinema.Utils;
using System.Linq;

namespace Cinema
{
    internal class UserVM : VMBaseNotify
    {
        private User selectedUser;

        public static ObservableCollection<User> Users { get; set; }

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

        public FileManager fileManager = new FileManager(@"C:\Users\anna.moskalenko\source\repos\NewRepo\Cinema\bin\Debug\users.xml");

        public UserVM()
        { 
            Users = new ObservableCollection<User>();

            UsersGeneratorCommand = new RelayCommand(parameter =>
             UsersGenerator_CommandExecute());

            SaveUsersCommand = new RelayCommand(parameter =>
              SaveUsers_CommandExecute());

            //var data = fileManager.LoadData();

            //if (data != null)
            //{
            //    Users = Serialization.Deserialize<ObservableCollection<User>>(data);
            //}
            //Users = Serialization.Deserialize<ObservableCollection<User>>(fileManager.LoadData());
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

                    //for(var j = 0; j < Users[i].AmountOfRatedFilms; j++)
                    //{
                    //    Users[i].Ratings.Add(generator.GenerateRating());                         
                    //}

                    foreach(var item in generator.GenerateRating())
                    {
                        Users[i].Ratings.Add(item);
                    }

                }
            }
        }

        private void SaveUsers_CommandExecute()
        {
           

            using (var stream = Serialization.SerializeToXML(Users))
            {
                fileManager.SaveData(stream);
            }

            MessageBox.Show("Changes saved successfully", "Saved", MessageBoxButton.OK);
        }
    }
}