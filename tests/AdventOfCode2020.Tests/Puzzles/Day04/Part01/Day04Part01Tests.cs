using System.Threading.Tasks;
using AdventOfCode2020.Puzzles.Day04;
using Xunit;

namespace AdventOfCode2020.Tests.Puzzles.Day04.Part01
{
    public class Day04Part01Tests : PuzzleTestBase
    {
        [Theory]
        [InlineData(new[]
        {
            @"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm",
            @"iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929",
            @"hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm",
            @"hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in",
        },
            "2")]
        public async Task GivenValidInput_ReturnsCorrectSolution(string[] input, string expected)
        {
            var parser = new PassportParser();
            var inputProvider = GetParsingInputProvider(input, str => parser.Parse(str));
            var uut = new AdventOfCode2020.Puzzles.Day04.Part01.Puzzle(inputProvider);
            await uut.InitializeAsync();

            var actual = await uut.GetSolutionAsync();

            Assert.True(actual.HasValue);
            Assert.Equal(expected, actual.Value);
        }
    }
}
