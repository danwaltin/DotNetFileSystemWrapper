using Xunit;

namespace DotNetFileSystemWrapper.Tests.File.ReadAndWrite {
	public class ReadAllLinesTests : TestBase {
		[Fact]
		public void ReadAllLinesFromAnEmptyFile() {
			_fs.File.WriteAllText(Path("theFile.txt"), "");

			var content = _fs.File.ReadAllText(Path("theFile.txt"));

			Assert.Equal(0, content.Length);
		}

		[Fact]
		public void ReadAllLinesFromAFileWithTwoEmptyLines() {
			_fs.File.WriteAllText(Path("theFile.txt"), $"{System.Environment.NewLine}");

			var content = _fs.File.ReadAllLines(Path("theFile.txt"));
			Assert.Equal(1, content.Length);
			Assert.Equal("", content[0]);
		}

		[Fact]
		public void ReadAllLinesFromAFileWithOneLine() {
			_fs.File.WriteAllText(Path("theFile.txt"), "the text");

			var content = _fs.File.ReadAllLines(Path("theFile.txt"));
			Assert.Equal(1, content.Length);
			Assert.Equal("the text", content[0]);
		}

		[Fact]
		public void ReadAllLinesFromFileWithTwoLinesWithoutEndingNewLine() {
			_fs.File.WriteAllText(Path("theFile.txt"), $"first{System.Environment.NewLine}second");

			var content = _fs.File.ReadAllLines(Path("theFile.txt"));
			Assert.Equal(2, content.Length);
			Assert.Equal("first", content[0]);
			Assert.Equal("second", content[1]);
		}

		[Fact]
		public void ReadAllLinesFromFileWithThreeLinesWithEndingNewLine() {
			_fs.File.WriteAllText(Path("theFile.txt"), $"first{System.Environment.NewLine}second{System.Environment.NewLine}third{System.Environment.NewLine}");

			var content = _fs.File.ReadAllLines(Path("theFile.txt"));
			Assert.Equal(3, content.Length);
			Assert.Equal("first", content[0]);
			Assert.Equal("second", content[1]);
			Assert.Equal("third", content[2]);
		}

		[Fact]
		public void ReadAllLinesFromFileWithSeveralNewLinesInRow() {
			_fs.File.WriteAllText(Path("theFile.txt"), $"first{System.Environment.NewLine}{System.Environment.NewLine}second{System.Environment.NewLine}{System.Environment.NewLine}");

			var content = _fs.File.ReadAllLines(Path("theFile.txt"));
			Assert.Equal(4, content.Length);
			Assert.Equal("first", content[0]);
			Assert.Equal("", content[1]);
			Assert.Equal("second", content[2]);
			Assert.Equal("", content[3]);
		}
	}
}