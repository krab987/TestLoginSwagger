using System.Windows;
using TestSwaggerLogin.View;
using TestSwaggerLogin.ViewModel;

namespace TestSwaggerLogin
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        override protected void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = new MainViewModel();
            mainWindow.Show();
        }
    }
}
