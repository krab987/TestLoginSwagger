using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using HttpRequestException = System.Net.Http.HttpRequestException;

namespace TestSwaggerLogin.Model
{
    public sealed class MyApiClient: HttpClient
    {
        private readonly static Lazy<MyApiClient> client = new Lazy<MyApiClient>(() => new MyApiClient());
        private readonly static string apiUrl = "https://traceavit-pro.azurewebsites.net/api/";
        public static MyApiClient Client => client.Value;
        private MyApiClient()
        {
           
        }
        public async Task<HttpResponseMessage> PostLogin(string requestUri)
        {
            string responseData;
            HttpResponseMessage response;
            
            using (response = await Client.PostAsync(requestUri, null))
            {
                responseData = await response.Content.ReadAsStringAsync();
            }
            //MessageBox.Show(response.StatusCode.ToString(), "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            
            return response;
        }
        public async Task<string> Login (string? login)
        {
            // try
            // {
            //     if (string.IsNullOrWhiteSpace(login))
            //         throw new NullReferenceException("Логін не було зчитано - він пустий");
            //
            //     var response = await Client.PostAsync($"{apiUrl}user/login/{login}", null);
            //     response.EnsureSuccessStatusCode();
            //
            //     string responseBody = await response.Content.ReadAsStringAsync();
            // }
            // catch (NullReferenceException ex)
            // {
            //     MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            // }
            // //?
            // catch (HttpProtocolException ex)
            // {
            //     MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            // }
            // catch (HttpRequestException ex)
            // {
            //     MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            // }
            if (string.IsNullOrWhiteSpace(login))
                throw new NullReferenceException("Логін не було зчитано - він пустий");

            var response = await Client.PostAsync($"{apiUrl}user/login/{login}", null);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
