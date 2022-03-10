using Cinema.Dialog;
using Cinema.Model;
using Cinema.Utils;
using Cinema.VM;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cinema.View
{
    public partial class UsersView : BaseView
    {
        public UserVM UserVM
        {
            get { return (UserVM)DataContext; }
        }

        public UsersView()
        {
            InitializeComponent();

            var userGenerator = new CommandBinding(Commands.UsersGeneratorCommand, UsersGeneratorCommand_Executed, UsersGeneratorCommand_CanExecute);
            CommandBindings.Add(userGenerator);

            var saveBinding = new CommandBinding(Commands.SaveAllChanges, SaveAllChanges_Executed, SaveAllChanges_CanExecute);
            CommandBindings.Add(saveBinding);

            var addRating = new CommandBinding(Commands.AddRatingCommand, AddRatingCommand_Executed, AddRatingCommand_CanExecute);
            CommandBindings.Add(addRating);

            var deleteRating = new CommandBinding(Commands.DeleteRatingCommand, DeleteRatingCommand_Executed, DeleteRatingCommand_CanExecute);
            CommandBindings.Add(deleteRating);

            CommandManager.InvalidateRequerySuggested();

            Loaded += Users_Loaded;
        }

        private void DeleteRatingCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = UserVM.UserGenerator_CanExecute();
        }

        private void DeleteRatingCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (MessageBox.Show(ConstClass.deleteItem, ConstClass.delete, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                UserVM.DeleteRating_CommandExecute();
            }
        }

        private void AddRatingCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UserVM.AddRating_CommandExecute();
        }

        private void AddRatingCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = UserVM.UserGenerator_CanExecute();
        }

        private void SaveAllChanges_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UserVM.SaveUsers_CommandExecute();
            MessageBox.Show(ConstClass.changesSaved, ConstClass.saved, MessageBoxButton.OK);
        }

        private void SaveAllChanges_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = UserVM.UserGenerator_CanExecute();
        }

        private void Users_Loaded(object sender, RoutedEventArgs e)
        {
            usersList.Focus();
        }

        private void UsersGeneratorCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            InputIntDialog dialog = new InputIntDialog(ConstClass.amountOf, ConstClass.inputNumber);
            dialog.ShowDialog();

            UserVM.UsersGenerator_CommandExecute(dialog.Number);
        }

        private void UsersGeneratorCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = UserVM.UserGenerator_CanExecute();
        }
    }
}
