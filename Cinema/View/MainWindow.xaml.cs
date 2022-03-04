using Cinema.Converters;
using Cinema.Service;
using Cinema.VM;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;

namespace Cinema.View
{
    /// <summary>
    /// Interaction logic for MovieLibrary.xaml
    /// </summary>
    /// 
    public partial class MainWindow : RibbonWindow
    {
        IDataManager dataManager = new DataManager();

        public async Task LoadData()
        {
              await dataManager.Load();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
           
            tabController.Items.Add(new TabItem
            {
                Header = "Users",
                Content = new UsersView()
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
                },
            });
        }
    }
}
