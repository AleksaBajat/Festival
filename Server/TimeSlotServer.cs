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
    internal class TimeSlotServer
    {
        private readonly ServiceHost _host;
        private readonly string _address = ConfigurationManager.AppSettings["timeSlotServerAddress"];

        public TimeSlotServer()
        {
            _host = new ServiceHost(typeof(TimeSlotHandler));
            NetTcpBinding binding = new NetTcpBinding();
            _host.AddServiceEndpoint(typeof(ITimeSlotHandler), binding, _address);
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
