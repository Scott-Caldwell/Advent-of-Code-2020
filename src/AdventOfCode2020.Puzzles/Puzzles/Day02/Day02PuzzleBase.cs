using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Puzzles.Day02
{
    public abstract class Day02PuzzleBase : PuzzleBase<PasswordData>
    {
        protected Day02PuzzleBase(IInputProvider<PasswordData> inputProvider) : base(inputProvider)
        {
        }

        protected async ValueTask InitializeAsync(string location)
        {
            _input = await _inputProvider.GetInputAsync(location);
        }

        public ValueTask<Solution> GetSolutionAsync()
        {
            var validCount = _input.Count(x => IsValid(x));

            return Solution.FromValue(validCount.ToString()).ToValueTask();
        }

        protected abstract bool IsValid(PasswordData input);
    }
}
