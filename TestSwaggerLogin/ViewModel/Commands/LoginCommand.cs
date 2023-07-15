using DevExpress.Mvvm;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestSwaggerLogin.Model;

namespace TestSwaggerLogin.ViewModel.Commands
{
    public class LoginCommand: ICommand
    {
        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public async void Execute(object? login)
        {
            MyApiClient client = MyApiClient.Client;
            try
            {
                if (login == null)
                    throw new NullReferenceException("Argument cant be null");
                await client.Login(login.ToString());
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public async void Execute(object? login, Page paveVM)
        {
            MyApiClient client = MyApiClient.Client;
            try
            {
                if (login == null)
                    throw new NullReferenceException("Argument cant be null");
                await client.Login(login.ToString());
                paveVM.NavigationService.Navigate(new InfoViewModel());
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public event EventHandler? CanExecuteChanged;
    }
}
