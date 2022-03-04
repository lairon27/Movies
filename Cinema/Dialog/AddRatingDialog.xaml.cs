using Cinema.Model;
using Cinema.Service;
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
    /// Interaction logic for AddRatingDialog.xaml
    /// </summary>
    public partial class AddRatingDialog : Window
    {
        private string title;
        private int rating;

        public AddRatingDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public string MovieTitle
        {
            get { return title; }
            set { title = value; }
        }

        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }
    }
}
