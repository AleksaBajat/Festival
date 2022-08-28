using System.Windows.Input;
using Client.Commands;
using Client.State.Authentication;

namespace Client.ViewModels
{
    public class AdminViewModel:BaseViewModel
    {
        private string _firstName;
        private string _lastName;
        private string _username;
        private string _password;
        private bool _isAdmin;

        public bool IsAdmin
        {
            get => _isAdmin;
            set
            {
                _isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(_firstName));
            } 
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(_lastName));
            } 
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(_username));
            } 
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand RegisterCommand { get; set; }

        public AdminViewModel()
        {
            RegisterCommand = new RegisterCommand(this);
        
        }


    }
}