using Xunit;

namespace DotNetFileSystemWrapper.Tests.File.ReadAndWrite
{
	public class TextFilesTests : TestBase
	{
		[Fact]
		public void WriteAndReadTextContent()
		{
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
    }
}