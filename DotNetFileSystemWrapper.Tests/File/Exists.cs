using Xunit;

namespace DotNetFileSystemWrapper.Tests.File {
	public class ExistsTests : TestBase {
		[Fact]
		public void NonExistingFileShouldReturnFalse() {
			var exists = _fs.File.Exists(Path("filename_of_non_existing_file.txt"));

			Assert.False(exists);
		}

		[Fact]
		public void ExistingFileShouldReturnTrue() {
			CreateFile(Path("file_name.txt"));

			var exists = _fs.File.Exists(Path("file_name.txt"));

			Assert.True(exists);
		}

		[Fact]
		public void ExistingDirectoryShouldReturnFalse() {
			CreateDirectory(Path("directory_name"));

			var exists = _fs.File.Exists(Path("directory_name"));

			Assert.False(exists);
		}
	}
}