using Cinema.Model;
using Cinema.Utils;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Service
{
    public class DataManager : IDataManager
    {
        public IFileManager MoviesFileManager;
        public IFileManager UsersFileManager;
        public IFileManager RatingsFileManager;
        public IXMLSerializator xMLSerializator;

        public ObservableCollection<Movie> movies;
        public ObservableCollection<User> users;
        public ObservableCollection<Rating> ratings;

        public DataManager()
        {
            MoviesFileManager = new FileManager(ConstClass.moviesPath);
            UsersFileManager = new FileManager(ConstClass.userPath);
            RatingsFileManager = new FileManager(ConstClass.ratingPath);

            xMLSerializator = new Serialization();

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
        }

        public ObservableCollection<User> GetUsers
        {
            get { return users; }
        }

        public async Task Load()
        {
            Stream movieStream = new MemoryStream();
            Stream usersStream = new MemoryStream();
            Stream ratingStream = new MemoryStream();

            await RatingsFileManager.LoadData(ratingStream);

            var ratingTask = Task.Run(() =>
            {
                ratings = xMLSerializator.Deserialize<ObservableCollection<Rating>>(ratingStream);
            });

            await MoviesFileManager.LoadData(movieStream);

            var movieTask = Task.Run(() =>
            {
                movies = xMLSerializator.Deserialize<ObservableCollection<Movie>>(movieStream);
            });

            await UsersFileManager.LoadData(usersStream);

            var userTask = Task.Run(() =>
            {
                users = xMLSerializator.Deserialize<ObservableCollection<User>>(usersStream);
            });

            await Task.WhenAll(ratingTask, movieTask, userTask);
            
            if (users != null && movies != null && ratings != null)
            {
                var usersDictionary = users.GroupBy(i => i.UserId).ToDictionary(g => g.Key, g => g.First());
                var moviesDictionary = movies.GroupBy(i => i.MovieId).ToDictionary(g => g.Key, g => g.First());

                foreach (var rating in ratings)
                {
                    if (usersDictionary.ContainsKey(rating.UserId))
                    {
                        usersDictionary[rating.UserId].Ratings.Add(rating);
                    }

                    if (moviesDictionary.ContainsKey(rating.MovieId))
                    {
                        moviesDictionary[rating.MovieId].Ratings.Add(rating);
                    }
                }
            }
        }

        public async Task Save()
        {
            using (var stream = xMLSerializator.SerializeToXML(movies))
            {
                await MoviesFileManager.SaveData(stream);
            }

            using (var stream = xMLSerializator.SerializeToXML(users))
            {
                await UsersFileManager.SaveData(stream);
            }

            using (var stream = xMLSerializator.SerializeToXML(ratings))
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

        public void DeleteRating(User user, Rating rating)
        {
            var movie = GetMovieById(rating.MovieId);

            user.Ratings.Remove(rating);
            movie.Ratings.Remove(rating);
            ratings.Remove(rating);
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

        public User GetUserById(Guid userId)
        {
            return users.SingleOrDefault(i => i.UserId == userId);
        }

        public Movie GetMovieById(Guid movieId)
        {
            return movies.SingleOrDefault(i => i.MovieId == movieId);
        }
    }
}
