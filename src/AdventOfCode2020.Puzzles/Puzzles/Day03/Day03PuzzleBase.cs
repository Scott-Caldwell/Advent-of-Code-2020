using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Puzzles.Day03
{
    public abstract class Day03PuzzleBase : PuzzleBase<string>
    {
        protected Day03PuzzleBase(IInputProvider<string> inputProvider) : base(inputProvider)
        {
        }

        protected async ValueTask InitializeAsync(string location)
        {
            _input = await _inputProvider.GetInputAsync(location);
            _height = _input.Length;
            _width = _input[0].Length;
        }

        protected long GetTreeCountProduct(params (int stepRight, int stepDown)[] scenarios)
        {
            var product = 1L;

            foreach (var (stepRight, stepDown) in scenarios)
            {
                product *= GetTreeCount(stepRight, stepDown);
            }

            return product;
        }

        private int GetTreeCount(int stepRight, int stepDown)
        {
            var (x, y) = (0, 0);

            var treeCount = _input[0][0] == Tree ? 1 : 0;

            while (TryAdvancePosition())
            {
                if (_input[y][x] == Tree)
                {
                    treeCount++;
                }
            }

            return treeCount;

            bool TryAdvancePosition()
            {
                x = (x + stepRight) % _width;
                y += stepDown;

                return y < _height;
            }
        }

        protected const char Tree = '#';

        protected int _height;
        protected int _width;
    }
}
