using Bogus;
using Cinema.Model;
using System;
using System.Collections.Generic;

namespace Cinema.Generation
{
    public class Generator
    {
        public Faker<User> Faker { get; set; }

        private Random random = new Random();

        public User GenerateUser()
        {
            return Faker.Generate();
        }

        public Generator()
        {
            Faker = new Faker<User>().RuleFor(x => x.UserId, f => Guid.NewGuid())
               .RuleFor(x => x.UserName, f => f.Name.FirstName())
               .RuleFor(x => x.UserLastName, f => f.Name.LastName())
               .RuleFor(x => x.BirthDate, f => f.Date.Between(new DateTime(1970, 1, 1), new DateTime(2010, 1, 1)).ToString("d"));
        }

        public List<Rating> GenerateRating(List<Guid> movieIdCollection)
        {
            var rating = new List<Rating>();
            var elements = GetRangomItems(movieIdCollection);
            foreach (var item in elements)
            {
                rating.Add(new Rating
                {
                    MovieId = item,
                    UserRating = random.Next(0, 10)
                });
            }

            return rating;
        }

        public List<Guid> GetRangomItems(List<Guid> moviesGuids)
        {
            var amountOfRatedFilms = random.Next(0, moviesGuids.Count);

            var movieIdCollection = new List<Guid>(amountOfRatedFilms);
            var guidsCopy = new List<Guid>(moviesGuids);

            if(guidsCopy.Count != 0)
            {
                for (var i = 0; i < amountOfRatedFilms; i++)
                {
                    int index = random.Next(guidsCopy.Count);
                    movieIdCollection.Add(guidsCopy[index]);
                    guidsCopy.RemoveAt(index);
                }
            }
            return movieIdCollection;
        }
    }
}
