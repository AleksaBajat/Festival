using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Commands;
using Client.Services.Abstractions;
using Client.State.Authentication;

namespace Client.ViewModels
{
    internal class ProfileViewModel:BaseViewModel
    {
        private readonly IAuthenticator _authenticator;

        public ICommand NavigateFestivalCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public ICommand ChangePasswordCommand { get; set; }

        private string _username;

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                ((BaseCommand)ChangePasswordCommand).OnCanExecuteChanged();
                OnPropertyChanged(nameof(Password));
            }
        }
        public ProfileViewModel(IAuthenticator authenticator,INavigationService navigationService,IRegisterService registerService)
        {
            _authenticator = authenticator;

            Username = _authenticator.Account.Username;

            NavigateFestivalCommand = new NavigateFestivalCommand(navigationService);

            LogoutCommand = new LogoutCommand(authenticator,navigationService);

            ChangePasswordCommand = new ChangePasswordCommand(this,registerService);
        }
    }
}
