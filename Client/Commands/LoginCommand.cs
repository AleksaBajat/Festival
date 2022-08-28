using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using Client.Models;
using Client.State.Authentication;
using Client.State.Resolver;
using Client.Stores;
using Client.ViewModels;
using static Common.Enums.CommonEnumerations;

namespace Client.Commands
{
    public class LoginCommand:AsyncBaseCommand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        public LoginCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
            _authenticator = DependencyResolver.Resolve<IAuthenticator>();
        }
        
        
        public override async Task ExecuteAsync(object parameter)
        {
            await _authenticator.Login(_loginViewModel.Username, _loginViewModel.Password);
        }
    }
}