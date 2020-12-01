using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Puzzles.Day1.Part2
{
    public class Puzzle : IPuzzle
    {
        public Puzzle(IInputProvider<int> inputProvider)
        {
            _inputProvider = inputProvider;
        }

        public async ValueTask InitializeAsync()
        {
            _input = await _inputProvider.GetInputAsync("Puzzles\\Day1\\Part2\\input");
        }

        public ValueTask<Solution> GetSolutionAsync()
        {
            var values = _input.ToArray();
            Array.Sort(values);

            for (var lowIndex = 0; lowIndex < values.Length; lowIndex++)
            {
                var lowValue = values[lowIndex];

                for (var highIndex = values.Length - 1; highIndex > lowIndex + 1; highIndex--)
                {
                    var highValue = values[highIndex];
                    var midValue = 2020 - (lowValue + highValue);

                    var midIndex = Array.BinarySearch(values, lowIndex + 1, highIndex - lowIndex - 1, midValue);

                    if (midIndex > 0)
                    {
                        var solution = (lowValue * midValue * highValue).ToString();
                        return Solution.FromValue(solution).ToValueTask();
                    }
                }
            }

            return Solution.FromError("Could not find a solution.").ToValueTask();
        }

        private readonly IInputProvider<int> _inputProvider;
        private ImmutableArray<int> _input;
    }
}
