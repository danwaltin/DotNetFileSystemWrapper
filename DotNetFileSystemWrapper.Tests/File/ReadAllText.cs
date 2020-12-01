using Xunit;

namespace DotNetFileSystemWrapper.Tests.File.ReadAndWrite {
	public class ReadAllTextTests : TestBase {
		[Fact]
		public void ReadAllTextFromAnEmptyFile() {
			_fs.File.WriteAllText(Path("theFile.txt"), "");

			var content = _fs.File.ReadAllText(Path("theFile.txt"));
			Assert.Equal("", content);
		}

		[Fact]
		public void ReadAllTextFromAFileWithLeadingAndTrailingSpace() {
			_fs.File.WriteAllText(Path("theFile.txt"), " the text ");

			var content = _fs.File.ReadAllText(Path("theFile.txt"));
			Assert.Equal(" the text ", content);
		}

		[Fact]
		public void ReadAllTextFromMultiLineFile() {
			_fs.File.WriteAllText(Path("theFile.txt"), $"file{System.Environment.NewLine}content");

			var content = _fs.File.ReadAllText(Path("theFile.txt"));
			Assert.Equal($"file{System.Environment.NewLine}content", content);
		}
	}
}