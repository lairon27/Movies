using Cinema.Model;
using System.Collections.ObjectModel;
using Cinema.VM;
using Cinema.Generation;
using Cinema.Dialog;
using System.Windows.Input;
using System.Windows;
using Cinema.Utils;
using System.Linq;
using Cinema.Service;

namespace Cinema
{
    internal class UserVM : VMBaseNotify
    {
        private User selectedUser;

        public static ObservableCollection<User> Users { get; set; }

        public FileManager fileManager = new FileManager(@"C:\Users\anna.moskalenko\source\repos\NewRepo\Cinema\bin\Debug\users.xml");

        private IDataManager dataManager;

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

        public UserVM(IDataManager _dataManager)
        { 
            dataManager = _dataManager;

            Users = new ObservableCollection<User>();

            UsersGeneratorCommand = new RelayCommand(parameter =>
             UsersGenerator_CommandExecute());

            SaveUsersCommand = new RelayCommand(parameter =>
              SaveUsers_CommandExecute());

            dataManager = new DataManager();

            //dataManager.Load();

            //if (dataManager.loadedUsers != null)
            //{
            //    Users = Serialization.Deserialize<ObservableCollection<User>>(dataManager.loadedUsers);
            //}

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
                    var user = generator.GenerateUser();
                    Users.Add(user);

                    var amount = user.AmountOfRatedFilms;
                    var selectedId = MovieLibraryVM.Movies.Select(i => i.MovieId).ToList();
                    var listOfRatings = generator.GenerateRating(amount, selectedId);

                    foreach (var element in listOfRatings)
                    {
                        user.Ratings.Add(element);
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