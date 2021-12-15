namespace Cinema.Model
{
    internal class Users : ModelBaseNotify
    {
        private int userNumber;
        private string userName;
        private string likedMovies;
        //private float userRating;

        public int UserNumber
        {
            get { return userNumber; }
            set
            {
                userNumber = value;
                OnPropertyChanged("UserNumber");
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

        public string LikedMovies
        {
            get { return likedMovies; }
            set
            {
                likedMovies = value;
                OnPropertyChanged("LikedMovies");
            }
        }

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
