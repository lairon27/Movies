using Cinema.Service;
using System.Windows.Controls;
using WpfApp1;

namespace Cinema.View
{
    public class ScreenFactory
    {
        private IDataManager DataManager { get; set; }

        //public UserControl screen;

        //public ScreenFactory()
        //{
        //    screen.DataContext = this;
        //}

        public ScreenFactory(IDataManager dataManager)
        {
            DataManager = dataManager;
        }

        public UserControl MovieScreen()
        {
            var screen = new MovieLibrary()
            {
                DataContext = new MovieLibraryVM(DataManager)
            };
            return screen;
        }

        public UserControl UserScreen()
        {
            var screen = new UsersView()
            {
                DataContext = new UserVM(DataManager)
            };
            return screen;
        }
    }
}
