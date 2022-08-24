using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using Client.Models;
using Client.State.Authentication;
using Client.Stores;
using Client.ViewModels;
using static Common.Enums.CommonEnumerations;

namespace Client.Commands
{
    public class LoginCommand:AsyncBaseCommand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly NavigationStore _navigationStore;
        private readonly IAuthenticator _authenticator;
        public LoginCommand(LoginViewModel loginViewModel, IAuthenticator authenticator, NavigationStore navigationStore)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _navigationStore = navigationStore;
        }
        
        
        public override async Task ExecuteAsync(object parameter)
        {
            bool isSuccessful = await _authenticator.Login(_loginViewModel.Username, _loginViewModel.Password);

            if (isSuccessful)
            {
                if (_authenticator.Account.Role == UserRole.User)
                {
                    MessageBox.Show("User Logged In.");
                }else if (_authenticator.Account.Role == UserRole.Admin)
                {
                    MessageBox.Show("Admin Logged In.");    
                    _navigationStore.CurrentViewModel = new AdminViewModel();
                }
            }
            else
            {
                MessageBox.Show("Incorrect Credentials.");
            }
        }
    }
}