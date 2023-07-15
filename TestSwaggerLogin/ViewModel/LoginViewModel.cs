using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Mvvm;
using System.Windows.Input;
using System.Windows.Navigation;
using TestSwaggerLogin.ViewModel.Commands;

namespace TestSwaggerLogin.ViewModel
{
    public class LoginViewModel : ObservableObject
    {

        private readonly NavigationService navigationService;

        public LoginViewModel()
        {
            LoginCommand = new LoginCommand();
        }
        public LoginViewModel(NavigationService navigationService)
        {
            LoginCommand = new LoginCommand();
            this.navigationService = navigationService;
        }
        public LoginCommand LoginCommand { get; }

        public ICommand GoNextPage
        {
            get
            {
                return new DelegateCommand(() => navigationService.Navigate(new InfoViewModel()));
            }
        }
    }
}
