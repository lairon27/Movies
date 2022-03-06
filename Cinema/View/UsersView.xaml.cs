using Cinema.Model;
using Cinema.VM;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cinema.View
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        public UsersView()
        {
            InitializeComponent();

            var userGenerator = new CommandBinding(Commands.UsersGeneratorCommand, UsersGeneratorCommand_Executed, UsersGeneratorCommand_CanExecute);
            CommandBindings.Add(userGenerator);

            var saveBinding = new CommandBinding(Commands.SaveAllChanges, SaveAllChanges_Executed, SaveAllChanges_CanExecute);
            CommandBindings.Add(saveBinding);

            var addRating = new CommandBinding(Commands.AddRatingCommand, AddRatingCommand_Executed, AddRatingCommand_CanExecute);
            CommandBindings.Add(addRating);

            CommandManager.InvalidateRequerySuggested();

            Loaded += Users_Loaded;
        }

        private void AddRatingCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((UserVM)DataContext).AddRating_CommandExecute();
        }

        private void AddRatingCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((UserVM)DataContext).UserGenerator_CanExecute();
        }

        private void SaveAllChanges_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((UserVM)DataContext).SaveUsers_CommandExecute();
        }

        private void SaveAllChanges_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((UserVM)DataContext).UserGenerator_CanExecute();
        }

        private void Users_Loaded(object sender, RoutedEventArgs e)
        {
            usersList.Focus();
        }

        private void UsersGeneratorCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((UserVM)DataContext).UsersGenerator_CommandExecute();
        }

        private void UsersGeneratorCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((UserVM)DataContext).UserGenerator_CanExecute();
        }

        private void Grid_PreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Command == DataGrid.DeleteCommand)
            {
                if (MessageBox.Show(String.Format("Are you sure?"), "Confirm Delete", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
                { 
                    e.Handled = true;
                }
            }
        }
    }
}
