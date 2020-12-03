using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Tests.Puzzles
{
    public abstract class PuzzleTestBase
    {
        protected IInputProvider<T> GetInputProvider<T>(T[] input)
            => new TrivialInputProvider<T>(input);

        protected IInputProvider<T> GetParsingInputProvider<T>(string[] input, Func<string, T> parse)
            => new TrivialInputProvider<T>(input.Select(parse));

        protected IInputProvider<string> GetStringSplitInputProvider(string input)
            => new TrivialInputProvider<string>(input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));

        private class TrivialInputProvider<T> : IInputProvider<T>
        {
            public TrivialInputProvider(T[] input)
            {
                _input = input.ToImmutableArray();
            }

            public TrivialInputProvider(IEnumerable<T> input)
            {
                _input = input.ToImmutableArray();
            }

            public ValueTask<ImmutableArray<T>> GetInputAsync(string location)
                => new(_input);

            private readonly ImmutableArray<T> _input;
        }
    }
}
