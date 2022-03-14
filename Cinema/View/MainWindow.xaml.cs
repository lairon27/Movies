using Cinema.Service;
using System.Threading.Tasks;
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
        ScreenFactory screenFactory;

        public async Task LoadData()
        {
              await dataManager.Load();
        }

        public MainWindow()
        {
            screenFactory = new ScreenFactory(dataManager);
            InitializeComponent();
            
        }

        public void Initialize()
        {
            tabController.Items.Add(new TabItem
            {
                Header = "Movie Library",
                Content = screenFactory.CreateScreen(ViewID.Movie),
            });

            tabController.Items.Add(new TabItem
            {
                Header = "Users",
                Content = screenFactory.CreateScreen(ViewID.User),
            });
        }
    }
}
