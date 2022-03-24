using Cinema.Utils;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Cinema.View
{
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
                Icon = new BitmapImage(new Uri("pack://application:,,,/Resources/icons/pen.png"));
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
            if (MessageBox.Show(ConstClass.saveChanges, ConstClass.close, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DialogResult = true;
            }
        }
    }
}
