using Xunit;

namespace TestProjectXunit
{
    public class UnitTestData
    {
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
