using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Puzzles.Day03.Part02
{
    public class Puzzle : Day03PuzzleBase, IPuzzle
    {
        public Puzzle(IInputProvider<string> inputProvider) : base(inputProvider)
        {
        }

        public async ValueTask InitializeAsync()
            => await InitializeAsync("Puzzles\\Day03\\input");

        public ValueTask<Solution> GetSolutionAsync()
        {
            var product = GetTreeCountProduct
            (
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2)
            );

            return Solution.FromValue(product.ToString()).ToValueTask();
        }
    }
}
