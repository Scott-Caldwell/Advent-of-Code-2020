using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Puzzles.Day04.Part02
{
    public class Puzzle : Day04PuzzleBase, IPuzzle
    {
        public Puzzle(IInputProvider<Passport> inputProvider) : base(inputProvider)
        {
        }

        public async ValueTask InitializeAsync()
            => await InitializeAsync("Puzzles\\Day04\\input");

        public ValueTask<Solution> GetSolutionAsync()
        {
            var validCount = _input.Count(x => IsValid(x));

            return Solution.FromValue(validCount.ToString()).ToValueTask();
        }

        private bool IsValid(Passport passport)
        {
            return IsYearInRange(passport.BirthYear, 1920, 2002)
                && IsYearInRange(passport.IssueYear, 2010, 2020)
                && IsYearInRange(passport.ExpirationYear, 2020, 2030)
                && IsValidHeight(passport.Height)
                && IsValidHairColor(passport.HairColor)
                && passport.EyeColor is "amb" or "blu" or "brn" or "gry" or "grn" or "hzl" or "oth"
                && passport.PassportId is { Length: 9 } passportId && uint.TryParse(passportId, out _);

            bool IsYearInRange(string? year, int minimumInclusive, int maximumInclusive)
                => year is { Length: 4 }
                && int.TryParse(year, out var yearValue)
                && yearValue >= minimumInclusive
                && yearValue <= maximumInclusive;

            bool IsValidHeight(string? height)
            {
                if (height is null || ParseHeight() is not var (value, units))
                {
                    return false;
                }

                return units switch
                {
                    "cm" => value is >= 150 and <= 193,
                    "in" => value is >= 59 and <= 76,
                    _ => false,
                };

                (int value, string units)? ParseHeight()
                {
                    var index = 0;
                    var value = 0;

                    while (index < height.Length && height[index] is >= '0' and <= '9')
                    {
                        value *= 10;
                        value += height[index] - '0';
                        index++;
                    }

                    if (height.Length - 2 != index)
                    {
                        return null;
                    }

                    return height[index..] switch
                    {
                        var units and ("cm" or "in") => (value, units),
                        _ => null,
                    };
                }
            }

            bool IsValidHairColor(string? hairColor)
            {
                if (hairColor is not { Length: 7 } || hairColor[0] != '#')
                {
                    return false;
                }

                for (var i = 1; i < hairColor.Length; i++)
                {
                    if (hairColor[i] is not (>= '0' and <= '9') and not (>= 'a' and <= 'f'))
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
