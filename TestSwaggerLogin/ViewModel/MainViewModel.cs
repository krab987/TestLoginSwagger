using DevExpress.Mvvm;
using System.Windows.Input;
using TestSwaggerLogin.Model;
using TestSwaggerLogin.ViewModel.Commands;

namespace TestSwaggerLogin.ViewModel
{
    public class MainViewModel: VmBase
    {
        private IViewModelFactory viewModelFactory;
        private INavigator navigator;
        public VmBase  CurrentViewModel => navigator.CurrentViewModel;

        public ICommand UpdateViewModelCommand { get; }
        public MainViewModel(IViewModelFactory viewModelFactory, INavigator navigator)
        {
            this.viewModelFactory = viewModelFactory;
            this.navigator = navigator;
            navigator.StateChanged += () => OnPropertyChanged(nameof(CurrentViewModel));

            UpdateViewModelCommand = new UpdateViewModelCommand(navigator, viewModelFactory);
            UpdateViewModelCommand.Execute(ViewType.Login);
        }
        
        public override void Dispose()
        {
            navigator.StateChanged -= () => OnPropertyChanged(nameof(CurrentViewModel));

            base.Dispose();
        }
    }
    
}
