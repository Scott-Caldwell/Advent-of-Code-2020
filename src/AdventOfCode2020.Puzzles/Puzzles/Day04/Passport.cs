using System.Diagnostics;

namespace AdventOfCode2020.Puzzles.Day04
{
    [DebuggerDisplay("ID = {PassportId}")]
    public class Passport
    {
        public string? BirthYear { get; set; }

        public string? IssueYear { get; set; }

        public string? ExpirationYear { get; set; }

        public string? Height { get; set; }

        public string? HairColor { get; set; }

        public string? EyeColor { get; set; }

        public string? PassportId { get; set; }

        public string? CountryId { get; set; }
    }
}
