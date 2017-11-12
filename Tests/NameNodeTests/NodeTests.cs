﻿using NameNode.FileSystem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameNodeTests
{
    [TestFixture]
    class NodeTests
    {
        [Test]
        public void IsRoot_WithNoParent_ReturnsTrue()
        {
            // Arrange
            var nodeDirectory = new Node();

            // Act
            var isRoot = nodeDirectory.IsRoot;

            // Assert
            Assert.IsTrue(isRoot);
        }

        [Test]
        public void IsRoot_WithParent_ReturnsFalse()
        {
            // Arrange
            var nodeDirectory = new Node() { Parent = new Node() };

            // Act
            var isRoot = nodeDirectory.IsRoot;

            // Assert
            Assert.IsFalse(isRoot);
        }

        [Test]
        public void FullPath_WithNoParent_ReturnsNodeName()
        {
            // Arrange
            var node = new Node() { Name = "NodeName" };

            // Act
            var fullPath = node.FullPath;

            // Assert
            Assert.AreEqual("NodeName", fullPath);
        }

        [Test]
        public void FullPath_WithParent_ReturnsParentPathCombinedWithNodeName()
        {
            // Arrange
            var node = new Node() { Name = "NodeName", Parent = new Node() { Name = "ParentPath" } };

            // Act
            var fullPath = node.FullPath;

            // Assert
            Assert.AreEqual("ParentPath\\NodeName", fullPath);
        }
    }
}