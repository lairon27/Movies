using Cinema.Service;
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
using System.Windows.Shapes;

namespace Cinema.Dialog
{
    /// <summary>
    /// Interaction logic for RatingsByUsers.xaml
    /// </summary>
    public partial class RatingsByUsers : Window
    {
        public static readonly DependencyProperty DataManagerProperty =
         DependencyProperty.Register("DataManager", typeof(IDataManager), typeof(RatingsByUsers), new
            PropertyMetadata(default(IDataManager)));

        public IDataManager DataManager
        {
            get { return (IDataManager)GetValue(DataManagerProperty); }
            set { SetValue(DataManagerProperty, value); }
        }

        public RatingsByUsers(Movie movie)
        {
            InitializeComponent();
            DataContext = movie;
        }
    }
}
