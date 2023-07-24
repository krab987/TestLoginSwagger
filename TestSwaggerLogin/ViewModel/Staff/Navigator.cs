using System;

namespace TestSwaggerLogin.ViewModel
{
    public interface INavigator
    {
        VmBase CurrentViewModel { get; set; }
        event Action StateChanged;
    }
    public class Navigator : INavigator
    {
        private VmBase _currentViewModel;
        public VmBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel?.Dispose();

                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;

    }
}
