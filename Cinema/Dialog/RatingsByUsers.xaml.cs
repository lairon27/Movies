using Cinema.Service;
using System.Windows;

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
