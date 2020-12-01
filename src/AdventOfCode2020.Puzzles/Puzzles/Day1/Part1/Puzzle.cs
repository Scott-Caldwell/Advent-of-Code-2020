using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Puzzles.Day1.Part1
{
    public class Puzzle : IPuzzle
    {
        public Puzzle(IInputProvider<int> inputProvider)
        {
            _inputProvider = inputProvider;
        }

        public async ValueTask InitializeAsync()
        {
            _input = await _inputProvider.GetInputAsync("Puzzles\\Day1\\Part1\\input");
        }

        public ValueTask<Solution> GetSolutionAsync()
        {
            var lessThan1010 = new List<int>(_input.Length);
            var greaterThanOrEqualTo1010 = new List<int>(_input.Length);

            foreach (var value in _input)
            {
                if (value < 1010)
                {
                    lessThan1010.Add(value);
                }
                else
                {
                    greaterThanOrEqualTo1010.Add(value);
                }
            }

            foreach (var lowerValue in lessThan1010)
            {
                foreach (var upperValue in greaterThanOrEqualTo1010)
                {
                    if (lowerValue + upperValue == 2020)
                    {
                        var solution = (lowerValue * upperValue).ToString();
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
