using System.ServiceModel;
using System.ServiceModel.PeerResolvers;
using System.Threading.Tasks;
using DTO;

namespace Contracts
{
    [ServiceContract]
    public interface IRegisterHandler
    {
        [OperationContract]
        Task<bool> Register(string username,string password, string name, string lastName, bool isAdmin);
    }
}