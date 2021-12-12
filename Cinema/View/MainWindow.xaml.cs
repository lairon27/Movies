using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
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
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        
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
    }
}
