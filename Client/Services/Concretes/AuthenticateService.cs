using System.Configuration;
using System.ServiceModel;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Contracts;
using DTO;

namespace Client.Services.Concretes
{
    public class AuthenticateService:IAuthenticateService
    {
        private readonly string _endpointAddress = ConfigurationManager.AppSettings["authenticationServerAddress"];

        public AuthenticateService() {}
        
        public async Task<AccountDto> Login(string username, string password)
        {
            AccountDto account = null;
            
            ChannelFactory<ILoginHandler> factory = new ChannelFactory<ILoginHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();
                
            account = await proxy.Login(username, password);

            return account;
        }
    }
}