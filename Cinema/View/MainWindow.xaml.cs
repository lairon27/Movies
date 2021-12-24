using Cinema.Commands;
using System;
using System.Windows;
using System.Windows.Controls;


namespace Cinema.View
{
    /// <summary>
    /// Interaction logic for MovieLibrary.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;

            tabController.Items.Add(new TabItem
            {
                Header = "Movie Library",
                Content = new MovieLibrary()
             }) ;

            tabController.Items.Add(new TabItem
            {
                Header = "Users",
                Content = new Users()
            });
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //e.Cancel = true;

            if (MessageBox.Show("Do you want to save all changes?", "Close app", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }      
        }
    }
}
