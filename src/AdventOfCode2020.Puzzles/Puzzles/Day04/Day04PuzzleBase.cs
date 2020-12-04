using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Puzzles.Day04
{
    public abstract class Day04PuzzleBase : PuzzleBase<Passport>
    {
        protected Day04PuzzleBase(IInputProvider<Passport> inputProvider) : base(inputProvider)
        {
        }

        protected async ValueTask InitializeAsync(string location)
        {
            _input = await _inputProvider.GetInputAsync(location);
        }
    }
}
