using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Mvvm;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TestSwaggerLogin.ApiForce;
using TestSwaggerLogin.Model;

namespace TestSwaggerLogin.ViewModel
{
     public class InfoViewModel: VmBase
    {
        private VmBase allInfo;
        private VmBase nameSurname;
        private VmBase current;
        public VmBase Current
        {
            get
            {
                return current;
            }
            set
            {
                current = value;
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
        
        IMyService _myService;
        public InfoViewModel (IMyService myService)
        {
            _myService = myService;
            allInfo = new AllInfoViewModel(myService.CurrentUser);
            nameSurname = new NameSurnameViewModel(myService.CurrentUser.name, myService.CurrentUser.surname);
            
            Current = allInfo;
            FrameOpacity = 1;
        }

        public ICommand AllInfoCommand
        {
            get
            {
                return new AsyncCommand(() => ChangePageOpacity(allInfo));
            }
        }
        public ICommand NameSurnameCommand
        {
            get
            {
                return new AsyncCommand(() => ChangePageOpacity(nameSurname));
            }
        }

        
        private async Task ChangePageOpacity(VmBase control)
        {
            await Task.Factory.StartNew(() =>
                {
                    for (double i = 1.0; i > 0.4; i -= 0.1)
                    {
                        FrameOpacity = i;
                        Thread.Sleep(15);
                    }
                    Current = control;
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
