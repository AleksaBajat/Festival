using System.Threading.Tasks;
using Client.Services.Abstractions;
using DTO;

namespace Client.State.Authentication
{
    public class Authenticator:IAuthenticator
    {
        private readonly IAuthenticateService _authenticateService;
        public AccountDto Account { get; private set; }
        public bool IsLoggedIn => Account != null;

        public Authenticator(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        
        public async Task<bool> Login(string username, string password)
        {
            var account = _authenticateService.Login(username, password);

            if (account != null)
            {
                Account = await account;
                return true;
            }

            return false;
        }

        public void Logout()
        {
            Account = null;
        }
    }
}