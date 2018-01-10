﻿using NameNode.FileSystem;
using NameNode.FileSystem.Interfaces;
using NameNode.Services;
using NameNode.Status;
using Protocols;
using StructureMap;

namespace NameNode.IoC
{
    public class NameNodeRegistry : Registry
    {
        public NameNodeRegistry()
        {
            For<INameNodeStatus>().Use<NameNodeStatus>().Singleton();
            For<IDataNodesStatus>().Use<DataNodesStatus>();

            For<IClientProtocol>().Use<ClientProtocol>();
            For<IDataNodeProtocol>().Use<DataNodeProtocol>();

            For<IDataNodeRepository>().Use<DataNodeRepository>().Singleton();
            For<IDateTimeProvider>().Use<DateTimeProvider>();

            For<IFileSystemImageFile>().Use<FileSystemImageFile>().Ctor<string>("imageFileName").Is("FSImage").Singleton();

            For<IFileSystem>().Use<FileSystem.FileSystem>().Singleton();
            For<IFileSystemSerializer>().Use<FileSystemSerializer>();
            For<IFileSystemReaderWriter>().Use<FileSystemReaderWriter>();

            For<INodeWalker>().Use<NodeWalker>();
        }
    }
}