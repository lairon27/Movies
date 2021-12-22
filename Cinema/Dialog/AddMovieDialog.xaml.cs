using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
        }

        public void add_Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void DowloadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new();
            myDialog.Filter = "Images(*.JPG;*.PNG)|*.JPG;*.PNG" + "|All Files (*.*)|*.* ";
            myDialog.CheckFileExists = true;
            if (myDialog.ShowDialog() == true)
            {
                txb_ImageFileName.Text = myDialog.FileName;
            }
        }

        private void cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
