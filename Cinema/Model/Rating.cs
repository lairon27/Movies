using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Rating : ModelBaseNotify
    {
        public Guid movieId;
        public Guid userId;
        public int userRating;

        public Guid MovieId
        {
            get { return movieId; }
            set
            {
                movieId = value;
                OnPropertyChanged("Rating");
            }
        }

        public Guid UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged("Rating");
            }
        }

        public int UserRating
        {
            get { return userRating; }
            set
            {
                userRating = value;
                OnPropertyChanged("Rating");
            }
        }
    }
}
