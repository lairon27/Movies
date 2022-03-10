using Cinema.Service;

namespace Cinema.View
{
    public enum View
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

        public BaseView CreateScreen(View view)
        {
            switch (view)
            {
                case View.Movie:
                    return new MovieLibraryView() 
                    { 
                        DataContext = new MovieLibraryVM(DataManager) 
                    };
                case View.User:
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
