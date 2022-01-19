using Bogus;
using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Generation
{
    internal class Generator
    {
        public static Generator faker;

        private Generator() { }

        public static Generator GetInstance
        {
            get
            {
                if (faker == null)
                    faker = new Generator();
                return faker;
            }
        }

        public User GenerateUser()
        {
            Random random = new();

            var rating = new List<Rating>();

            for(var i=0; i<100; i++)
            {
                rating.Add(GenerateRating());
            }

            return new Faker<User>()
               .RuleFor(x => x.UserId, f => Guid.NewGuid())
               .RuleFor(x => x.UserName, f => f.Name.FirstName())
               .RuleFor(x => x.UserLastName, f => f.Name.LastName())
               .RuleFor(x => x.BirthDate, f => f.Date.Between(new DateTime(1970, 1, 1), new DateTime(2010, 1, 1)).ToString("d"))
               .RuleFor(x => x.AmountOfRatedFilms, f => f.Random.Int(0, 11))
               .RuleFor(x => x.Ratings, (f,o) => Enumerable.Range(1, o.AmountOfRatedFilms).Select(r => f.PickRandom(rating)).ToList())
               .Generate();
        }

        public static Rating GenerateRating()
        {
            Rating rating = new ();
            Random random = new();
            MovieLibraryVM movie = new();

            var moviesId = new List<Guid>();

            foreach (var item in movie.Movies)
            {
                moviesId.Add(item.MovieId);
            }

            int index = random.Next(moviesId.Count);

            rating.MovieId = moviesId[index];
            rating.UserRating = random.Next(0, 10);

            return rating;
        }
    }
}
