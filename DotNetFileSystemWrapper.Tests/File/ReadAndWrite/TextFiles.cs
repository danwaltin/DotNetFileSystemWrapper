using Xunit;
using System;
using DotNetFileSystemWrapper;

namespace DotNetFileSystemWrapper.Tests.File.ReadAndWrite
{
	public class TextFilesTests : IDisposable
	{
		private IFileSystem _fs;
		private string _rootPath;

		public TextFilesTests()
		{
			_rootPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "TestRoot", Guid.NewGuid().ToString());
            AssureRootPathExists();
			_fs = new FileSystemFactory().PhysicalFileSystem();
        }

		public void Dispose()
		{
			ClearRootPath();
		}

        private string RootPath()
		{
			return _rootPath;
		}

        private void AssureRootPathExists()
		{
			System.IO.Directory.CreateDirectory(RootPath());
		}

        private void ClearRootPath()
        {
            System.IO.Directory.Delete(RootPath(), recursive: true);
        }

        private string PathRelativeToRoot(string filename)
        {
            return System.IO.Path.Combine(RootPath(), filename);
        }

		[Fact]
		public void WriteAndReadTextContent()
		{
			_fs.File.WriteAllText(PathRelativeToRoot("theFile.txt"), "the file content");
			var content = _fs.File.ReadAllText(PathRelativeToRoot("theFile.txt"));

			Assert.True(true);
        }
    }
}