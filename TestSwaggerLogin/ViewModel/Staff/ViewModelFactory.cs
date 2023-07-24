using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace TestSwaggerLogin.ViewModel
{
    public enum ViewType
    {
        Login,
        Info,
        Allinfo,
        NanesurnameInfo
    }
    public interface IViewModelFactory
    {
        VmBase CreateViewModel(ViewType viewType);
    }
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<InfoViewModel> _createInfoViewModel;

        public ViewModelFactory(CreateViewModel<LoginViewModel> createLoginViewModel, 
            CreateViewModel<InfoViewModel> createInfoViewModel)
        {
            _createLoginViewModel = createLoginViewModel;
            _createInfoViewModel = createInfoViewModel;
        }
        public VmBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Info:
                    return _createInfoViewModel();

                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
