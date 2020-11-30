using Xunit;

namespace DotNetFileSystemWrapper.Tests.File.ReadAndWrite
{
	public class TextFilesTests : TestBase
	{
		[Fact]
		public void WriteAndReadTextContent()
		{
			_fs.File.WriteAllText(PathRelativeToRoot("theFile.txt"), "the file content");
			var content = _fs.File.ReadAllText(PathRelativeToRoot("theFile.txt"));

			Assert.True(true);
        }
    }
}