using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Mvvm;
using System.Windows.Input;
using System.Windows.Navigation;
using TestSwaggerLogin.ViewModel.Commands;

namespace TestSwaggerLogin.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        public LoginViewModel()
        {
            LoginCommand = new LoginCommand();
        }
        public LoginCommand LoginCommand { get; }
        
    }
}
