using Xunit;

namespace DotNetFileSystemWrapper.Tests.File {
	public class DeleteTests : TestBase {
		[Fact]
		public void DeletedFileDoesNotExist() {
			CreateFile(Path("filename.txt"));

			_fs.File.Delete(Path("filename.txt"));

			AssertFileDoesNotExist(Path("filename.txt"));
		}

		[Fact]
		public void DeleteFileWithSameNameAsAnotherInADifferentFolder() {
			CreateDirectory(Path("folder_one"));
			CreateDirectory(Path("folder_two"));
			CreateFile(Path("folder_one", "name.txt"));
			CreateFile(Path("folder_two", "name.txt"));

			_fs.File.Delete(Path("folder_two", "name.txt"));

			AssertFileExist(Path("folder_one", "name.txt"));
			AssertFileDoesNotExist(Path("folder_two", "name.txt"));
		}

		private void AssertFileDoesNotExist(string path) {
			Assert.False(_fs.File.Exists(path));
		}

		private void AssertFileExist(string path) {
			Assert.True(_fs.File.Exists(path));
		}
	}
}