﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Server
{
    public class StageServer
    {
        private readonly ServiceHost _host;
        private readonly string _address = ConfigurationManager.AppSettings["stageServerAddress"];

        public StageServer()
        {
            _host = new ServiceHost(typeof(StageHandler));
            NetTcpBinding binding = new NetTcpBinding();
            _host.AddServiceEndpoint(typeof(IStageHandler), binding, _address);
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
