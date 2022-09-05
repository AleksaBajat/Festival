using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Authentication;
using Client.ViewModels;

namespace Client.Commands
{
    public class LoginCommand:AsyncBaseCommand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly INavigationService _navigationService;
        public LoginCommand(IAuthenticator authenticator,INavigationService navigationService,LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _navigationService = navigationService;
        }
        
        
        public override async Task ExecuteAsync(object parameter)
        {
            await _authenticator.Login(_loginViewModel.Username, _loginViewModel.Password);
            if (_authenticator.IsLoggedIn)
            {
                if (_authenticator.IsAdmin)
                {
                    _navigationService.NavigateToAdmin();
                }
                else
                {
                    _navigationService.NavigateToFestival();
                }
            }
        }
    }
}