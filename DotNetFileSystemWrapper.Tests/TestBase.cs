using System;

namespace DotNetFileSystemWrapper.Tests {
	public class TestBase : IDisposable {
		protected IFileSystem _fs;
		private string _rootPath;

		public TestBase() {
			_rootPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "TestRoot", Guid.NewGuid().ToString());
			AssureRootPathExists();
			_fs = new FileSystemFactory().PhysicalFileSystem();
		}

		public void Dispose() =>
			ClearRootPath();

		private string RootPath() =>
			_rootPath;

		private void AssureRootPathExists() =>
			System.IO.Directory.CreateDirectory(RootPath());

		private void ClearRootPath() =>
			System.IO.Directory.Delete(RootPath(), recursive: true);

		protected void CreateDirectory(string path) =>
			_fs.Directory.CreateDirectory(path);

		protected void CreateFile(string path) => 
			_fs.File.WriteAllText(path, "content");

		/// <summary>
		/// Create a path relative to a root path
		/// </summary>
		protected string Path(string p) =>
			System.IO.Path.Combine(RootPath(), p);

		protected string Path(string p1, string p2) =>
			System.IO.Path.Combine(RootPath(), p1, p2);

		protected string Path(string p1, string p2, string p3) =>
			System.IO.Path.Combine(RootPath(), p1, p2, p3);
	}
}
