using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using TestSwaggerLogin.Model;

namespace TestSwaggerLogin.View
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MyApiClient apiClient = new MyApiClient();
            var res = apiClient.PostLogin("https://traceavit-pro.azurewebsites.net/api/user/login/" + tbLogin.Text);
        }
    }
    
}

