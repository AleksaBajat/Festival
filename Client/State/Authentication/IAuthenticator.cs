using System.Threading.Tasks;
using DTO;

namespace Client.State.Authentication
{
    public interface IAuthenticator
    {
        AccountDto Account { get; }
        bool IsLoggedIn { get; }

        Task<bool> Login(string username, string password);
        void Logout();
    }
}