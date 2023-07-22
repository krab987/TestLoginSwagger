using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TestSwaggerLogin.Model;
using TestSwaggerLogin.ViewModel;

namespace TestSwaggerLogin.View
{
    public partial class LoginPage : Page
    {
        private string responceMessage = "";
        public LoginPage()
        {
            InitializeComponent();
        }
        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                responceMessage = await MyApiClient.Client.Login(TbLogin.Text);
                NavigationService.Navigate(new InfoViewModel(responceMessage));
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
