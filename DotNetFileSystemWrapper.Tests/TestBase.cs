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

		/// <summary>
		/// Create a path relative to a root path
		/// </summary>
		protected string Path(string filename) =>
			System.IO.Path.Combine(RootPath(), filename);

		protected string Path(string folder, string filename) =>
			System.IO.Path.Combine(RootPath(), folder, filename);
	}
}
