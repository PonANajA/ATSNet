using ASTNet.Services;

namespace ASTNet.Tests
{
    public class RankServiceTests
    {
        [Fact]
        public void ProcessRankSortedCorrectly()
        {
            var service = new RankService();
            var input = "A,B,1,2,1,AA,3,5,BB,4,2,4,AA,B";

            var result = service.ProcessRank(input);

            Assert.NotNull(result);
            Assert.Equal(5, result.Count);

            Assert.Equal("AA", result[0].rank);
            Assert.Equal("B", result[1].rank);
            Assert.Equal("1", result[2].rank);
            Assert.Equal("2", result[3].rank);
            Assert.Equal("4", result[4].rank);
        }
    }
}
