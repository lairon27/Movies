using System.Windows.Input;

namespace Cinema.VM
{
    internal class Commands
    {
        static Commands()
        {
            AddMovieDialog = new RoutedUICommand("AddMovieDialog", "AddMovieDialog", typeof(Commands));
            SaveAllChanges = new RoutedUICommand("SaveAllChanges", "SaveAllChanges", typeof(Commands));
            SortByCommand = new RoutedUICommand("SortByCommand", "SortByCommand", typeof(Commands));
            SortByAscCommand = new RoutedUICommand("SortByAscCommand", "SortByAscCommand", typeof(Commands));
            Appearance = new RoutedUICommand("Appearance", "Appearance", typeof(Commands));
            UsersGeneratorCommand = new RoutedUICommand("UsersGeneratorCommand", "UsersGeneratorCommand", typeof(Commands));
            AddRatingCommand = new RoutedUICommand("AddRatingCommand", "AddRatingCommand", typeof (Commands));
            DeleteRatingCommand = new RoutedUICommand("DeleteRatingCommand", "DeleteRatingCommand", typeof(Commands));
        }

        public static RoutedUICommand AddMovieDialog { get; set; }
        public static RoutedUICommand SaveAllChanges { get; set; }
        public static RoutedUICommand SortByCommand { get; set; }
        public static RoutedUICommand SortByAscCommand { get; set; }
        public static RoutedUICommand Appearance { get; set; }
        public static RoutedUICommand UsersGeneratorCommand { get; set; }
        public static RoutedCommand AddRatingCommand { get; set; }
        public static RoutedCommand DeleteRatingCommand { get; set; }
    }
}
