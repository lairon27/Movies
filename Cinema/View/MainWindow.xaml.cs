
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

            tabController.Items.Add(new TabItem
            {
                Header = "Movie Library",
                Content = new MovieLibrary()
                {
                    DataContext = new MovieLibraryVM()
                }
            });

            tabController.Items.Add(new TabItem
            {
                Header = "Users",
                Content = new Users()
                {
                    DataContext = new UsersVM()
                }
            }) ;
        }
    }
}
