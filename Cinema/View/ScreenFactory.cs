using Cinema.Service;

namespace Cinema.View
{
    public enum ViewID
    {
        Movie,
        User
    }

    public class ScreenFactory
    {
        private IDataManager DataManager { get; set; }

        public ScreenFactory(IDataManager dataManager)
        {
            DataManager = dataManager;
        }

        public BaseView CreateScreen(ViewID view)
        {
            switch (view)
            {
                case ViewID.Movie:
                    return new MovieLibraryView() 
                    { 
                        DataContext = new MovieLibraryVM(DataManager) 
                    };
                case ViewID.User:
                    return new UsersView()
                    {
                        DataContext = new UserVM(DataManager)
                    };
                default:
                    return null;
            }
        }
    }
}
