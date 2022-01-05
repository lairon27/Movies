using System;

namespace Cinema.Model
{
    internal class User : ModelBaseNotify
    {
        private Guid userId;
        private string userName;
        //private string likedMovies;
        //private float userRating;

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

        //public string LikedMovies
        //{
        //    get { return likedMovies; }
        //    set
        //    {
        //        likedMovies = value;
        //        OnPropertyChanged("LikedMovies");
        //    }
        //}

        //public float UserRating
        //{
        //    get { return userRating; }
        //    set
        //    {
        //        userRating = value;
        //        OnPropertyChanged("UserRating");
        //    }
        //}
    }
}
