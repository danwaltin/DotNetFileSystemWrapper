using System.Collections.Generic;
using Xunit;

namespace DotNetFileSystemWrapper.Tests.File.ReadAndWrite {
	public class AppendAllLinesTests : TestBase {
		[Fact]
		public void AppendAllLinesToAnNewFile() {
			_fs.File.AppendAllLines(Path("theFile.txt"), new List<string>{"one", "two"});

			var content = _fs.File.ReadAllText(Path("theFile.txt"));
			Assert.Equal($"one{System.Environment.NewLine}two{System.Environment.NewLine}", content);
		}

		[Fact]
		public void AppendAllLinesToAnExistingFile() {
			_fs.File.WriteAllText(Path("theFile.txt"), "original");

			_fs.File.AppendAllLines(Path("theFile.txt"), new List<string>{"One", "Two"});

			var content = _fs.File.ReadAllText(Path("theFile.txt"));
			Assert.Equal($"originalOne{System.Environment.NewLine}Two{System.Environment.NewLine}", content);
		}
	}
}