using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Cinema.Model
{
    [Serializable]
    public class User : ModelBaseNotify
    {
        private Guid userId;
        private string userName;
        private string userLastName;
        private string birthDate;
        private Rating selectedRating;

        [XmlIgnore]
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

        public User()
        {
            Ratings = new ObservableCollection<Rating>();
        }
    }
}
