using System.Collections.ObjectModel;

namespace TestSwaggerLogin.Model
{
    public class User
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string number { get; set; }
        public ObservableCollection<string> roles { get; set; }
        public bool isvalid { get; set; }
        public bool authenticated { get; set; }
    }
}
