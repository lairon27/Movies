using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace Cinema.Dialog
{
    /// <summary>
    /// Interaction logic for EditMovieDialog.xaml
    /// </summary>
    public partial class EditMovieDialog : Window
    {
        public EditMovieDialog()
        {
            InitializeComponent();
            DataContext = new Movie();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
