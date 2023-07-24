using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Threading.Tasks;
using TestSwaggerLogin.Model;

namespace TestSwaggerLogin.ApiForce
{
    public interface IMyService
    {
        User CurrentUser { get; set; }
        Task Login(string? login);
    }
    public class MyService : IMyService
    {
        private readonly ApiClient _client;
        private User currentUser;
        public User CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
            }
        }
        
        public MyService(ApiClient client)
        {
            _client = client;
        }

        public async Task Login(string? login)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new NullReferenceException("Argument cant be null or empty string");

            User response = await _client.PostAsync<User>($"user/login/{login}", null);
            CurrentUser = response;
        }
    }

    
}
