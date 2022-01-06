using Bogus;
using Cinema.Dialog;
using Cinema.Model;
using System;
using System.Windows;

namespace Cinema.Generation
{
    internal class Generator
    {
        public static Faker<User> UsersGenerator()
        {
            return new Faker<User>()
                .RuleFor(x => x.UserId, f => Guid.NewGuid())
                .RuleFor(x => x.UserName, f => f.Name.FirstName())
                .RuleFor(x => x.UserLastName, f => f.Name.LastName());
        }
    }
}
