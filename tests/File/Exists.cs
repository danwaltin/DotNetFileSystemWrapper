using Xunit;
using src;

namespace tests.File
{
    public class ExistsTests {
        [Fact]
        public void NonExistingFileShouldReturnFalse() {
            var fileSystem = new FileSystemFactory().PhysicalFileSystem();

            var exists = fileSystem.File.Exists("filename_of_non_existing_file.txt");

            Assert.False(exists);
        }
    }
}