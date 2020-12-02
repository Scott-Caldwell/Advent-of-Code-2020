using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2020.Tests.Puzzles.Day01.Part01
{
    public class Day01Part01Tests : PuzzleTestBase
    {
        [Theory]
        [InlineData(new[] { 1721, 979, 366, 299, 675, 1456 }, "514579")]
        public async Task GivenInputWithValidNumbers_ReturnsCorrectSolution(int[] input, string expected)
        {
            var inputProvider = GetInputProvider(input);
            var uut = new AdventOfCode2020.Puzzles.Day01.Part01.Puzzle(inputProvider);
            await uut.InitializeAsync();

            var actual = await uut.GetSolutionAsync();

            Assert.True(actual.HasValue);
            Assert.Equal(expected, actual.Value);
        }
    }
}
