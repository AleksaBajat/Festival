using System.Threading.Tasks;
using Client.State.Authentication;

namespace Client.Commands
{
    public class LogoutCommand:AsyncBaseCommand
    {
        private readonly IAuthenticator _authenticator;

        public LogoutCommand(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            await _authenticator.Logout();
        }
    }
}