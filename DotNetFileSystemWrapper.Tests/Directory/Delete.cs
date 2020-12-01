using Xunit;

namespace DotNetFileSystemWrapper.Tests.Directory {
	public class DeleteTests : TestBase {
		[Fact]
		public void DeletingAnEmptyDirectoryRemovesTheDirectory() {
			CreateDirectory(Path("parent", "child"));
			
			_fs.Directory.Delete(Path("parent", "child"));

			AssertDirectoryDoesNotExist(Path("parent", "child"));
			AssertDirectoryExists(Path("parent"));
		}

		[Fact]
		public void DeletingRecursivelyRemovesChildren() {
			CreateDirectory(Path("parent", "child"));
			CreateFile(Path("parent", "parent_file.txt"));
			CreateFile(Path("parent", "child", "child_file.txt"));

			_fs.Directory.Delete(Path("parent"), recursive: true);

			AssertDirectoryDoesNotExist(Path("parent"));
			AssertDirectoryDoesNotExist(Path("parent", "child"));
			AssertFileDoesNotExist(Path("parent", "parent_file.txt"));
			AssertFileDoesNotExist(Path("parent", "child", "child_file.txt"));
		}

		private void AssertDirectoryExists(string path) {
			var exists = _fs.Directory.Exists(Path(path));
			Assert.True(exists);
		}

		private void AssertDirectoryDoesNotExist(string path) {
			var exists = _fs.Directory.Exists(Path(path));
			Assert.False(exists);
		}

		private void AssertFileDoesNotExist(string path) {
			var exists = _fs.File.Exists(Path(path));
			Assert.False(exists);
		}
	}
}