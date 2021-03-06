﻿using NameNode.FileSystem.Interfaces;

namespace NameNode.FileSystem
{
    public class NodeWalker : INodeWalker
    {
        public INode GetNodeByPath(INode root, string path, bool stopAtLastExistingNode = false)
        {
            INode currentNode = root;

            if (!string.IsNullOrEmpty(path))
            {
                var pathComponents = FileSystemPath.GetComponents(path);

                foreach (var pathComponent in pathComponents)
                {
                    if (!string.IsNullOrEmpty(pathComponent) && currentNode != null && currentNode is IDirectory)
                    {
                        var childNode = (currentNode as IDirectory).GetChild(pathComponent);
                        currentNode = childNode ?? (stopAtLastExistingNode ? currentNode : null);
                    }
                }
            }
            return currentNode;
        }
    }
}
