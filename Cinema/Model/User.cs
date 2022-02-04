using System;
using System.Collections.Generic;
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
        public List<Rating> Ratings { get; set; }

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
            Ratings = new List<Rating>();
        }
    }
}
