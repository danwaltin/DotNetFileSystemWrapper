using Xunit;

namespace DotNetFileSystemWrapper.Tests.Directory {
	public class ExistsTests : TestBase {
		[Fact]
		public void NonExistingDirectoryShouldReturnFalse() {
			var exists = _fs.Directory.Exists(Path("filename_of_non_existing_directory"));

			Assert.False(exists);
		}


		[Fact]
		public void ExistingDirectoryShouldReturnTrue() {
			CreateDirectory(Path("directory_name"));

			var exists = _fs.Directory.Exists(Path("directory_name"));

			Assert.True(exists);
		}

		[Fact]
		public void ExistingFileShouldReturnFalse() {
			CreateFile(Path("filename"));

			var exists = _fs.Directory.Exists(Path("filename"));

			Assert.False(exists);
		}
	}
}