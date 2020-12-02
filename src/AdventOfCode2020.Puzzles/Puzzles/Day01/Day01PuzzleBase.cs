using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Puzzles.Puzzles.Day01
{
    public abstract class Day01PuzzleBase : PuzzleBase<int>
    {
        protected Day01PuzzleBase(IInputProvider<int> inputProvider) : base(inputProvider)
        {
        }

        protected async ValueTask InitializeAsync(string location)
        {
            var input = await _inputProvider.GetInputAsync(location);
            _input = input.Sort();
        }

        protected const int SumValue = 2020;
    }
}
