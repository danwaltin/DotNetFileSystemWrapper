using Xunit;
using DotNetFileSystemWrapper;

namespace DotNetFileSystemWrapper.Tests.File
{
    public class ExistsTests {
        private string RootPath() {
            
            return "/Users/dan/";
        }

        private string PathRelativeToRoot(string filename) {
            return System.IO.Path.Combine(RootPath(), filename);
        }

        [Fact]
        public void NonExistingFileShouldReturnFalse() {
            var fileSystem = new FileSystemFactory().PhysicalFileSystem();

            var exists = fileSystem.File.Exists("filename_of_non_existing_file.txt");

            Assert.False(exists);
        }

        [Fact]
        public void ExistingFileShouldReturnTrue() {
            var fileSystem = new FileSystemFactory().PhysicalFileSystem();

            var path = PathRelativeToRoot("file_name.txt");
            fileSystem.File.WriteAllText(path, "content");
            var exists = fileSystem.File.Exists(path);

            Assert.True(exists);
        }
    }
}