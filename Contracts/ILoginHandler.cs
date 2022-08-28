using System.ServiceModel;
using System.Threading.Tasks;
using DTO;

namespace Contracts
{
    [ServiceContract]
    public interface ILoginHandler
    {
        [OperationContract]
        Task<AccountDto> Login(string username, string password);
    }
}