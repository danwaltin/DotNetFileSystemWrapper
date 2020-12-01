using Xunit;

namespace DotNetFileSystemWrapper.Tests.File.ReadAndWrite {
	public class TextFilesAllTextTests : TestBase {
		[Fact]
		public void WriteAndReadTextContent() {
			_fs.File.WriteAllText(Path("theFile.txt"), "the file content");
			var content = _fs.File.ReadAllText(Path("theFile.txt"));

			Assert.Equal("the file content", content);
		}

		[Fact]
		public void WriteAllTextOverwritesExistingFile() {
			_fs.File.WriteAllText(Path("theFile.txt"), "original content");
			_fs.File.WriteAllText(Path("theFile.txt"), "new content");
			var content = _fs.File.ReadAllText(Path("theFile.txt"));

			Assert.Equal("new content", content);
		}

		[Fact]
		public void AppendAllTextToAnExistingFile() {
			_fs.File.WriteAllText(Path("existing.txt"), "original");
			_fs.File.AppendAllText(Path("existing.txt"), "appended");
			var content = _fs.File.ReadAllText(Path("existing.txt"));

			Assert.Equal("originalappended", content);
		}

		[Fact]
		public void AppendAllTextToANewFile() {
			_fs.File.WriteAllText(Path("existing.txt"), "original");
			_fs.File.AppendAllText(Path("new.txt"), "appended");
			var content = _fs.File.ReadAllText(Path("new.txt"));

			Assert.Equal("appended", content);
		}
	}
}