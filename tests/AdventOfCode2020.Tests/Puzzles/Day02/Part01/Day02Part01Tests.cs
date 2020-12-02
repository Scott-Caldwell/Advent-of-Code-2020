using System.Threading.Tasks;
using AdventOfCode2020.Puzzles.Day02;
using Xunit;

namespace AdventOfCode2020.Tests.Puzzles.Day02.Part01
{
    public class Day02Part01Tests : PuzzleTestBase
    {
        [Theory]
        [InlineData(new[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" }, "2")]
        public async Task GivenValidInput_ReturnsCorrectSolution(string[] input, string expected)
        {
            var parser = new PasswordDataParser();
            var inputProvider = GetParsingInputProvider(input, str => parser.Parse(str));
            var uut = new AdventOfCode2020.Puzzles.Day02.Part01.Puzzle(inputProvider);
            await uut.InitializeAsync();

            var actual = await uut.GetSolutionAsync();

            Assert.True(actual.HasValue);
            Assert.Equal(expected, actual.Value);
        }
    }
}
