using Bogus;
using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Generation
{
    internal class Generator
    {
        public Faker<User> Faker { get; set; }
        public Faker<Rating> FakerRating { get; set; }

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

            FakerRating = new Faker<Rating>().RuleFor(x => x.MovieId, f => Guid.NewGuid())
                .RuleFor(x => x.UserRating, f => f.Random.Int(0, 10));
        }

        public Rating GenerateRating()
        {
            return FakerRating.Generate();
        }
    }
}
