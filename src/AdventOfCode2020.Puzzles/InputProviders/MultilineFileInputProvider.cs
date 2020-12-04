using System;
using System.Collections.Immutable;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.InputProviders
{
    public class MultilineFileInputProvider<T> : IInputProvider<T>
    {
        public MultilineFileInputProvider(Func<string, T> parse)
        {
            _parse = parse;
        }

        public async ValueTask<ImmutableArray<T>> GetInputAsync(string location)
        {
            var lines = await File.ReadAllLinesAsync(location, Encoding.UTF8);

            var lineBlocks = ImmutableArray.CreateBuilder<T>();
            var stringBuilder = new StringBuilder();

            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    stringBuilder.AppendLine(line);
                }
                else if (stringBuilder.Length > 0)
                {
                    AddBlock();
                }
            }

            AddBlock();

            return lineBlocks.ToImmutable();

            void AddBlock()
            {
                var lineBlock = stringBuilder.ToString();
                var parsedLineBlock = _parse(lineBlock);

                lineBlocks.Add(parsedLineBlock);
                stringBuilder.Clear();
            }
        }

        private readonly Func<string, T> _parse;
    }
}
