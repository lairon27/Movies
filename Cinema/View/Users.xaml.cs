using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using System.Xml.Serialization;

namespace Cinema.View
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
            DataContext = new UsersVM();

            //var uri = new Uri("/images/item0.jpg", UriKind.Relative);
            //img.Source =new  BitmapImage(uri);

            //Image myImage3 = new Image();
            //BitmapImage bi3 = new BitmapImage();
            //bi3.BeginInit();
            //bi3.UriSource = new Uri("/Resources / avengersInfinityWar.jpg", UriKind.Relative);
            //bi3.EndInit();
            //myImage3.Stretch = Stretch.Fill;
            //myImage3.Source = bi3;

        }
    }
}
