using Bogus;
using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Cinema.Generation
{
    internal class Generator
    {
        public static User GenerateUser()
        {
            User user = new();
            Movie movie = new();

            var generatedUserFaker = new Faker<User>()
               .RuleFor(x => x.UserId, f => Guid.NewGuid())
               .RuleFor(x => x.UserName, f => f.Name.FirstName())
               .RuleFor(x => x.UserLastName, f => f.Name.LastName())
               .RuleFor(x => x.BirthDate, f => f.Date.Between(new DateTime(1970, 1, 1), new DateTime(2010, 1, 1)).ToString("d"))
               .RuleFor(x => x.AmountOfRatedFilms, f => f.Random.Int(0, 11));

            user = generatedUserFaker.Generate();

            return user;
        }
    }
}
