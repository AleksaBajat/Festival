using System.Configuration;
using System.ServiceModel;
using Contracts;

namespace Server
{
    public class RegistrationServer
    {
        private readonly ServiceHost _host;
        private readonly string _address = ConfigurationManager.AppSettings["registrationServerAddress"];

        public RegistrationServer()
        {
            _host = new ServiceHost(typeof(RegisterHandler));
            NetTcpBinding binding = new NetTcpBinding();
            _host.AddServiceEndpoint(typeof(IRegisterHandler), binding, _address);
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