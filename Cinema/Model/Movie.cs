using Cinema.Model;

namespace Cinema
{
    internal class Movie : ModelBaseNotify
    {
        private string movieName;
        private int year;
        private float rating;
        private string genre;
        private string describe;
        private string time;

        public string MovieName
        {
            get { return movieName; }
            set
            {
                movieName = value;
                OnPropertyChanged("MovieName");
            }
        }
        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }
        public float Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                OnPropertyChanged("Rating");
            }
        }

        public string Genre
        {
            get { return genre; }
            set
            {
                genre = value;
                OnPropertyChanged("Genre");
            }
        }

        public string Describe
        {
            get { return describe; }
            set
            {
                describe = value;
                OnPropertyChanged("Describe");
            }
        }

        public string Time
        {
            get { return time; }
            set
            {
                time = value; ;
                OnPropertyChanged("Time");
            }
        }
    }
}