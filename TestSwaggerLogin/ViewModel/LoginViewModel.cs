using System.Windows.Input;
using TestSwaggerLogin.ApiForce;
using TestSwaggerLogin.Model;
using TestSwaggerLogin.ViewModel.Commands;

namespace TestSwaggerLogin.ViewModel
{
    
    public partial class LoginViewModel: VmBase
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }
        private IViewModelNavigator navigator;
        private IMyService myService;
        
        public LoginCommand LoginCommand { get; }
        
        public LoginViewModel(IMyService myService, IViewModelNavigator navigator)
        {
            this.myService = myService;
            this.navigator = navigator;
            LoginCommand = new LoginCommand(this, navigator, myService);
        }

    }
}
