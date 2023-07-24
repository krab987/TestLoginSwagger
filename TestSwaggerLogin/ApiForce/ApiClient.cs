using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestSwaggerLogin.ApiForce
{
    public class ApiClient
    {
        private readonly HttpClient httpClient;
        public ApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        
        public async Task<T> PostAsync<T>(string uri, HttpContent content)
        {
            HttpResponseMessage response = await httpClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
