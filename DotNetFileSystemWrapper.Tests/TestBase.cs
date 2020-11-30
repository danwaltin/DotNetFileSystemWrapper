using System;

namespace DotNetFileSystemWrapper.Tests
{
	public class TestBase : IDisposable
	{
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

        protected string PathRelativeToRoot(string filename) => 
			System.IO.Path.Combine(RootPath(), filename);
    }
}
