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

        public FileManager fileManager = new FileManager(@"C:\Users\anna.moskalenko\source\repos\NewRepo\Cinema\bin\Debug\users.xml");

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
                int k;

                if (Users.Count == 0)
                {
                    k = 0;
                }
                else
                {
                    k = Users.Count;
                    dialog.Number += Users.Count;
                }

                var generator = new Generator();

                for (var i = k; i < dialog.Number; i++)
                {
                    Users.Add(generator.GenerateUser());

                    var amount = Users[i].AmountOfRatedFilms;
                    var selectedId = MovieLibraryVM.Movies.Select(i => i.MovieId).ToList();
                    var listOfRatings = generator.GenerateRating(amount, selectedId);

                    foreach (var element in listOfRatings)
                    {
                        Users[i].Ratings.Add(element);
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