using System.Collections.Immutable;
using System.Threading.Tasks;

namespace AdventOfCode2020.InputProviders
{
    public interface IInputProvider<T>
    {
        public ValueTask<ImmutableArray<T>> GetInputAsync(string location);
    }
}
