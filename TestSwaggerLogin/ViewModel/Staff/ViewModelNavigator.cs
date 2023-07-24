namespace TestSwaggerLogin.ViewModel
{
    public interface IViewModelNavigator
    {
        void NavigateVm();
    }
    public class ViewModelNavigator<TViewModel> : IViewModelNavigator where TViewModel : VmBase
    {
        private readonly INavigator _navigator;
        private readonly CreateViewModel<TViewModel> _createViewModel;

        public ViewModelNavigator(INavigator navigator, CreateViewModel<TViewModel> createViewModel)
        {
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        public void NavigateVm()
        {
            _navigator.CurrentViewModel = _createViewModel();
        }
    }
}
