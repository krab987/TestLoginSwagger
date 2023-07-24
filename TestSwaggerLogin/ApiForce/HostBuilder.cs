using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TestSwaggerLogin.View;
using TestSwaggerLogin.ViewModel;

namespace TestSwaggerLogin.ApiForce
{
    public static class HostBuilder
    {
        public static IHostBuilder Add(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddHttpClient<ApiClient>(httpclient =>
                {
                    httpclient.BaseAddress = new Uri("https://traceavit-pro.azurewebsites.net/api/");
                });
                services.AddSingleton<IViewModelFactory, ViewModelFactory>();

                services.AddTransient<MainViewModel>();
                services.AddTransient(CreateInfoViewModel);
                
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                services.AddSingleton<CreateViewModel<InfoViewModel>>(services => () => services.GetRequiredService<InfoViewModel>());
                // services.AddSingleton<CreateViewModel<InfoViewModel>>(services => () => new InfoViewModel(services.GetRequiredService<IMyService>()));
                
                services.AddSingleton<ViewModelNavigator<InfoViewModel>>();
                services.AddSingleton<ViewModelNavigator<LoginViewModel>>();
                
                
                services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
                
                services.AddSingleton<IMyService, MyService>();
                services.AddSingleton<INavigator, Navigator>();
            });

            return host;
        }
        private static InfoViewModel CreateInfoViewModel(IServiceProvider services)
        {
            return new InfoViewModel(
                services.GetRequiredService<IMyService>());
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        {
            return new LoginViewModel(
                services.GetRequiredService<IMyService>(),
                services.GetRequiredService<ViewModelNavigator<InfoViewModel>>());
        }
    }
}
