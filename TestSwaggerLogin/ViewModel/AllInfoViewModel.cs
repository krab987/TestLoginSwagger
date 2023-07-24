using TestSwaggerLogin.Model;

namespace TestSwaggerLogin.ViewModel
{
    public class AllInfoViewModel : VmBase
    {
        private User _currentUser;

        public AllInfoViewModel(User currentUser)
        {
            _currentUser = currentUser;
        }
        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }
    }
}
