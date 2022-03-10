using Cinema.Service;
using System.Windows.Controls;

namespace Cinema.View
{
    public class ScreenFactory
    {
        private IDataManager DataManager { get; set; }

        public ScreenFactory(IDataManager dataManager)
        {
            DataManager = dataManager;
        }

        public BaseView CreateMovieScreen()
        {
            var screen = new MovieLibrary()
            {
                DataContext = new MovieLibraryVM(DataManager)
            };
            return screen;
        }

        public BaseView CreateUserScreen()
        {
            var screen = new UsersView()
            {
                DataContext = new UserVM(DataManager)
            };
            return screen;
        }
    }
}
