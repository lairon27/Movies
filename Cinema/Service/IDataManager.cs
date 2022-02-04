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
         ObservableCollection<User> GetUsers { get; set; }
         ObservableCollection<Movie> GetMovies { get; set; }
         void SetRating(User user, Movie movie, int rate);
         void AddMovie(Movie movie);
         void UpdateMovie(Movie target, Movie source);
         void AddUser(User user);
         void UpdateUser(User target, User source);
         User GetUserById(Guid userId);
         Movie GetMovieById(Guid movieId);
    }
}
