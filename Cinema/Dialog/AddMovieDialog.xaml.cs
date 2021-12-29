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
        }

        public void add_Button_Click(object sender, RoutedEventArgs e)
        {
            Closing -= AddWindow_Closing;
            DialogResult = true;
        }

        private void DowloadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new();
            myDialog.Filter = "Images(*.JPG;*.PNG)|*.JPG;*.PNG" + "|All Files (*.*)|*.* ";
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
