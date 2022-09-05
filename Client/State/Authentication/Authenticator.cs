using System.Threading.Tasks;
using System.Windows;
using Client.Services.Abstractions;
using Common.Enums;
using DTO;

namespace Client.State.Authentication
{
    public class Authenticator:IAuthenticator
    {
        private readonly IAuthenticateService _authenticateService;
        public AccountDto Account { get; private set; }
        public bool IsLoggedIn => Account != null;

        public bool IsAdmin => Account.Role == CommonEnumerations.UserRole.Admin;

        public Authenticator(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
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
                }else if (Account.Role == CommonEnumerations.UserRole.Admin)
                {
                    MessageBox.Show("Admin Logged In.");
                }
            } else
            {
                MessageBox.Show("Incorrect Credentials.");
            }
        }

        public Task Logout()
        {
            Account = null;
            return Task.CompletedTask;
        }
    }
}