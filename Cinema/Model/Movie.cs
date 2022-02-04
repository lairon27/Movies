using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Cinema
{
    [System.Xml.Serialization.XmlInclude(typeof(Movie))]
    [Serializable]
    public class Movie : ModelBaseNotify
    {
        private Guid movieId;
        private string movieName;
        private int year;
        private float rating;
        private string genre;
        private string describe;
        private string time;
        private string image;

        public List<Rating> Ratings { get; set; }

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

        [XmlAttribute("Genre")]
        public string Genre
        {
            get { return genre; }
            set
            {
                genre = value;
                OnPropertyChanged("Genre");
            }
        }

        [XmlAttribute("Describe")]
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

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}