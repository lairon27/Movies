using Cinema.Model;
using System;

namespace Cinema
{
    [System.Xml.Serialization.XmlInclude(typeof(Movie))]
    public class Movie : ModelBaseNotify
    {
        private Guid movieId;
        public string movieName;
        public int year;
        public float rating;
        public string genre;
        public string describe;
        public string time;
        public string image;

        public Guid MovieId
        {
            get { return movieId; }
            set
            {
                movieId = value;
                OnPropertyChanged("UserId");
            }
        }

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

        public string Image
        {
            get { return image; }
            set
            {
                image = value; ;
                OnPropertyChanged("Image");
            }
        }
    }
}