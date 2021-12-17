using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using Cinema.Model;
using Cinema.VM;
using Cinema.View;

namespace Cinema.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MovieLibrary : BaseView
    {
        //MovieContext db;
        public MovieLibrary()
        {
            InitializeComponent();
            DataContext = new MovieLibraryVM();

            //CommandBindings.Add(new CommandBinding(BaseVM.Open,   // this is the command object
            //                  XCutFooCommand,      // execute
            //                  CanXCuteFooCommand));

            //var exitBinding = new CommandBinding(MainVm.Exit, ExitExecuted, ExitCanExecute);
            //CommandBindings.Add(exitBinding);

            //var addBinding = new CommandBinding(BaseView.AddMovie, XCutFooCommand, CanXCuteFooCommand);
            //CommandBindings.Add(addBinding);

            CommandManager.InvalidateRequerySuggested();

            //searchTextBox.Focus();

            this.Loaded += MovieLibrary_Loaded;

            //db = new MovieContext();
            //db.Movies.Load();
            //moviesList.ItemsSource = db.Movies.Local.ToBindingList();

        }

        private void MovieLibrary_Loaded(object sender, RoutedEventArgs e)
        {
            searchTextBox.Focus();
        }

        //private void CanXCuteFooCommand(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;  // can this command be executed?
        //    e.Handled = true;
        //}

        //private void XCutFooCommand(object sender, ExecutedRoutedEventArgs e)
        //{
        //    AddMovie add = new AddMovie();
        //    add.Show();
        //}

        //public void CanExecuteRerollCommand(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;  // can this command be executed?
        //    e.Handled = true;     // has this event been handled?
        //}
        //public void ExecuteRerollCommand(object sender, ExecutedRoutedEventArgs e)
        //{
        //    // do stuff
        //}

        //private void ExitCanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //    e.Handled = true;
        //}

        //private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        //{
        //    AddMovie add = new AddMovie();
        //    add.Show();
        //}
    }
}
