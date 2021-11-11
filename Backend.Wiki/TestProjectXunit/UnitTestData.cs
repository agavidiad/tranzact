using System.IO;
using Xunit;

namespace TestProjectXunit
{
    public class UnitTestData
    {
        [Fact]
        public void ExistsCompressedFile()
        {
            Assert.True(File.Exists(@"..\..\..\..\Data\pageviews-20150501-010000.gz"));
        }
        [Fact]
        public void ExistsDecompressedFile()
        {
            Assert.True(File.Exists(@"..\..\..\..\Data\pageviews-20150501-010000"));
        }
        [Fact]
        public void WithData()
        {
            Assert.True(Wiki.Shared.Files.Functions.GetFileContent(@"..\..\..\..\Data\pageviews-20150501-010000", @"..\..\..\..\Data\").ToArray().Length > 0);
        }

        [Fact]
        public void WithoutData()
        {
            Assert.True(Wiki.Shared.Files.Functions.GetFileContent(@"..\..\..\..\Data\pageviews-20150501-010000", @"..\..\..\..\Data\").ToArray().Length == 0);
        }
    }
}
