using Cinema.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cinema.View
{
    public  class BaseView : UserControl
    {

        public BaseView()
        {
            var addBinding = new CommandBinding(Commands.AddMovie,  AddMovie_Executed, AddMovie_CanExecute);
            CommandBindings.Add(addBinding);

            CommandManager.InvalidateRequerySuggested();
        }

        private void AddMovie_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((MovieLibraryVM)DataContext).AddMovie_CanExecute();
        }

        private void AddMovie_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        //private static RoutedUICommand _AddCommand = new("Add Movie", "AddMovie", typeof(MainWindow));
        //public static RoutedUICommand AddCommand
        //{
        //    get { return _AddCommand; }
        //}

        //public RoutedUICommand AddMovie = new("AddMovie", "AddMovie", typeof(BaseView));
    }
}
