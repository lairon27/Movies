using Cinema.Model;
using System.Windows;

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
