using System.Threading.Tasks;
using DTO;

namespace Client.State.Authentication
{
    public interface IAuthenticator
    {
        AccountDto Account { get; }
        bool IsLoggedIn { get; }

        bool IsAdmin { get; }

        Task Login(string username, string password);
        Task Logout();
    }
}