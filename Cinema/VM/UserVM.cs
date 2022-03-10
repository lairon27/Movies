using Cinema.Model;
using System.Collections.ObjectModel;
using Cinema.VM;
using Cinema.Generation;
using Cinema.Dialog;
using System.Linq;
using Cinema.Service;

namespace Cinema
{
    public class UserVM : VMBaseNotify
    {
        private User selectedUser;
        
        public ObservableCollection<User> Users { get; set; }

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
            DataManager = _dataManager;

            Users = new ObservableCollection<User>();

            Users = DataManager.GetUsers;
        }

        public void DeleteRating_CommandExecute()
        {
            DataManager.DeleteRating(selectedUser, selectedUser.SelectedRating);
            //selectedUser.AmountOfRatedFilms -= 1;
        }

        internal bool UserGenerator_CanExecute()
        {
            return true;
        }

        public void UsersGenerator_CommandExecute(int number)
        {
            var generator = new Generator();

            for (var i = 0; i < number; i++)
            {
                var user = generator.GenerateUser();
                DataManager.AddUser(user);

                //var amount = user.AmountOfRatedFilms;
                var selectedId = DataManager.GetMovies.Select(j => j.MovieId).ToList();
                var listOfRatings = generator.GenerateRating(selectedId);

                foreach (var element in listOfRatings)
                {
                    var movieById = DataManager.GetMovieById(element.MovieId);
                    DataManager.SetRating(movieById, user, element.UserRating);
                }
            }
        }

        public void AddRating_CommandExecute()
        {
            var addRating = new AddRatingDialog(DataManager);
            if(addRating.ShowDialog() == true)
            {
                var movie = DataManager.GetMovies.Single(i => i.MovieName == addRating.MovieTitle);
                DataManager.SetRating(movie, selectedUser, addRating.Rating);
                //selectedUser.AmountOfRatedFilms += 1;
            }
        }

        public void SaveUsers_CommandExecute()
        {
            DataManager.Save();
        }
    }
}