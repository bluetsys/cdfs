﻿using System.IO;

namespace NameNode.FileSystem
{
    public static class FileSystemPath
    {
        public static string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }

        public static string[] GetComponents(string path)
        {
            return Normalize(path).Split(Path.DirectorySeparatorChar);
        }

        public static string Normalize(string path)
        {
            return path.TrimStart(Path.DirectorySeparatorChar);
        }

        public static string Combine(string path1, string path2)
        {
            return path1 == null ? null : Path.Combine(path1, path2);
        }

        public static string GetFullPath(string path)
        {
            var fullPath = Path.DirectorySeparatorChar.ToString();

            if (!string.IsNullOrEmpty(path))
            {
                if (!path.StartsWith(Path.DirectorySeparatorChar))
                {
                    fullPath += path;
                }
                else
                {
                    fullPath = path;
                }
            }

            return fullPath;
        }
    }
}
