using System.Threading.Tasks;
using Client.State.Authentication;
using Client.State.Resolver;

namespace Client.Commands
{
    public class LogoutCommand:AsyncBaseCommand
    {
        private readonly IAuthenticator _authenticator;

        public LogoutCommand(IAuthenticator authenticator)
        {
            _authenticator = DependencyResolver.Resolve<IAuthenticator>();
        }
        public override async Task ExecuteAsync(object parameter)
        {
            await _authenticator.Logout();
        }
    }
}