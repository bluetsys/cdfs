﻿using NameNode.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameNode.Interfaces
{
    public interface IDataNodeRepository
    {
        Guid AddDataNode(DataNodeDescriptor descriptor);
        DataNodeDescriptor GetDataNodeDescriptorById(Guid dataNodeId);

        bool IsDataNodeDead(DataNodeDescriptor dn);
        int LiveNodes { get; }
        int DeadNodes { get; }
    }
}