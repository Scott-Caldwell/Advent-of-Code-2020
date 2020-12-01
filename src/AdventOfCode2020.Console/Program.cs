using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using AdventOfCode2020.Puzzles;

namespace AdventOfCode2020.ConsoleApp
{
    internal class Program
    {
        [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        private static async Task Main()
        {
            var puzzleFactory = new PuzzleFactory();

            Console.WriteLine("Enter a day and part in day.part format (e.g. 1.2 for day one, part two).");
            Console.WriteLine("Enter \"exit\" to exit.");

            while (true)
            {
                var input = Console.ReadLine();

                if (input is null || input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var split = input.Split('.', 2, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                if (split.Length != 2)
                {
                    Console.WriteLine("{0} is not in a valid input format.", input);
                    continue;
                }

                if (split[0] is var dayInput && !int.TryParse(dayInput, out var day))
                {
                    Console.WriteLine("{0} is not a valid day.", dayInput);
                    continue;
                }

                if (split[1] is var partInput && !int.TryParse(partInput, out var part))
                {
                    Console.WriteLine("{0} is not a valid part.", partInput);
                    continue;
                }

                var puzzle = puzzleFactory.GetPuzzle(day, part);

                if (puzzle is null)
                {
                    Console.WriteLine("A puzzle solution has not been implemented for day {0} part {1}.", day, part);
                    continue;
                }

                await puzzle.InitializeAsync();

                var stopwatch = Stopwatch.StartNew();

                var solution = await puzzle.GetSolutionAsync();

                stopwatch.Stop();

                if (solution.HasValue)
                {
                    Console.WriteLine("Solution: {0}", solution.Value);
                }
                else
                {
                    Console.WriteLine("Error: {0}", solution.Error);
                }

                Console.WriteLine("Execution time: {0}", stopwatch.Elapsed);
                Console.WriteLine();
            }
        }
    }
}
