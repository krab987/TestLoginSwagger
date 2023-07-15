using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Mvvm;
using System.Text.Json;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TestSwaggerLogin.Model;

namespace TestSwaggerLogin.ViewModel
{
    public class InfoViewModel: ObservableObject
    {
        private string responseMessage;
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
        private ObservableObject allInfoVm;
        private ObservableObject nameSurnameVm;
        private ObservableObject _currentVm;
        public ObservableObject CurrentVm
        {
            get
            {
                return _currentVm;
            }
            set
            {
                _currentVm = value;
                OnPropertyChanged();
            }
        }
        private double _frameOpacity;
        public double FrameOpacity
        {
            get
            {
                return _frameOpacity;
            }
            set
            {
                _frameOpacity = value;
                OnPropertyChanged();
            }
        }
        
        public InfoViewModel(string responseMessage)
        {
            this.responseMessage = responseMessage;
            currentUser = JsonSerializer.Deserialize<User>(responseMessage);

            allInfoVm = new AllInfoViewModel(currentUser);
            nameSurnameVm = new NameSurnameViewModel(currentUser.name, currentUser.surname);
            
            CurrentVm = allInfoVm;
            FrameOpacity = 1;
        }
        public InfoViewModel()
        {
        }

        public ICommand AllInfoCommand
        {
            get
            {
                return new AsyncCommand(() => ChangePageOpacity(allInfoVm));
            }
        }
        public ICommand NameSurnameCommand
        {
            get
            {
                return new AsyncCommand(() => ChangePageOpacity(nameSurnameVm));
            }
        }

        
        private async Task ChangePageOpacity(ObservableObject controlVM)
        {
            await Task.Factory.StartNew(() =>
                {
                    for (double i = 1.0; i > 0.4; i -= 0.1)
                    {
                        FrameOpacity = i;
                        Thread.Sleep(15);
                    }
                    CurrentVm = controlVM;
                    for (double i = 0.4; i < 1.1; i += 0.1)
                    {
                        FrameOpacity = i;
                        Thread.Sleep(15);
                    }
                }
            );
        }


    }
}
