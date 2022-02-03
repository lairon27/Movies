using Cinema.Model;
using Cinema.Utils;
using Cinema.View;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Cinema.Service
{
    internal class DataManager : IDataManager
    {
        public Stream loadedMovies;

        public Stream loadedUsers;

        public FileManager UsersFilePath = new FileManager(@"C:\Users\anna.moskalenko\source\repos\NewRepo\Cinema\bin\Debug\users.xml");
        public FileManager MoviesFilePath = new FileManager(@"C:\Users\anna.moskalenko\source\repos\NewRepo\Cinema\bin\Debug\moviesFile.xml"); 

        public ObservableCollection<Movie> movies;
        public ObservableCollection<User> users;

        public DataManager()
        {
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

        public ObservableCollection<Movie> GetMovies()
        {
            if (loadedMovies != null)
            {
                movies = Serialization.Deserialize<ObservableCollection<Movie>>(loadedMovies);
            }

            return movies;
        }

        public ObservableCollection<User> GetUsers()
        {
            if (loadedUsers != null)
            {
                users = Serialization.Deserialize<ObservableCollection<User>>(loadedUsers);
            }

            return users;
        }

        public void Load()
        {
            loadedMovies = MoviesFilePath.LoadData();
            loadedUsers = UsersFilePath.LoadData();
        }

        public void Save()
        {
            
        }

        public void SetRating(Guid userId, Guid movieId, int amount)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(Movie target, Movie source)
        {
            AddMovieDialog movieDialog = new AddMovieDialog();

            movieDialog.Editor();

            movieDialog.DataContext = target;

            if (movieDialog.ShowDialog() == true)
            {
                source.MovieId = target.MovieId;
                source.MovieName = target.MovieName;
                source.Year = target.Year;
                source.Genre = target.Genre;
                source.Rating = target.Rating;
                source.Describe = target.Describe;
                source.Time = target.Time;
                source.Image = target.Image;
            }
        }

        public void UpdateUser(User target, User source)
        {
            throw new NotImplementedException();
        }
    }
}
