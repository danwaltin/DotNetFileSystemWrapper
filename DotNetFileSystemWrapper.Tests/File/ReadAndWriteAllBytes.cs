using Xunit;

namespace DotNetFileSystemWrapper.Tests.File {
	public class WriteAllBytesTests : TestBase {
		[Fact]
		public void WriteAllBytesToANewFile() {
			_fs.File.WriteAllBytes(Path("theFile.txt"), new byte[]{0x11, 0x22, 0x33});

			var content = _fs.File.ReadAllBytes(Path("theFile.txt"));
			Assert.Equal(new byte[]{0x11, 0x22, 0x33}, content);
		}

		[Fact]
		public void WriteAllBytesOverwritesAnExistingFile() {
			_fs.File.WriteAllBytes(Path("theFile.txt"), new byte[]{0x11, 0x11});

			_fs.File.WriteAllBytes(Path("theFile.txt"), new byte[]{0x22, 0x22});

			var content = _fs.File.ReadAllBytes(Path("theFile.txt"));
			Assert.Equal(new byte[]{0x22, 0x22}, content);
		}
	}
}