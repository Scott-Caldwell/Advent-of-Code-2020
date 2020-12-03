using System;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2020.Tests.Puzzles.Day03.Part02
{
    public class Day03Part02Tests : PuzzleTestBase
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
            "336")]
        public async Task GivenValidInput_ReturnsCorrectSolution(string input, string expected)
        {
            var inputProvider = GetStringSplitInputProvider(input);
            var uut = new AdventOfCode2020.Puzzles.Day03.Part02.Puzzle(inputProvider);
            await uut.InitializeAsync();

            var actual = await uut.GetSolutionAsync();

            Assert.True(actual.HasValue);
            Assert.Equal(expected, actual.Value);
        }
    }
}
