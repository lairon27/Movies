using Cinema.Model;
using System.Collections.ObjectModel;
using Cinema.VM;
using Bogus;
using System.Collections.Generic;
using System.Linq;

namespace Cinema
{
    internal class UsersVM : VMBaseNotify
    {
        private Users selectedUsers;
        private static int userNumber = 1;

        public ObservableCollection<Users> user { get; set; }

          
        public Users SelectedUsers
        {
            get { return selectedUsers; }
            set
            {
                selectedUsers = value;
                OnPropertyChanged("SelectedUsers");
            }
        }

        public UsersVM()
        {
            var generatorPerson = new Faker<Users>()
                .RuleFor(x => x.UserNumber, f => userNumber++)
                .RuleFor(x => x.UserName, f => f.Name.FullName());

            user = new ObservableCollection<Users>(generatorPerson.Generate(10000));
        }
    }
    
}

    
