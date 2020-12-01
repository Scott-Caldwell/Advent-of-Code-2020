using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace AdventOfCode2020.Puzzles
{
    public readonly struct Solution
    {
        public static Solution FromValue(string value)
            => new(true, value);

        public static Solution FromError(string error)
            => new(false, error);

        public ValueTask<Solution> ToValueTask()
            => new(this);

        private Solution(bool hasValue, string valueOrError)
        {
            HasValue = hasValue;
            _valueOrError = valueOrError;
        }

        [MemberNotNullWhen(true, nameof(Value))]
        public bool HasValue { get; }

        public string? Value => HasValue ? _valueOrError : null;

        public string? Error => HasValue ? null : _valueOrError;

        private readonly string _valueOrError;
    }
}
