using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;
using AdventOfCode2020.Puzzles.Puzzles.Day01;

namespace AdventOfCode2020.Puzzles.Day01.Part01
{
    public class Puzzle : Day01PuzzleBase, IPuzzle
    {
        public Puzzle(IInputProvider<int> inputProvider) : base(inputProvider)
        {
        }

        public async ValueTask InitializeAsync()
        {
            await InitializeAsync("Puzzles\\Day01\\Part01\\input");
        }

        public ValueTask<Solution> GetSolutionAsync()
        {
            for (var lowIndex = 0; lowIndex < _input.Length - 1; lowIndex++)
            {
                var lowValue = _input[lowIndex];
                var highValue = SumValue - lowValue;

                var highIndex = _input.BinarySearch(lowIndex + 1, _input.Length - lowIndex - 1, highValue);

                if (highIndex > 0)
                {
                    var solution = (lowValue * highValue).ToString();
                    return Solution.FromValue(solution).ToValueTask();
                }
            }

            return Solution.FromError("Could not find a solution.").ToValueTask();
        }
    }
}
