using System.Configuration;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using Client.Services.Abstractions;
using Client.State.Authentication;
using Contracts;
using DTO;

namespace Client.Services.Concretes
{
    public class RegisterService:IRegisterService
    {
        private readonly string _endpointAddress = ConfigurationManager.AppSettings["authenticationServerAddress"];
        public RegisterService()
        {
        }
        
        public async Task Register(string username, string password, string name, string lastName, bool isAdmin)
        {
            bool isSuccessful = false;
            
            ChannelFactory<IRegisterHandler> factory = new ChannelFactory<IRegisterHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();
                
            isSuccessful = await proxy.Register(username, password,name,lastName,isAdmin);

            if (isSuccessful)
            {
                MessageBox.Show("Registration successful!");
            }
            else
            {
                MessageBox.Show("Registration unsuccessful!");
            }
            
        }
    }
}