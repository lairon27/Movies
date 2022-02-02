using Cinema.Service;
using System.Windows;
using System.Windows.Controls;


namespace Cinema.View
{
    /// <summary>
    /// Interaction logic for MovieLibrary.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IDataManager dataManager = new DataManager();

            tabController.Items.Add(new TabItem
            {
                Header = "Users",
                Content = new Users()
                {
                    DataContext = new UserVM(dataManager)
                }
            });

            tabController.Items.Add(new TabItem
            {
                Header = "Movie Library",
                Content = new MovieLibrary()
                {
                    DataContext = new MovieLibraryVM(dataManager)
                }
            });
        }
    }
}
