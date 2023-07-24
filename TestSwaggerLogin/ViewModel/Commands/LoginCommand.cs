using DevExpress.Mvvm;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestSwaggerLogin.ApiForce;
using TestSwaggerLogin.Model;

namespace TestSwaggerLogin.ViewModel.Commands
{
    public class LoginCommand: AsyncCommandBase
    {
        private LoginViewModel loginViewModel;
        private IViewModelNavigator navigator;
        private IMyService myService;
        
        public LoginCommand(LoginViewModel loginViewModel, IViewModelNavigator navigator, IMyService myService)
        {
            this.loginViewModel = loginViewModel;
            this.navigator = navigator;
            this.myService = myService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await myService.Login("Master");
                // await myService.Login(loginViewModel.Username);
                navigator.NavigateVm();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (UriFormatException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
