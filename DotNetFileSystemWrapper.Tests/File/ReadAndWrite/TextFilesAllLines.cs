using System.Collections.Generic;
using Xunit;

namespace DotNetFileSystemWrapper.Tests.File.ReadAndWrite {
	public class TextFilesAllLinesTests : TestBase {
		[Fact]
		public void WriteAllLines() {
			_fs.File.WriteAllLines(Path("theFile.txt"), new List<string>{"first", "second"});
			var content = _fs.File.ReadAllText(Path("theFile.txt"));

			Assert.Equal($"first{System.Environment.NewLine}second{System.Environment.NewLine}", content);
		}

		[Fact]
		public void WriteAllLinesOverwritesExistingFile() {
			_fs.File.WriteAllLines(Path("theFile.txt"), new List<string>{"one", "two"});
			_fs.File.WriteAllLines(Path("theFile.txt"), new List<string>{"three", "four", "five"});
			var content = _fs.File.ReadAllText(Path("theFile.txt"));

			Assert.Equal($"three{System.Environment.NewLine}four{System.Environment.NewLine}five{System.Environment.NewLine}", content);
		}

		[Fact]
		public void AppendAllLinesToAnExistingFile() {
			_fs.File.WriteAllText(Path("theFile.txt"), "original");
			_fs.File.AppendAllLines(Path("theFile.txt"), new List<string>{"One", "Two"});
			var content = _fs.File.ReadAllText(Path("theFile.txt"));

			Assert.Equal($"originalOne{System.Environment.NewLine}Two{System.Environment.NewLine}", content);
		}

		[Fact]
		public void AppendAllLinesToAnNewFile() {
			_fs.File.AppendAllLines(Path("theFile.txt"), new List<string>{"one", "two"});
			var content = _fs.File.ReadAllText(Path("theFile.txt"));

			Assert.Equal($"one{System.Environment.NewLine}two{System.Environment.NewLine}", content);
		}
	}
}