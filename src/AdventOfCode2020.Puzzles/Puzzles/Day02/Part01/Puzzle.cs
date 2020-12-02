using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Puzzles.Day02.Part01
{
    public class Puzzle : Day02PuzzleBase, IPuzzle
    {
        public Puzzle(IInputProvider<PasswordData> inputProvider) : base(inputProvider)
        {
        }

        public async ValueTask InitializeAsync()
            => await InitializeAsync("Puzzles\\Day02\\input");

        protected override bool IsValid(PasswordData passwordData)
        {
            var occurrences = 0;

            foreach (var character in passwordData.Password)
            {
                if (character == passwordData.Character)
                {
                    occurrences++;

                    if (occurrences > passwordData.Number2)
                    {
                        return false;
                    }
                }
            }

            return occurrences >= passwordData.Number1;
        }
    }
}
