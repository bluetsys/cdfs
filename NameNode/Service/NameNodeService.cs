﻿using log4net;
using NameNode.Interfaces;
using Protocols;
using System;
using System.Collections.Generic;

namespace NameNode.Service
{
    /// <summary>
    /// The main NameNode WCF service implementation
    /// 
    /// Limitation of WCF is that you can only have one service implementation class so this must
    /// implement both of the service interfaces.
    /// </summary>
    public class NameNodeService : IDataNodeProtocol, IClientProtocol
    {
        private readonly ILog _logger;
        private readonly IDataNodeProtocol _dataNodeProtocol;
        private readonly IClientProtocol _clientNodeProtocol;
        private readonly INameNodeStatus _nameNodeStatus;

        public NameNodeService(ILog logger, IDataNodeProtocol dataNodeProtocol, IClientProtocol clientNodeProtocol, INameNodeStatus nameNodeStatus)
        {
            _logger = logger;
            _dataNodeProtocol = dataNodeProtocol;
            _clientNodeProtocol = clientNodeProtocol;

            // Injection of NameNodeStatus forces the singleton to be created at this point recording the service startup time
            _nameNodeStatus = nameNodeStatus;
        }

        void IClientProtocol.Create(string filePath)
        {
            _clientNodeProtocol.Create(filePath);
        }

        void IClientProtocol.Delete(string filePath)
        {
            _clientNodeProtocol.Delete(filePath);
        }

        IList<CdfsFileStatus> IClientProtocol.GetListing(string filePath)
        {
            return _clientNodeProtocol.GetListing(filePath);
        }

        void IClientProtocol.ReadBlock()
        {
            _clientNodeProtocol.ReadBlock();
        }

        void IClientProtocol.WriteBlock()
        {
            _clientNodeProtocol.WriteBlock();
        }

        Guid IDataNodeProtocol.RegisterDataNode(DataNodeRegistration dataNodeRegistration)
        {
            return _dataNodeProtocol.RegisterDataNode(dataNodeRegistration);
        }

        void IDataNodeProtocol.SendHeartbeat(Guid dataNodeID)
        {
            _dataNodeProtocol.SendHeartbeat(dataNodeID);
        }
    }
}
