using Microsoft.Win32;
using System.ComponentModel;
using System.Windows;

namespace Cinema.View
{
    /// <summary>
    /// Interaction logic for AddMovie.xaml
    /// </summary>
    public partial class AddMovieDialog : Window
    {
        public AddMovieDialog()
        {
            InitializeComponent();
            DataContext = new Movie();
            Closing += AddWindow_Closing;
            //saveBtn += cancel_Button_Click;
        }

        public void add_Button_Click(object sender, RoutedEventArgs e)
        {
            Closing -= AddWindow_Closing;
            DialogResult = true;
        }

        private void DowloadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new();
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
            //DialogResult = false;
            Close();
            //e.Cancel = true;
        }

        private void AddWindow_Closing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Do you want to save all changes?", "Close app", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DialogResult = true;
            }
        }

        public void Editor()
        {
            addBtn.Visibility = Visibility.Hidden;
            saveBtn.Visibility = Visibility.Visible;
            Title = "Movie Editor";
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Closing -= AddWindow_Closing;
            DialogResult = true;
            //Close();
        }
    }
}
