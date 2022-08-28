using System.Threading.Tasks;
using DTO;

namespace Client.Services.Abstractions
{
    public interface IRegisterService
    {
        Task Register(string username, string password,string name,string lastName, bool isAdmin);
    }
}