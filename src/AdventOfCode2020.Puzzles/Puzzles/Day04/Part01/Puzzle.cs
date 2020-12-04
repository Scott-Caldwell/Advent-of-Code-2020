using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Puzzles.Day04.Part01
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
            => passport.BirthYear is not null
            && passport.IssueYear is not null
            && passport.ExpirationYear is not null
            && passport.Height is not null
            && passport.HairColor is not null
            && passport.EyeColor is not null
            && passport.PassportId is not null;
    }
}
