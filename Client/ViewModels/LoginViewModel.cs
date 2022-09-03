using System.Windows.Input;
using Client.Commands;
using Client.Models;
using Client.State.Authentication;
using Client.Stores;

namespace Client.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        private string _username = "";
        
        public string Username
        {
            get => _username;

            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        
        private string _password = "";
        
        public string Password
        {
            get => _password;

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new LoginCommand(this);
        }
    }
}