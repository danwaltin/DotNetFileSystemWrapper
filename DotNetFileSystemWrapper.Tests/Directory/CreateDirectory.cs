using Xunit;

namespace DotNetFileSystemWrapper.Tests.Directory {
	public class CreateDirectoryTests : TestBase {
		[Fact]
		public void CreateDirectoryShouldCreate() {
			_fs.Directory.CreateDirectory(Path("directory_name"));

			AssertDirectoryExists(Path("directory_name"));
		}

		[Fact]
		public void CreateDirectoryShouldCreateIntermediateDirectories() {
			_fs.Directory.CreateDirectory(Path("parent", "child", "grand_child"));

			AssertDirectoryExists(Path("parent"));
			AssertDirectoryExists(Path("parent", "child"));
			AssertDirectoryExists(Path("parent", "child", "grand_child"));
		}

		private void AssertDirectoryExists(string path) {
			var exists = _fs.Directory.Exists(Path(path));
			Assert.True(exists);
		}
	}
}