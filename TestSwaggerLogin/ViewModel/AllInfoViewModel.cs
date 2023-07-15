using CommunityToolkit.Mvvm.ComponentModel;
using TestSwaggerLogin.Model;

namespace TestSwaggerLogin.ViewModel
{
    public class AllInfoViewModel: ObservableObject
    {
        private User currentUser;
        public User CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
                OnPropertyChanged();
            }
        }
        
        public AllInfoViewModel(User currentUser)
        {
            CurrentUser = currentUser;
        }

    }
}
