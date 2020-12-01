using System.Threading.Tasks;

namespace AdventOfCode2020.Puzzles
{
    public interface IPuzzle
    {
        public ValueTask InitializeAsync();

        public ValueTask<Solution> GetSolutionAsync();
    }
}
