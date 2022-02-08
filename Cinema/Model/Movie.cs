using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace Cinema
{
    [Flags]
    public enum Genres
    {
        None = 0,
        Action = 1,
        Comedy = 2,
        Drama = 4,
        Fantasy = 8,
        Horror = 16,
        Mystery = 32,
        Romance = 64,
        Thriller = 128,
        Western = 256,
        Fiction = 512,
        Adventure = 1024,
        Crime = 2048,
        Detective = 4096,
        Biographical = 8192,
        Historical = 16384,
        Sports = 32768,
        Science = 65536
    }


    //[System.Xml.Serialization.XmlInclude(typeof(Movie))]
    [Serializable]
    public class Movie : ModelBaseNotify
    {
        private Guid movieId;
        private string movieName;
        private int year;
        private float rating;
        private Genres genre;
        private string describe;
        private string time;
        private string image;
        private float avgRatingByUsers;

        public ObservableCollection<Rating> Ratings { get; set; }

        [XmlAttribute("MovieId")]
        public Guid MovieId
        {
            get { return movieId; }
            set
            {
                movieId = value;
                OnPropertyChanged("MovieId");
            }
        }

        [XmlAttribute("MovieName")]
        public string MovieName
        {
            get { return movieName; }
            set
            {
                movieName = value;
                OnPropertyChanged("MovieName");
            }
        }

        [XmlAttribute("Year")]
        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

        [XmlAttribute("Rating")]
        public float Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                OnPropertyChanged("Rating");
            }
        }

        [XmlElement("Genre")]
        public Genres Genre
        {
            get { return genre; }
            set
            {
                genre = value;
                OnPropertyChanged("Genre");
            }
        }

        [XmlElement("Describe")]
        public string Describe
        {
            get { return describe; }
            set
            {
                describe = value;
                OnPropertyChanged("Describe");
            }
        }

        [XmlAttribute("Time")]
        public string Time
        {
            get { return time; }
            set
            {
                time = value; ;
                OnPropertyChanged("Time");
            }
        }

        [XmlAttribute("Image")]
        public string Image
        {
            get { return image; }
            set
            {
                image = value; ;
                OnPropertyChanged("Image");
            }
        }

        [XmlAttribute("Avarage Rating")]
        public float AvgRatingByUsers
        {
            get { return CalcRatingByUsers(); }
        }

        private float CalcRatingByUsers()
        {
            return 0;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public Movie()
        {
           MovieId=Guid.NewGuid();
           Ratings = new ObservableCollection<Rating>();
           Ratings.CollectionChanged += Ratings_CollectionChanged;
        }

        private void Ratings_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("AvgRatingByUsers");
        }
    }
}