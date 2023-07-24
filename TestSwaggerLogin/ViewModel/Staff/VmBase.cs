using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Mvvm;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestSwaggerLogin.ViewModel
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : VmBase;
    public class VmBase: ObservableObject, INotifyPropertyChanged
    {
        public virtual void Dispose() { }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
