using Bogus;
using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Generation
{
    internal class Generator
    {
        public static Faker<User> UsersGenerator()
        {
            var generatorPerson = new Faker<User>()
                .RuleFor(x => x.UserId, f => Guid.NewGuid())
                .RuleFor(x => x.UserName, f => f.Name.FullName());

            return generatorPerson;
        }
    }
}
