using System.Configuration;
using System.Data.Entity;
using System.ServiceModel;
using Contracts;

namespace Server
{
    public class AuthenticationServer
    {
        private readonly ServiceHost _host;
        private readonly string _address = ConfigurationManager.AppSettings["authenticationServerAddress"];

        public AuthenticationServer()
        {
            _host = new ServiceHost(typeof(LoginHandler));
            NetTcpBinding binding = new NetTcpBinding();
            _host.AddServiceEndpoint(typeof(ILoginHandler), binding, _address);
        }

        public void Open()
        {
            _host.Open();
        }

        public void Close()
        {
            _host.Close();
        }

    }
}