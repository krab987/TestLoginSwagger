namespace TestSwaggerLogin.ViewModel
{
    public class NameSurnameViewModel: VmBase
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged();
            }
        }   
        
        public NameSurnameViewModel(string currentUserName, string currentUserSurname)
        {
            Name = currentUserName;
            Surname = currentUserSurname;
        }
        public NameSurnameViewModel()
        {
        }

    }
}
