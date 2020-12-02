using System.Threading.Tasks;
using AdventOfCode2020.InputProviders;

namespace AdventOfCode2020.Puzzles.Day02.Part02
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
            return IsCharacterAtPositionValid(passwordData.Number1) ^ IsCharacterAtPositionValid(passwordData.Number2);

            bool IsCharacterAtPositionValid(int position)
                => passwordData.Password[position - 1] == passwordData.Character;
        }
    }
}
