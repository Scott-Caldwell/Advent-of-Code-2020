using System;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2020.Tests.Puzzles.Day03.Part01
{
    public class Day03Part01Tests : PuzzleTestBase
    {
        [Theory]
        [InlineData(
@"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#",
            "7")]
        public async Task GivenValidInput_ReturnsCorrectSolution(string input, string expected)
        {
            var inputProvider = GetStringSplitInputProvider(input);
            var uut = new AdventOfCode2020.Puzzles.Day03.Part01.Puzzle(inputProvider);
            await uut.InitializeAsync();

            var actual = await uut.GetSolutionAsync();

            Assert.True(actual.HasValue);
            Assert.Equal(expected, actual.Value);
        }
    }
}
