using Cinema.Generation;
using Cinema.Model;
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
    /// Interaction logic for AmountOfUsers.xaml
    /// </summary>
    public partial class AmountOfUsers : Window
    {
        public AmountOfUsers()
        {
            InitializeComponent();
            DataContext = new User();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
