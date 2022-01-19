using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Cinema.Model
{
    [System.Xml.Serialization.XmlInclude(typeof(User))]
    public class User : ModelBaseNotify
    {
        public Guid userId;
        public string userName;
        public string userLastName;
        public string birthDate;
        public int amountOfRatedFilms;
        public List<Rating> Ratings { get; set; }

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

        public string UserLastName
        {
            get { return userLastName; }
            set
            {
                userLastName = value;
                OnPropertyChanged("UserLastName");
            }
        }

        public string BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        public int AmountOfRatedFilms
        {
            get { return amountOfRatedFilms; }
            set
            {
                amountOfRatedFilms = value;
                OnPropertyChanged("AmountOfRatedFilms");
            }
        }
    }
}
