using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace DotNetFileSystemWrapper.Tests.Directory {
	public class EnumerateDirectoriesTests : TestBase {
		[Fact]
		public void EnumerateEmptyDirectory() {
			CreateDirectories(
				Path("directory_name"));

			var result = _fs.Directory.EnumerateDirectories(Path("directory_name"));

			Assert.Empty(result);
		}

		[Fact]
		public void EnumerateDirectoryWithOneChild() {
			CreateDirectories(
				Path("parent"),
				Path("parent", "child"));

			var result = _fs.Directory.EnumerateDirectories(Path("parent"));

			AssertEnumerableUnordered(result,
				Path("parent", "child"));
		}

		[Fact]
		public void EnumerateDirectoryWithThreeChildren() {
			CreateDirectories(
				Path("parent"),
				Path("parent", "child B"),
				Path("parent", "child A"),
				Path("parent", "child C"));

			var result = _fs.Directory.EnumerateDirectories(Path("parent"));

			AssertEnumerableUnordered(result,
				Path("parent", "child A"),
				Path("parent", "child B"),
				Path("parent", "child C"));
		}

		private void CreateDirectories(params string[] paths) {
			foreach (var p in paths)
				CreateDirectory(p);
		}

		private void AssertEnumerableUnordered(IEnumerable<string> actual, params string[] expected) {
			Assert.Equal(expected.Length, actual.Count());
			
			foreach(var e in expected)
				Assert.True(actual.Any(a => a == e));
		}
	}
}