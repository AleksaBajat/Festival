using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Authentication;
using Client.State.Logging;
using log4net;

namespace Client.Commands
{
    public class LogoutCommand:AsyncBaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly IAuthenticator _authenticator;
        private readonly INavigationService _navigationService;

        public LogoutCommand(IAuthenticator authenticator,INavigationService navigationService)
        {
            _navigationService = navigationService;
            _authenticator = authenticator;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            await _authenticator.Logout();
            _log.Info("Executed Logout Command");
            _navigationService.NavigateToLogin();
        }
    }
}