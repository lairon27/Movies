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

namespace Cinema
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MovieLibrary : UserControl
    {
        MovieContext db;
        public MovieLibrary()
        {
            InitializeComponent();
            DataContext = new MovieLibraryVM();

            //db = new MovieContext();
            //db.Movies.Load();
            //moviesList.ItemsSource = db.Movies.Local.ToBindingList();

        }
    }
}
