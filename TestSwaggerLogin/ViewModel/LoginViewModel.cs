using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using TestSwaggerLogin.Model;
using TestSwaggerLogin.View.Pages;
using TestSwaggerLogin.ViewModel.Commands;

namespace TestSwaggerLogin.ViewModel
{
    public partial class LoginViewModel: ObservableObject
    {
        public LoginCommand LoginCommand { get; }

        private NavigationService navigationService;

        public LoginViewModel()
        {
            LoginCommand = new LoginCommand();
        }
        public LoginViewModel(NavigationService navigationService)
        {
            LoginCommand = new LoginCommand();
            this.navigationService = navigationService;
        }

        public ICommand GoNextPage
        {
            get
            {
                return new DelegateCommand(() => navigationService.Navigate(new InfoViewModel()));
            }
        }
        
    }
}
