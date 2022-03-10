using Cinema.Utils;
using Cinema.VM;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cinema.View
{
    public enum Appearance
    {
        Small,
        Big
    }

    public partial class MovieLibraryView : BaseView
    {
        public MovieLibraryVM MovieVM
        {
            get { return (MovieLibraryVM)DataContext; }
        }

        public MovieLibraryView()
        {
            InitializeComponent();

            var addBinding = new CommandBinding(Commands.AddMovieDialog, AddMovie_Executed, AddMovie_CanExecute);
            CommandBindings.Add(addBinding);

            var saveBinding = new CommandBinding(Commands.SaveAllChanges, SaveAllChanges_Executed, SaveAllChanges_CanExecute);
            CommandBindings.Add(saveBinding);

            var sortBinding = new CommandBinding(Commands.SortByCommand, SortByCommand_Executed, SortByCommand_CanExecute);
            CommandBindings.Add(sortBinding);

            var sortAscBinding = new CommandBinding(Commands.SortByAscCommand, SortByAscCommand_Executed, SortByAscCommand_CanExecute);
            CommandBindings.Add(sortAscBinding);

            var appearance = new CommandBinding(Commands.Appearance, Appearance_Executed, Appearance_CanExecute);
            CommandBindings.Add(appearance);

            var showRating = new CommandBinding(Commands.ShowRatingInfoCmd, ShowRatingInfoCmd_Executed, ShowRatingInfoCmd_CanExecute);
            CommandBindings.Add(showRating);

            var editMovie = new CommandBinding(Commands.EditMovieDialogCmd, EditMovieDialogCmd_Executed, EditMovieDialogCmd_CanExecute);
            CommandBindings.Add(editMovie);

            CommandManager.InvalidateRequerySuggested();

            Loaded += MovieLibrary_Loaded;
        }

        private void EditMovieDialogCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MovieVM.EditMovieDialog_Command();
        }

        private void EditMovieDialogCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = MovieVM.AddMovie_CanExecute();
        }

        private void ShowRatingInfoCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MovieVM.ShowRatingInfo_Command();
        }

        private void ShowRatingInfoCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = MovieVM.AddMovie_CanExecute();
        }

        private void Appearance_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if ((Appearance)e.Parameter == Appearance.Small)
            {
                moviesList.ItemTemplate = (DataTemplate)Resources["small"];
            }
            if ((Appearance)e.Parameter == Appearance.Big)
            {
                moviesList.ItemTemplate = (DataTemplate)Resources["normal"];
            }
        }


        private void Appearance_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = MovieVM.AddMovie_CanExecute();
        }

        private void MovieLibrary_Loaded(object sender, RoutedEventArgs e)
        {
            searchTextBox.Focus();
        }

        private void SortByAscCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = MovieVM.AddMovie_CanExecute();
        }

        private void SortByAscCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MovieVM.SortByAsc_CommandExecute(e.Parameter.ToString());
        }

        private void SortByCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = MovieVM.AddMovie_CanExecute();
        }

        private void SortByCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MovieVM.SortBy_CommandExecute(e.Parameter.ToString());
        }

        private void SaveAllChanges_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = MovieVM.AddMovie_CanExecute();
        }

        private void SaveAllChanges_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MovieVM.SaveAllChanges_Command();
            MessageBox.Show(ConstClass.changesSaved, ConstClass.saved, MessageBoxButton.OK);
        }

        private void AddMovie_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
           e.CanExecute = MovieVM.AddMovie_CanExecute();     
        }

        private void AddMovie_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MovieVM.AddMovieDialog_Command();
        }
    }
}
