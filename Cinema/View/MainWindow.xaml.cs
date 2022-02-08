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
        IDataManager dataManager = new DataManager();

        public MainWindow()
        {
            InitializeComponent();

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

        public void LoadData()
        {
            dataManager.Load();
        }
    }
}
