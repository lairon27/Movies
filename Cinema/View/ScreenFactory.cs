using Cinema.Service;

namespace Cinema.View
{
    public class ScreenFactory
    {
        //IDataManager dataManager = new DataManager();
        public object MovieScreen()
        {
            var screen = new MovieLibrary();
            //{
            //    DataContext = new MovieLibraryVM(dataManager)
            //};
            //screen.DataContext = new MovieLibraryVM(dataManager);
            return screen;
        }

        public object UserScreen()
        {
            var screen = new UsersView();
            //{
            //    DataContext = new UserVM(dataManager)
            //};
            //screen.DataContext = new UserVM(dataManager);
            return screen;
        }
    }
}
