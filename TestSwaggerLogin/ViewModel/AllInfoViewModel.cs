using CommunityToolkit.Mvvm.ComponentModel;
using TestSwaggerLogin.Model;

namespace TestSwaggerLogin.ViewModel
{
    public class AllInfoViewModel: ObservableObject
    {
        private User _currentUser;
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
        
        public AllInfoViewModel(User currentUser)
        {
            _currentUser = currentUser;
        }

    }
}
