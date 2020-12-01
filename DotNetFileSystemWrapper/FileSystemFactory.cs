using System;
using System.Collections.Generic;

namespace DotNetFileSystemWrapper {
	public class FileSystemFactory {
		public IFileSystem PhysicalFileSystem() =>
			new PhysicalFileSystem();
	}


	public interface IFileSystem {
		IDirectory Directory { get; }
		IFile File { get; }
	}

	public interface IDirectory {
		void CreateDirectory(string path);

		bool Exists(string path);
		
		void Delete(string path);
		void Delete(string path, bool recursive);
	}

	public interface IFile {
		bool Exists(string path);

		void Delete(string path);

		void WriteAllText(string path, string contents);
        void WriteAllLines(string path, IEnumerable<string> contents);
        void WriteAllBytes(string path, byte[] contents);

        void AppendAllText(string path, string contents);
        void AppendAllLines(string path, IEnumerable<string> contents);
		
        string ReadAllText(string path);
        string[] ReadAllLines(string path);
        byte[] ReadAllBytes(string path);
	}

	internal class PhysicalFileSystem : IFileSystem {
		public IDirectory Directory => new PhysicalDirectory();
		public IFile File => new PhysicalFile();

		private class PhysicalDirectory : IDirectory {
			public void CreateDirectory(string path) =>
				System.IO.Directory.CreateDirectory(path);

			public bool Exists(string path) =>
				System.IO.Directory.Exists(path);

			public void Delete(string path) =>
				System.IO.Directory.Delete(path);

			public void Delete(string path, bool recursive) =>
				System.IO.Directory.Delete(path, recursive);
		}

		private class PhysicalFile : IFile {
			public bool Exists(string path) =>
				System.IO.File.Exists(path);

			public void Delete(string path) =>
				System.IO.File.Delete(path);

			public void WriteAllText(string path, string contents) =>
				System.IO.File.WriteAllText(path, contents);

            public void WriteAllLines(string path, IEnumerable<string> contents) =>
                System.IO.File.WriteAllLines(path, contents);

            public void WriteAllBytes(string path, byte[] contents) =>
                System.IO.File.WriteAllBytes(path, contents);

			public void AppendAllText(string path, string contents) =>
				System.IO.File.AppendAllText(path, contents);

            public void AppendAllLines(string path, IEnumerable<string> contents) =>
                System.IO.File.AppendAllLines(path, contents);

			public string ReadAllText(string path) =>
				System.IO.File.ReadAllText(path);

			public string[] ReadAllLines(string path) =>
				System.IO.File.ReadAllLines(path);

			public byte[] ReadAllBytes(string path) =>
				System.IO.File.ReadAllBytes(path);
		}

	}
}
