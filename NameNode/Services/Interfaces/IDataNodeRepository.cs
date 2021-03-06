﻿using Protocols;
using System;

namespace NameNode.Services.Interfaces
{
    public interface IDataNodeRepository
    {
        Guid AddDataNode(IDataNodeId descriptor);
        IDataNodeId GetDataNodeDescriptorById(Guid dataNodeGuid);
        Guid GetRandomDataNodeId();

        void SetLastUpdateTicks(Guid dataNodeGuid, long lastUpdateTicks);

        int LiveNodes { get; }
        int DeadNodes { get; }
    }
}
