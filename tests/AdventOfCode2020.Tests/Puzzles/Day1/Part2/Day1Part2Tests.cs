using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2020.Tests.Puzzles.Day1.Part2
{
    public class Day1Part2Tests : PuzzleTestBase
    {
        [Theory]
        [InlineData(new[] { 1721, 979, 366, 299, 675, 1456 }, "241861950")]
        public async Task GivenInputWithValidNumbers_ReturnsCorrectSolution(int[] input, string expected)
        {
            var inputProvider = GetInputProvider(input);
            var uut = new AdventOfCode2020.Puzzles.Day1.Part2.Puzzle(inputProvider);
            await uut.InitializeAsync();

            var actual = await uut.GetSolutionAsync();

            Assert.True(actual.HasValue);
            Assert.Equal(expected, actual.Value);
        }
    }
}
