using Cinema.Model;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Cinema.Service
{
    public interface IDataManager
    {
         Task Load();
         Task Save();
         ObservableCollection<User> GetUsers { get; }
         ObservableCollection<Movie> GetMovies { get; }
         void SetRating(Movie movie, User user, int rate);
         void DeleteRating(User user, Rating rating);
         void AddMovie(Movie movie);
         void UpdateMovie(Movie target, Movie source);
         void AddUser(User user);
         User GetUserById(Guid userId);
         Movie GetMovieById(Guid movieId);
    }
}
