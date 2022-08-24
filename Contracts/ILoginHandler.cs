using System.ServiceModel;
using DTO;

namespace Contracts
{
    [ServiceContract]
    public interface ILoginHandler
    {
        [OperationContract]
        AccountDto Login(string username, string password);
    }
}