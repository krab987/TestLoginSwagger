using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestSwaggerLogin.Model
{
    public sealed class MyApiClient: HttpClient
    {
        private readonly static Lazy<MyApiClient> client = new Lazy<MyApiClient>(() => new MyApiClient
        {
            BaseAddress = new Uri("https://traceavit-pro.azurewebsites.net/api/"),
        });
        public static MyApiClient Client => client.Value;
        
        private MyApiClient()
        {
            
        }
        public async Task<string> Login (string? login)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new NullReferenceException("Argument cant be null or empty string");

            var response = await Client.PostAsync($"user/login/{login}", null);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
            
        }
    }
}
