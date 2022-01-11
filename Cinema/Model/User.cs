using System;

namespace Cinema.Model
{
    internal class User : ModelBaseNotify
    {
        private Guid userId;
        private string userName;
        private string userLastName;
        private string birthDate;
        private int amountOfRatedFilms;

        public Guid UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged("UserId");
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                userName= value;
                OnPropertyChanged("UserName");
            }
        }

        public string UserLastName
        {
            get { return userLastName; }
            set
            {
                userLastName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                OnPropertyChanged("UserName");
            }
        }

        public int AmountOfRatedFilms
        {
            get { return amountOfRatedFilms; }
            set
            {
                amountOfRatedFilms = value;
                OnPropertyChanged("LikedMovies");
            }
        }

    }
}
