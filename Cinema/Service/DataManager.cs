using Cinema.Model;
using Cinema.Utils;
using Cinema.View;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Cinema.Service
{
    internal class DataManager : IDataManager
    {
        public const string moviesPath = @"C:\Users\anna.moskalenko\source\repos\NewRepo\Cinema\bin\Debug\moviesFileAttribute3.xml";
        public const string userPath = @"C:\Users\anna.moskalenko\source\repos\NewRepo\Cinema\bin\Debug\usersFileAttribute4.xml";
        public FileManager MoviesFileManager;
        public FileManager UsersFileManager;

        public ObservableCollection<Movie> movies;
        public ObservableCollection<User> users;

        public DataManager()
        {
            MoviesFileManager = new FileManager(moviesPath);
            UsersFileManager = new FileManager(userPath);

            movies = new ObservableCollection<Movie>();
            users = new ObservableCollection<User>();
        }

        public void AddMovie(Movie movie)
        {
           movies.Add(movie);
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public ObservableCollection<Movie> GetMovies
        {
            get{ return movies; }
            set{ movies = value; }
        }

        public ObservableCollection<User> GetUsers
        {
            get { return users; }
            set { users = value; }
        }

        public void Load()
        {
            Stream movieStream = new MemoryStream();
            Stream usersStream = new MemoryStream();
            MoviesFileManager.LoadData(movieStream);
            UsersFileManager.LoadData(usersStream);

            movies = Serialization.Deserialize<ObservableCollection<Movie>>(movieStream);
            users = Serialization.Deserialize<ObservableCollection<User>>(usersStream);
        }

        public void Save()
        {
            using (var stream = Serialization.SerializeToXML(movies))
            {
                MoviesFileManager.SaveData(stream);
            }

            using (var stream = Serialization.SerializeToXML(users))
            {
                UsersFileManager.SaveData(stream);
            }
        }

        public void SetRating(Movie movie, User user, int rate)
        {
            var rating = new Rating(movie.MovieId, user.UserId, rate);
            user.Ratings.Add(rating);
            movie.Ratings.Add(rating);
        }


        public void UpdateMovie(Movie target, Movie source)
        {
            source.MovieName = target.MovieName;
            source.Year = target.Year;
            source.Genre = target.Genre;
            source.Rating = target.Rating;
            source.Describe = target.Describe;
            source.Time = target.Time;
            source.Image = target.Image;
        }

        public void UpdateUser(User target, User source)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(Guid userId)
        {
            return users.Single(i => i.UserId == userId);
        }

        public Movie GetMovieById(Guid movieId)
        {
            return movies.Single(i => i.MovieId == movieId); 
        }
    }
}
