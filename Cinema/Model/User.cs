using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Cinema.Model
{
    //[System.Xml.Serialization.XmlInclude(typeof(User))]
    [Serializable]
    public class User : ModelBaseNotify
    {
        private Guid userId;
        private string userName;
        private string userLastName;
        private string birthDate;
        private int amountOfRatedFilms;
        private Rating selectedRating;
        public ObservableCollection<Rating> Ratings { get; set; }

        public Rating SelectedRating
        {
            get { return selectedRating; }
            set
            {
                selectedRating = value;
                OnPropertyChanged("SelectedRating");
            }
        }

        [XmlAttribute("UserId")]
        public Guid UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged("UserId");
            }
        }

        [XmlAttribute("UserName")]
        public string UserName
        {
            get { return userName; }
            set
            {
                userName= value;
                OnPropertyChanged("UserName");
            }
        }

        [XmlAttribute("UserLastName")]
        public string UserLastName
        {
            get { return userLastName; }
            set
            {
                userLastName = value;
                OnPropertyChanged("UserLastName");
            }
        }

        [XmlAttribute("BirthDate")]
        public string BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        [XmlAttribute("AmountOfRatedFilms")]
        public int AmountOfRatedFilms
        {
            get { return amountOfRatedFilms; }
            set
            {
                amountOfRatedFilms = value;
                OnPropertyChanged("AmountOfRatedFilms");
            }
        }

        public User()
        {
            Ratings = new ObservableCollection<Rating>();
        }

        public object Clone()
        {
            Ratings = null;
            return MemberwiseClone();
        }
    }
}
