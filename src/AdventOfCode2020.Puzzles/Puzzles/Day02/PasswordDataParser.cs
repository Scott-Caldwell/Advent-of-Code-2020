namespace AdventOfCode2020.Puzzles.Day02
{
    public class PasswordDataParser
    {
        public PasswordData Parse(string input)
        {
            // Example input:
            // 1-3 a: abcde

            var index = 0;
            var number1 = ReadInt32();

            // Skip hyphen
            index++;

            var number2 = ReadInt32();

            // Skip space
            index++;

            var character = input[index];

            // Move past the character and skip the colon and space
            index += 3;

            var password = input[index..];

            return new PasswordData(number1, number2, character, password);

            int ReadInt32()
            {
                var currentChar = input[index];
                var value = 0;

                while (currentChar is >= '0' and <= '9')
                {
                    value *= 10;
                    value += currentChar - '0';

                    index++;
                    currentChar = input[index];
                }

                return value;
            }
        }
    }
}
