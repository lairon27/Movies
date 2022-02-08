using Cinema.View;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    { 
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var splash = new SplashWindow();
            splash.Show();

            var main = new MainWindow();

            Task.Run(() =>
            {
                main.LoadData();

                Dispatcher.Invoke(() =>
                {
                    main.Show();
                    splash.Close();
                }); 
            });
        }
    }
}
