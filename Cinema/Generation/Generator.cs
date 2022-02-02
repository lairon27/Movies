using Bogus;
using Cinema.Model;
using System;
using System.Collections.Generic;

namespace Cinema.Generation
{
    internal class Generator
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
               .RuleFor(x => x.BirthDate, f => f.Date.Between(new DateTime(1970, 1, 1), new DateTime(2010, 1, 1)).ToString("d"))
               .RuleFor(x => x.AmountOfRatedFilms, f => f.Random.Int(0, 11));
        }

        public List<Rating> GenerateRating(int amount, List<Guid> guids)
        {
            var rating = new List<Rating>();
            var elements = GetRangomItems(amount, guids);
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

        public List<Guid> GetRangomItems(int amount, List<Guid> guids)
        {
            var idCollection = new List<Guid>(amount);
            var guidsCopy = new List<Guid>(guids);

            for (var i = 0; i < amount; i++)
            {
                int index = random.Next(guidsCopy.Count);
                idCollection.Add(guidsCopy[index]);
                guidsCopy.RemoveAt(index);
            }

            return idCollection;
        }
    }
}
