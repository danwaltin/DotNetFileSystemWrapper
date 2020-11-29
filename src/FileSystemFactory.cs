using System;

namespace src
{
    public interface IFileSystem {
        IFile File {get;}
    }

    public interface IFile {
        bool Exists(string path);
    }

    public class FileSystemFactory
    {
        public IFileSystem PhysicalFileSystem() =>
            new PhysicalFileSystem();
    }

    internal class PhysicalFileSystem : IFileSystem
    {
        private class PhysicalFile : IFile
        {
            public bool Exists(string path)
            {
                return false;
            }
        }
        public IFile File => new PhysicalFile();
    }
}
