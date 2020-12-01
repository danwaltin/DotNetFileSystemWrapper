using System;

namespace DotNetFileSystemWrapper
{
	public class FileSystemFactory {
		public IFileSystem PhysicalFileSystem() =>
			new PhysicalFileSystem();
	}


	public interface IFileSystem  {
		IFile File {get;}
	}

	public interface IFile {
		bool Exists(string path);
		void WriteAllText(string path, string contents);
		void AppendAllText(string path, string contents);
		string ReadAllText(string path);
	}

	internal class PhysicalFileSystem : IFileSystem
	{
		private class PhysicalFile : IFile
		{
            public bool Exists(string path) =>
				System.IO.File.Exists(path);

            public void WriteAllText(string path, string contents) => 
				System.IO.File.WriteAllText(path, contents);

            public void AppendAllText(string path, string contents) => 
				System.IO.File.AppendAllText(path, contents);

            public string ReadAllText(string path) =>
				System.IO.File.ReadAllText(path);
        }
		
		public IFile File => new PhysicalFile();
	}
}
