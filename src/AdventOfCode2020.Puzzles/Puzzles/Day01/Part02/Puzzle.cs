using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;
using AdventOfCode2020.Puzzles.Puzzles.Day01;

namespace AdventOfCode2020.Puzzles.Day01.Part02
{
    public class Puzzle : Day01PuzzleBase, IPuzzle
    {
        public Puzzle(IInputProvider<int> inputProvider) : base(inputProvider)
        {
        }

        public async ValueTask InitializeAsync()
        {
            await InitializeAsync("Puzzles\\Day01\\Part02\\input");
        }

        public ValueTask<Solution> GetSolutionAsync()
        {
            for (var lowIndex = 0; lowIndex < _input.Length - 2; lowIndex++)
            {
                var lowValue = _input[lowIndex];

                for (var highIndex = _input.Length - 1; highIndex > lowIndex + 1; highIndex--)
                {
                    var highValue = _input[highIndex];
                    var midValue = 2020 - (lowValue + highValue);

                    var midIndex = _input.BinarySearch(lowIndex + 1, highIndex - lowIndex - 1, midValue);

                    if (midIndex > 0)
                    {
                        var solution = (lowValue * midValue * highValue).ToString();
                        return Solution.FromValue(solution).ToValueTask();
                    }
                }
            }

            return Solution.FromError("Could not find a solution.").ToValueTask();
        }
    }
}
