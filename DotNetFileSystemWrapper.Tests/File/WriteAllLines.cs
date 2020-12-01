using System.Collections.Generic;
using Xunit;

namespace DotNetFileSystemWrapper.Tests.File {
	public class WriteAllLinesTests : TestBase {
		[Fact]
		public void WriteAllLinesToANewFile() {
			_fs.File.WriteAllLines(Path("theFile.txt"), new List<string>{"first", "second"});
			
			var content = _fs.File.ReadAllText(Path("theFile.txt"));
			Assert.Equal($"first{System.Environment.NewLine}second{System.Environment.NewLine}", content);
		}

		[Fact]
		public void WriteAllLinesOverwritesToAnExistingFile() {
			_fs.File.WriteAllLines(Path("theFile.txt"), new List<string>{"one", "two"});

			_fs.File.WriteAllLines(Path("theFile.txt"), new List<string>{"three", "four", "five"});

			var content = _fs.File.ReadAllText(Path("theFile.txt"));
			Assert.Equal($"three{System.Environment.NewLine}four{System.Environment.NewLine}five{System.Environment.NewLine}", content);
		}
	}
}