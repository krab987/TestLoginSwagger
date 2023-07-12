using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace TestSwaggerLogin.Model
{
    public class MyApiClient
    {
        private readonly HttpClient _client;

        public MyApiClient()
        {
            _client = new HttpClient();
        }
        
        public async Task<string> PostLogin(string requestUri)
        {
            string responseData;
            HttpResponseMessage response;
            
            using (HttpClient client = new HttpClient()) {
                using (response = await client.PostAsync(requestUri, null)) {
                    responseData = await response.Content.ReadAsStringAsync();
                }
            }
            MessageBox.Show(response.StatusCode.ToString(), "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            
            return responseData;
        }
    }
}
