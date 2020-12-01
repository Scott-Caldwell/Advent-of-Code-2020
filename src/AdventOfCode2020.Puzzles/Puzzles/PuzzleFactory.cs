using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Puzzles
{
    public class PuzzleFactory
    {
        public IPuzzle? GetPuzzle(int day, int part)
        {
            return (day, part) switch
            {
                (1, 1) => new Day01.Part01.Puzzle(_fileInputProviderInt32),
                (1, 2) => new Day01.Part02.Puzzle(_fileInputProviderInt32),
                _      => null,
            };
        }

        private readonly FileInputProvider<int> _fileInputProviderInt32 = new(str => int.Parse(str));
    }
}
