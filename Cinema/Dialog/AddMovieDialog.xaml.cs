using Cinema.Utils;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Xceed.Wpf.Toolkit;

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
            genresComboBox.ItemsSource = Enum.GetValues(typeof(Genres));
            genresComboBox.SelectedValue = movie.Genre.ToString().Replace(" ", "");
            DataContext = movie;
           
            Closing += AddWindow_Closing;

            if (editMode)
            {
                addBtn.Content = ConstClass.saveBtn;
                Title = ConstClass.editTitile;
            }

        }

        public void add_Button_Click(object sender, RoutedEventArgs e)
        {
            Closing -= AddWindow_Closing;
            ((Movie)DataContext).Genre = (Genres)Enum.Parse(typeof(Genres),genresComboBox.SelectedValue);
            DialogResult = true;
        }

        private void DowloadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog chooseImageDialog = new OpenFileDialog();
            chooseImageDialog.Filter = ConstClass.imageFilter;
            chooseImageDialog.CheckFileExists = true;
            if (chooseImageDialog.ShowDialog() == true && DataContext is Movie)
            {
                ((Movie)DataContext).Image = chooseImageDialog.FileName;
            }
        }

        private void cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Closing -= AddWindow_Closing;
            Close();
        }

        private void AddWindow_Closing(object sender, CancelEventArgs e)
        {
            if (System.Windows.MessageBox.Show(ConstClass.saveChanges, ConstClass.close, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DialogResult = true;
            }
        }
    }
}
