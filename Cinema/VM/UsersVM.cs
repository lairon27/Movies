using Cinema.Model;
using System.Collections.ObjectModel;
using Cinema.VM;

namespace Cinema
{
    internal class UsersVM : VMBaseNotify
    {
        private Users selectedUsers;

        public ObservableCollection<Users> user { get; set; }


        public Users SelectedUsers
        {
            get { return selectedUsers; }
            set
            {
                selectedUsers = value;
                OnPropertyChanged("SelectedUsers");
            }
        }

        public UsersVM()
        {
            user = new ObservableCollection<Users>
            {
                new Users {UserNumber = 1, UserName="Tom", LikedMovies="Avengers: Infinity War, Harry Potter and the Deathly Hallows: Part 2, Shang-Chi and the Legend of the Ten Rings"},
                new Users {UserNumber = 2, UserName="Benedict", LikedMovies="Shang-Chi and the Legend of the Ten Rings, Avengers: Infinity War, Ford v Ferrari, Joker"},
                new Users {UserNumber = 3, UserName="Cris", LikedMovies="Dune, The Shawshank Redemption"},
                new Users {UserNumber = 4, UserName="Timotti", LikedMovies="Dune, Spotlight, Harry Potter and the Deathly Hallows: Part 2"},
                new Users {UserNumber = 5, UserName="Tom", LikedMovies="Avengers: Infinity War, Terminator 2: Judgment Day, Ford v Ferrari, Avengers: Infinity War, The Shawshank Redemption"},
                new Users {UserNumber = 6, UserName="Robert", LikedMovies="Joker, Avengers: Infinity War, Shang-Chi and the Legend of the Ten Rings"},
                new Users {UserNumber = 7, UserName="Martin", LikedMovies="Harry Potter and the Deathly Hallows: Part 2, No Time to Die, The Dark Knight , Joker"},
                new Users {UserNumber = 8, UserName="Mark", LikedMovies="The Shawshank Redemption, Spotlight, Terminator 2: Judgment Day"},
                new Users {UserNumber = 9, UserName="Scarlett", LikedMovies="Avengers: Infinity War, Ford v Ferrari, Shang-Chi and the Legend of the Ten Rings, Harry Potter and the Deathly Hallows: Part 2"}

            };
        }
    }
}
