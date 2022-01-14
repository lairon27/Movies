using Cinema.Model;
using System.Windows;
using System.Windows.Controls;

namespace Cinema.Dialog
{
    /// <summary>
    /// Interaction logic for AmountOfUsers.xaml
    /// </summary>
    public partial class AmountOfUsersDialog : Window
    {
        //public TextBox count;

        public AmountOfUsersDialog()
        {
            InitializeComponent();
            DataContext = new User();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public int NumberOfUsersForGenerating()
        {
            int amount;
            if (int.TryParse(number.Text, out int count))
            {
                amount = count;
            }
            else
            {
                MessageBox.Show("The input data must be a number!", "Incorrect value", MessageBoxButton.OK, MessageBoxImage.Warning);
                amount = 0;
            }

            return amount;
        }
    }
}
