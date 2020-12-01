using System.Collections.Immutable;
using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Tests.Puzzles
{
    public abstract class PuzzleTestBase
    {
        protected IInputProvider<T> GetInputProvider<T>(T[] input)
            => new TrivialInputProvider<T>(input);

        private class TrivialInputProvider<T> : IInputProvider<T>
        {
            public TrivialInputProvider(T[] input)
            {
                _input = input.ToImmutableArray();
            }

            public ValueTask<ImmutableArray<T>> GetInputAsync(string location)
                => new(_input);

            private readonly ImmutableArray<T> _input;
        }
    }
}
