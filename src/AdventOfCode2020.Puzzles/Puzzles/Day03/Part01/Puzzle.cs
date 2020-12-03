using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Puzzles.Day03.Part01
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
            var treeCount = GetTreeCountProduct((3, 1));

            return Solution.FromValue(treeCount.ToString()).ToValueTask();
        }
    }
}
