using System.Windows;

namespace Cinema.Dialog
{
    /// <summary>
    /// Interaction logic for AmountOfUsers.xaml
    /// </summary>
    public partial class InputIntDialog : Window
    {
        private int _number;

        public InputIntDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
    }
}
