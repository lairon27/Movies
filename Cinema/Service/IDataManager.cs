using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Cinema.Service
{
    internal interface IDataManager
    {
        void Load();
        void Save();
        ObservableCollection<User> GetUsers();
        ObservableCollection<Movie> GetMovies();
        void SetRating(Guid userId, Guid movieId, int amount);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie target, Movie source);
        void AddUser(User user);
        void UpdateUser(User target, User source);
    }
}
