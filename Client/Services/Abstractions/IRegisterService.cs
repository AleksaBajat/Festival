using DTO;

namespace Client.Services.Abstractions
{
    public interface IRegisterService
    {
        AccountDto Register(string username, string password,string name,string lastName, bool isAdmin);
    }
}