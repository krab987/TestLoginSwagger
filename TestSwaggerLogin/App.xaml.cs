using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using TestSwaggerLogin.ApiForce;
using TestSwaggerLogin.Model;
using TestSwaggerLogin.View;

namespace TestSwaggerLogin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IHost host;

        public App()
        {
            host = Host.CreateDefaultBuilder()
                .Add()
                .Build();
        }

        override protected async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();
            Window window = host.Services.GetRequiredService<MainWindow>();
            window.Show();
            
            base.OnStartup(e);
        }
        
        override protected async void OnExit(ExitEventArgs e)
        {
            await host.StopAsync();
            host.Dispose();
            
            base.OnExit(e);
        }
    }
}
