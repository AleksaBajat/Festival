using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Authentication;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    public class LoginCommand:AsyncBaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
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
            _log.Info("Executed Login Command");
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