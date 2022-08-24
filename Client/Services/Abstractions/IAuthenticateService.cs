using System.Threading.Tasks;
using DTO;

namespace Client.Services.Abstractions
{
    public interface IAuthenticateService
    {
        Task<AccountDto> Login(string username, string password);
    }
}