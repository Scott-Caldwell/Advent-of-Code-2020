using System.Collections.Immutable;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Puzzles
{
    public abstract class PuzzleBase<T>
    {
        protected PuzzleBase(IInputProvider<T> inputProvider)
        {
            _inputProvider = inputProvider;
        }

        protected readonly IInputProvider<T> _inputProvider;
        protected ImmutableArray<T> _input;
    }
}
