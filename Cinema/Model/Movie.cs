using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace Cinema
{
    internal class Movie : INotifyPropertyChanged
    {
        private string movieName;
        private int year;
        private float rating;
        private string genre;
        private string describe;

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}