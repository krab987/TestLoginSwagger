using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace TestSwaggerLogin.Model
{
    public class User
    {
        //{"name":"Operator Name","surname":"Operator Surname","number":"Operator","roles":["Operator"],"isValid":true,"authenticated":true}
        public string name { get; set; }
        public string surname { get; set; }
        public string number { get; set; }
        public ObservableCollection<string> roles { get; set; }
        public bool isvalid { get; set; }
        public bool authenticated { get; set; }
    }
}
