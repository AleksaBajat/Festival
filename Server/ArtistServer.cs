using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Server
{
    internal class ArtistServer
    {
        private readonly ServiceHost _host;
        private readonly string _address = ConfigurationManager.AppSettings["stageServerAddress"];

        public ArtistServer()
        {
            _host = new ServiceHost(typeof(ArtistHandler));
            NetTcpBinding binding = new NetTcpBinding();
            _host.AddServiceEndpoint(typeof(IArtistHandler), binding, _address);
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
