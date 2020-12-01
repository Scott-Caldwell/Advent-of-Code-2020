using System.Collections.Immutable;
using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Puzzles.Puzzles.Day01
{
    public abstract class Day01PuzzleBase
    {
        protected Day01PuzzleBase(IInputProvider<int> inputProvider)
        {
            _inputProvider = inputProvider;
        }

        protected async ValueTask InitializeAsync(string location)
        {
            var input = await _inputProvider.GetInputAsync(location);
            _input = input.Sort();
        }

        protected const int SumValue = 2020;

        private readonly IInputProvider<int> _inputProvider;
        protected ImmutableArray<int> _input;
    }
}
