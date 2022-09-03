using System.Threading.Tasks;
using System.Windows;
using Client.Services.Abstractions;
using Client.State.Resolver;
using Client.Stores;
using Client.ViewModels;
using Common.Enums;
using DTO;

namespace Client.State.Authentication
{
    public class Authenticator:IAuthenticator
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly INavigationService _navigationService;
        public AccountDto Account { get; private set; }
        public bool IsLoggedIn => Account != null;

        public bool IsAdmin => Account.Role == CommonEnumerations.UserRole.Admin;

        public Authenticator(IAuthenticateService authenticateService,INavigationService navigationService)
        {
            _authenticateService = authenticateService;
            _navigationService = navigationService;
        }
        
        public async Task Login(string username, string password)
        {
            var account = _authenticateService.Login(username, password);

            Account = await account;

            if (account.Result != null)
            {
                if (Account.Role == CommonEnumerations.UserRole.User)
                {
                    MessageBox.Show("User Logged In.");
                    _navigationService.NavigateToFestival();
                }else if (Account.Role == CommonEnumerations.UserRole.Admin)
                {
                    MessageBox.Show("Admin Logged In.");
                    _navigationService.NavigateToAdmin();
                }
            } else
            {
                MessageBox.Show("Incorrect Credentials.");
            }
        }

        public Task Logout()
        {
            Account = null;
            _navigationService.NavigateToLogin();
            return Task.CompletedTask;
        }
    }
}