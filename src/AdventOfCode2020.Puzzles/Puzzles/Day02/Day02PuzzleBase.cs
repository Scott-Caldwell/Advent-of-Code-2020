using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Puzzles.Day02
{
    public abstract class Day02PuzzleBase
    {
        protected Day02PuzzleBase(IInputProvider<PasswordData> inputProvider)
        {
            _inputProvider = inputProvider;
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

        private readonly IInputProvider<PasswordData> _inputProvider;
        protected ImmutableArray<PasswordData> _input;
    }
}
