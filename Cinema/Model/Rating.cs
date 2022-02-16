using System;
using System.Xml.Serialization;

namespace Cinema.Model
{
    public class Rating : ModelBaseNotify
    {
        private Guid movieId;
        private Guid userId;
        private int userRating;

        [XmlAttribute("MovieId")]
        public Guid MovieId
        {
            get { return movieId; }
            set
            {
                movieId = value;
                OnPropertyChanged("Rating");
            }
        }

        [XmlAttribute("UserId")]
        public Guid UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged("Rating");
            }
        }

        [XmlAttribute("UserRating")]
        public int UserRating
        {
            get { return userRating; }
            set
            {
                userRating = value;
                OnPropertyChanged("Rating");
            }
        }

        public Rating()
        {
            
        }

        public Rating(Guid movieId, Guid userId, int rating)
        {
            MovieId = movieId;
            UserId = userId;
            UserRating = rating;
        }
    }
}
