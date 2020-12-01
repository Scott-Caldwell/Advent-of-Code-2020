using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.InputProviders
{
    public class FileInputProvider<T> : IInputProvider<T>
    {
        public FileInputProvider(Func<string, T> converter)
        {
            _converter = converter;
        }

        public async ValueTask<ImmutableArray<T>> GetInputAsync(string location)
        {
            var lines = await File.ReadAllLinesAsync(location, Encoding.UTF8);

            return lines
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(_converter)
                .ToImmutableArray();
        }

        private readonly Func<string, T> _converter;
    }
}
