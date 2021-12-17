using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cinema.VM
{
    internal class Commands
    {
        static Commands()
        {
            AddMovie = new RoutedUICommand("AddMovie", "AddMovie", typeof(Commands));
        }
        public static RoutedUICommand AddMovie { get; set; }
    }
}
