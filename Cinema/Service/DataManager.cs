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
            await MoviesFileManager.LoadData(movieStream);
            await UsersFileManager.LoadData(usersStream);

            movies = xMLSerializator.Deserialize<ObservableCollection<Movie>>(movieStream);
            users = xMLSerializator.Deserialize<ObservableCollection<User>>(usersStream);
            ratings = xMLSerializator.Deserialize<ObservableCollection<Rating>>(ratingStream);


            if(users != null && movies != null && ratings != null)
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
            var moviesCopy = movies.Select(i => (Movie)i.Clone()).ToList();
            var usersCopy = users.Select(i => (User)i.Clone()).ToList();

            using (var stream = xMLSerializator.SerializeToXML(moviesCopy))
            {
                await MoviesFileManager.SaveData(stream);
            }

            using (var stream = xMLSerializator.SerializeToXML(usersCopy))
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
            try
            {
                return users.Single(i => i.UserId == userId);
            }
            catch
            {
                return null;
            }
        }

        public Movie GetMovieById(Guid movieId)
        {
            try
            {
                return movies.Single(i => i.MovieId == movieId);
            }
            catch
            {
                return null;
            }
        }
    }
}
