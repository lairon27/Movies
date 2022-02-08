using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows;

namespace Cinema.View
{
    /// <summary>
    /// Interaction logic for AddMovie.xaml
    /// </summary>
    public partial class AddMovieDialog : Window
    {
        public AddMovieDialog(Movie movie, bool editMode = false)
        {
            InitializeComponent();
            DataContext = movie;
            Closing += AddWindow_Closing;

            if (editMode)
            {
                addBtn.Content = "Save";
                Title = "Movie Editor";
            }

        }

        public void add_Button_Click(object sender, RoutedEventArgs e)
        {
            Closing -= AddWindow_Closing;
            DialogResult = true;
        }

        private void DowloadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Images(*.JPG;*.PNG;*.JPEG)|*.JPG;*.PNG;*.JPEG" + "|All Files (*.*)|*.* ";
            myDialog.CheckFileExists = true;
            if (myDialog.ShowDialog() == true && DataContext is Movie)
            {
                ((Movie)DataContext).Image = myDialog.FileName;
            }
        }

        private void cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Closing -= AddWindow_Closing;
            Close();
        }

        private void AddWindow_Closing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Do you want to save all changes?", "Close app", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DialogResult = true;
            }
        }
    }
}
