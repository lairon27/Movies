using Cinema.Model;
using Cinema.Service;
using Cinema.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Cinema.Tests
{
    [TestClass]
    public class DataManagerTests
    {
        [TestMethod]
        public void AddMovie_NewMovie_AddedMovie()
        {
            //Arange
            var dataManager = new DataManager();
            var movie = new Movie();
            movie.MovieName = "TestMovieName";

            //Act
            dataManager.AddMovie(movie);

            //Assert
            Assert.IsTrue(dataManager.GetMovies.Any());
        }

        [TestMethod]
        public void AddUser_NewUser_AddedUser()
        {
            //Arange
            var dataManager = new DataManager();
            var user = new User();
            user.UserName = "TestUserName";

            //Act
            dataManager.AddUser(user);

            //Assert
            Assert.IsTrue(dataManager.GetUsers.Any());
        }

        [TestMethod]
        public void Save_SaveData_CallMethodSaveData()
        {
            //Arange
            var dataManager = new DataManager();
            var fileManagerMock = new Mock<IFileManager>();
            dataManager.MoviesFileManager = fileManagerMock.Object;
            dataManager.UsersFileManager = fileManagerMock.Object;
            dataManager.RatingsFileManager = fileManagerMock.Object;

            //Act
            dataManager.Save();

            //Assert
            fileManagerMock.Verify(x => x.SaveData(It.IsAny<Stream>()), Times.Exactly(3));
        }

        [TestMethod]
        public async Task Load_LoadData_CallMethodLoadData() //to finish
        {
            //Arange
            var dataManager = new DataManager();
            var fileManagerMock = new Mock<IFileManager>();
            var serealizationMock = new Mock<IXMLSerializator>();

            var users = new ObservableCollection<User>()
            {
                new User()
                {
                    UserId = new Guid("5b89e195-0905-4b23-99cc-2ccc660b8454"),
                    UserName="Mable",
                }
            };

            var movies = new ObservableCollection<Movie>()
            {
                new Movie()
                {
                    MovieId = new Guid(),
                    MovieName="No Time to Die",
                }
            };

            var ratings = new ObservableCollection<Rating>()
            {
                new Rating()
                {
                    UserId = new Guid("5b89e195-0905-4b23-99cc-2ccc660b8454"),
                    MovieId = new Guid("81915939-af6b-4514-a247-f0bb109aeb05")
                }
            };

            fileManagerMock.Setup(x => x.LoadData(It.IsAny<Stream>())).Callback<Stream>((st) =>
            {
                var writer = new StreamWriter(st);
                writer.Write(users);
                writer.Flush();
                st.Position = 0;
            });

            fileManagerMock.Setup(x => x.LoadData(It.IsAny<Stream>())).Callback<Stream>((st) =>
            {
                var writer = new StreamWriter(st);
                writer.Write(movies);
                writer.Flush();
                st.Position = 0;
            });

            fileManagerMock.Setup(x => x.LoadData(It.IsAny<Stream>())).Callback<Stream>((st) =>
            {
                var writer = new StreamWriter(st);
                writer.Write(ratings);
                writer.Flush();
                st.Position = 0;
            });

            serealizationMock.Setup(x => x.Deserialize<ObservableCollection<User>>(It.IsAny<Stream>())).Returns(users);
            serealizationMock.Setup(x => x.Deserialize<ObservableCollection<Movie>>(It.IsAny<Stream>())).Returns(movies);
            serealizationMock.Setup(x => x.Deserialize<ObservableCollection<Rating>>(It.IsAny<Stream>())).Returns(ratings);

            dataManager.UsersFileManager = fileManagerMock.Object;
            dataManager.MoviesFileManager = fileManagerMock.Object;
            dataManager.RatingsFileManager = fileManagerMock.Object;

            dataManager.xMLSerializator = serealizationMock.Object;

            //Act
            await dataManager.Load();

            //Assert
            fileManagerMock.Verify(x => x.LoadData(It.IsAny<Stream>()), Times.Exactly(3));
            serealizationMock.Verify();
        }

        [TestMethod]
        public void SetRating_NewRating_AddedReting()
        {
            //Arange
            var dataManager = new DataManager();
            int rate = 9;
            var movie = new Movie();
            movie.MovieId = Guid.NewGuid();
            var user = new User();
            user.UserId = Guid.NewGuid();

            //Act
            dataManager.SetRating(movie, user, rate);

            //Assert
            Assert.AreEqual(movie.Ratings.Count(), user.Ratings.Count());
        }

        [TestMethod]
        public void UpdateMovie_NewValues_UpdatedMovie()
        {
            //Arange
            var dataManager = new DataManager();
            var movie = new Movie();
            movie.Year = 2019;
            var updatedMovie = movie.Clone();
            
            ((Movie)updatedMovie).Year = 2022;
            
            //Act
            dataManager.UpdateMovie((Movie)updatedMovie, movie);

            //Assert
            Assert.AreNotEqual(updatedMovie, movie);
        }
    }
}
