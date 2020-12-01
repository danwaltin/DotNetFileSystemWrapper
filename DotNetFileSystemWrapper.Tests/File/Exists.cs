using Xunit;

namespace DotNetFileSystemWrapper.Tests.File {
	public class ExistsTests : TestBase {
		[Fact]
		public void NonExistingFileShouldReturnFalse() {
			var exists = _fs.File.Exists("filename_of_non_existing_file.txt");

			Assert.False(exists);
		}

		[Fact]
		public void ExistingFileShouldReturnTrue() {
			var path = Path("file_name.txt");
			_fs.File.WriteAllText(path, "content");
			var exists = _fs.File.Exists(path);

			Assert.True(exists);
		}
	}
}