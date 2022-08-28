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
        private NavigationStore _navigationStore;
        public AccountDto Account { get; private set; }
        public bool IsLoggedIn => Account != null;

        public Authenticator(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        
        public async Task Login(string username, string password)
        {
            _navigationStore = DependencyResolver.Resolve<NavigationStore>();
            var account = _authenticateService.Login(username, password);

            if (account != null)
            {
                Account = await account;
                
                if (Account.Role == CommonEnumerations.UserRole.User)
                {
                    MessageBox.Show("User Logged In.");
                }else if (Account.Role == CommonEnumerations.UserRole.Admin)
                {
                    MessageBox.Show("Admin Logged In.");    
                    _navigationStore.CurrentViewModel = new AdminViewModel();
                }
            } else
            {
                MessageBox.Show("Incorrect Credentials.");
            }
        }

        public Task Logout()
        {
            Account = null;
            _navigationStore.CurrentViewModel = new LoginViewModel();
            
            return Task.CompletedTask;
        }
    }
}