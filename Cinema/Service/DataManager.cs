using Cinema.Model;
using Cinema.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Cinema.Service
{
    internal class DataManager : IDataManager
    {
        public const string moviesPath = @"C:\Users\anna.moskalenko\source\repos\NewRepo\Cinema\bin\Debug\moviesFileAttribute16f.xml";
        public const string userPath = @"C:\Users\anna.moskalenko\source\repos\NewRepo\Cinema\bin\Debug\usersFileAttribute31.xml";
        public const string ratingPath = @"C:\Users\anna.moskalenko\source\repos\NewRepo\Cinema\bin\Debug\rating5.xml";
        public FileManager MoviesFileManager;
        public FileManager UsersFileManager;
        public FileManager RatingsFileManager;

        public ObservableCollection<Movie> movies;
        public ObservableCollection<User> users;
        public ObservableCollection<Rating> ratings;

        public DataManager()
        {
            MoviesFileManager = new FileManager(moviesPath);
            UsersFileManager = new FileManager(userPath);
            RatingsFileManager = new FileManager(ratingPath);

            movies = new ObservableCollection<Movie>();
            users = new ObservableCollection<User>();
            ratings = new ObservableCollection<Rating>();
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

        public async Task Load()
        {
            Stopwatch stopwatch = new Stopwatch();
            Stream movieStream = new MemoryStream();
            Stream usersStream = new MemoryStream();
            Stream ratingStream = new MemoryStream();

            stopwatch.Start();
            await RatingsFileManager.LoadData(ratingStream);
            await MoviesFileManager.LoadData(movieStream);
            await UsersFileManager.LoadData(usersStream);
            //stopwatch.Stop();
            //MessageBox.Show($"Time loading1111: {stopwatch.Elapsed}");


            //stopwatch.Start();
            ratings = Serialization.Deserialize<ObservableCollection<Rating>>(ratingStream);
            movies = Serialization.Deserialize<ObservableCollection<Movie>>(movieStream);
            users = Serialization.Deserialize<ObservableCollection<User>>(usersStream);


            foreach (var movie in movies)
            {
                foreach (var rating in ratings.Where(rating => movie.MovieId == rating.MovieId))
                {
                    movie.Ratings.Add(rating);
                }
            }

            //stopwatch.Start();
            foreach (var user in users)
            {
                foreach (var rating in ratings.Where(rating => user.UserId == rating.UserId))
                {
                    user.Ratings.Add(rating);
                }
            }

            stopwatch.Stop();
            MessageBox.Show($"Time: {stopwatch.Elapsed}");
        }

        public async void Save()
        {
            var moviesCopy = movies.Select(i => (Movie)i.Clone()).ToList();

            foreach(var movie in moviesCopy)
            {
                movie.Ratings = null;
            }

            var usersCopy = users.Select(i => (User)i.Clone()).ToList();

            foreach (var user in usersCopy)
            {
                user.Ratings = null;
            }


            using (var stream = Serialization.SerializeToXML(moviesCopy))
            {
                await MoviesFileManager.SaveData(stream);
            }

            using (var stream = Serialization.SerializeToXML(usersCopy))
            {
                await UsersFileManager.SaveData(stream);
            }

            using (var stream = Serialization.SerializeToXML(ratings))
            {
                await RatingsFileManager.SaveData(stream);
            }
        }

        public void SetRating(Movie movie, User user, int rate)
        {
            var rating = new Rating(movie.MovieId, user.UserId, rate);
            user.Ratings.Add(rating);
            movie.Ratings.Add(rating);
            ratings.Add(rating);
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
