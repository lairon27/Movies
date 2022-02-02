using Cinema.Model;
using System;
using System.Collections.Generic;

namespace Cinema
{
    [System.Xml.Serialization.XmlInclude(typeof(Movie))]
    public class Movie : ModelBaseNotify, ICloneable
    {
        public Guid movieId;
        public string movieName;
        public int year;
        public float rating;
        public string genre;
        public string describe;
        public string time;
        public string image;

        public List<Rating> Ratings { get; set; }

        public Guid MovieId
        {
            get { return movieId; }
            set
            {
                movieId = value;
                OnPropertyChanged("MovieId");
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


        //public Movie(Guid id, string title, int _year, float _rating, string _genre, string _describe, string _time, string _image)
        //{
        //    movieId = id;
        //    movieName = title;
        //    year = _year;
        //    rating = _rating;
        //    genre = _genre;
        //    describe = _describe;
        //    time = _time;
        //    image = _image;
        //}

        public object Clone()
        {
            //return this.MemberwiseClone();
            return new Movie
            {
                movieId = movieId,
                movieName = movieName,
                year = year,
                rating = rating,
                genre = genre,
                describe = describe,
                time = time,
                image = image
            };
        }
    }
}