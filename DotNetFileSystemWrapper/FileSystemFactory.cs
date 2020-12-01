using System;
using System.Collections.Generic;

namespace DotNetFileSystemWrapper {
	public class FileSystemFactory {
		public IFileSystem PhysicalFileSystem() =>
			new PhysicalFileSystem();
	}


	public interface IFileSystem {
		IFile File { get; }
	}

	public interface IFile {
		bool Exists(string path);

		void WriteAllText(string path, string contents);
        void WriteAllLines(string path, IEnumerable<string> contents);
        
        void AppendAllText(string path, string contents);
        void AppendAllLines(string path, IEnumerable<string> contents);
		
        string ReadAllText(string path);
        string[] ReadAllLines(string path);
	}

	internal class PhysicalFileSystem : IFileSystem {
		private class PhysicalFile : IFile {
			public bool Exists(string path) =>
				System.IO.File.Exists(path);

			public void WriteAllText(string path, string contents) =>
				System.IO.File.WriteAllText(path, contents);

            public void WriteAllLines(string path, IEnumerable<string> contents) =>
                System.IO.File.WriteAllLines(path, contents);

			public void AppendAllText(string path, string contents) =>
				System.IO.File.AppendAllText(path, contents);

            public void AppendAllLines(string path, IEnumerable<string> contents) =>
                System.IO.File.AppendAllLines(path, contents);

			public string ReadAllText(string path) =>
				System.IO.File.ReadAllText(path);

			public string[] ReadAllLines(string path) =>
				System.IO.File.ReadAllLines(path);
		}

		public IFile File => new PhysicalFile();
	}
}
