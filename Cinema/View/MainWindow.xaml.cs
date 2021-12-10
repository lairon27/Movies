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
            var tabItem = new TabItem();
            tabItem.Content = new MovieLibrary();
            tabItem.Header = "MovieLibrary";
            tabcont1.Items.Add(tabItem);

            var tabItem1 = new TabItem();
            tabItem1.Content = new Users();
            tabItem1.Header = "Users";
            tabcont1.Items.Add(tabItem1);
        }
    }
}
