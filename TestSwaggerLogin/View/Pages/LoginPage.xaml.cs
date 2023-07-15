using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using TestSwaggerLogin.Model;
using TestSwaggerLogin.ViewModel;

namespace TestSwaggerLogin.View.Pages
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
            MyApiClient client = MyApiClient.Client;
            try
            {
                if (TbLogin.Text == null)
                    throw new NullReferenceException("Argument cant be null");
                responceMessage =  await client.Login(TbLogin.Text);
                NavigationService.Navigate(new InfoViewModel(responceMessage));
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //?
            catch (HttpProtocolException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

