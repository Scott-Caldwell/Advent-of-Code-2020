namespace AdventOfCode2020.Puzzles.Day04
{
    public class PassportParser
    {
        public Passport Parse(string input)
        {
            // Example input:
            // ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm

            var index = 0;
            var passport = new Passport();

            while (index < input.Length)
            {
                var (key, value) = ReadKeyValuePair();

                switch (key)
                {
                    case "byr":
                        passport.BirthYear = value;
                        break;
                    case "iyr":
                        passport.IssueYear = value;
                        break;
                    case "eyr":
                        passport.ExpirationYear = value;
                        break;
                    case "hgt":
                        passport.Height = value;
                        break;
                    case "hcl":
                        passport.HairColor = value;
                        break;
                    case "ecl":
                        passport.EyeColor = value;
                        break;
                    case "pid":
                        passport.PassportId = value;
                        break;
                    case "cid":
                        passport.CountryId = value;
                        break;
                }
            }

            return passport;

            (string key, string value) ReadKeyValuePair()
            {
                MoveToNextNonTriviaCharacter();

                var currentStringStart = index;

                MoveToNextTriviaCharacter();

                var key = input[currentStringStart..index];

                MoveToNextNonTriviaCharacter();

                currentStringStart = index;

                MoveToNextTriviaCharacter();

                var value = input[currentStringStart..index];

                return (key, value);

                void MoveToNextNonTriviaCharacter()
                {
                    while (index < input.Length && IsTrivia(input[index]))
                    {
                        index++;
                    }
                }

                void MoveToNextTriviaCharacter()
                {
                    while (index < input.Length && !IsTrivia(input[index]))
                    {
                        index++;
                    }
                }

                bool IsTrivia(char character)
                    => character is ':' or ' ' or '\r' or '\n';
            }
        }
    }
}
