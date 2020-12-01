using Xunit;

namespace DotNetFileSystemWrapper.Tests.File {
	public class AppendAllTextTests : TestBase {
		[Fact]
		public void AppendAllTextToANewFile() {
			_fs.File.WriteAllText(Path("existing.txt"), "original");

			_fs.File.AppendAllText(Path("new.txt"), "appended");

			var content = _fs.File.ReadAllText(Path("new.txt"));
			Assert.Equal("appended", content);
		}

		[Fact]
		public void AppendAllTextToAnExistingFile() {
			_fs.File.WriteAllText(Path("existing.txt"), "original");

			_fs.File.AppendAllText(Path("existing.txt"), "appended");

			var content = _fs.File.ReadAllText(Path("existing.txt"));
			Assert.Equal("originalappended", content);
		}

	}
}