using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Cinema.Service
{
    internal interface IDataManager
    {
        public void Load();
        public void Save();
        public ObservableCollection<User> GetUsers();
        public ObservableCollection<Movie> GetMovies();
        public void SetRating(Guid userId, Guid movieId, int amount);
        public void AddMovie(Movie movie);
        public void UpdateMovie(Movie target, Movie source);
        public void AddUser(User user);
        public void UpdateUser(User target, User source);
    }
}
