
using Cinema.VM;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cinema.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MovieLibrary : UserControl
    {
        public MovieLibrary()
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

            CommandManager.InvalidateRequerySuggested();

            Loaded += MovieLibrary_Loaded;
        }

        private void Appearance_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter.ToString() == "1")
            {
                moviesList.ItemTemplate = (DataTemplate)this.Resources["small"];
            }
            if (e.Parameter.ToString() == "2")
            {
                moviesList.ItemTemplate = (DataTemplate)this.Resources["normal"];
            }
        }

        private void Appearance_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((MovieLibraryVM)DataContext).AddMovie_CanExecute();
        }

        private void MovieLibrary_Loaded(object sender, RoutedEventArgs e)
        {
            searchTextBox.Focus();
        }

        private void SortByAscCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((MovieLibraryVM)DataContext).AddMovie_CanExecute();
        }

        private void SortByAscCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((MovieLibraryVM)DataContext).SortByAsc_CommandExecute(e.Parameter.ToString());
        }

        private void SortByCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((MovieLibraryVM)DataContext).AddMovie_CanExecute();
        }

        private void SortByCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((MovieLibraryVM)DataContext).SortBy_CommandExecute(e.Parameter.ToString());
        }

        private void SaveAllChanges_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((MovieLibraryVM)DataContext).AddMovie_CanExecute();
        }

        private void SaveAllChanges_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((MovieLibraryVM)DataContext).SaveAllChanges_Command();
        }

        private void AddMovie_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
           e.CanExecute = ((MovieLibraryVM)DataContext).AddMovie_CanExecute();     
        }

        private void AddMovie_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((MovieLibraryVM)DataContext).AddMovieDialog_Command();
        }
    }
}
