using DiamondKata.Exceptions;

using System.Text;

namespace DiamondKata
{
    public class DiamondCreator
    {
        private string[] _alphabet = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        private string _dividerCharacter = " ";

        public string Create(string input)
        {
            ValidateInputIsOneCharacter(input);
            var position = GetLetterPosition(input);

            if (position == 0)
            {
                return _alphabet[0];
            }

            return BuildLetterDiamond(position);
        }

        private string BuildLetterDiamond(int position)
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i <= position; i++)
            {
                stringBuilder.AppendLine(FormatRow(position, i));
            }

            for (int i = (position - 1); i >= 0; i--)
            {
                stringBuilder.AppendLine(FormatRow(position, i));
            }

            return stringBuilder.ToString();
        }

        private void ValidateInputIsOneCharacter(string input)
        {
            if (input.Length != 1)
            {
                throw new InvalidInputException("Input must be a single character.");
            }
        }

        private int GetLetterPosition(string input)
        {
            var letterPosition = Array.IndexOf(_alphabet, input.ToLower());

            if (letterPosition == -1)
            {
                throw new InvalidInputException("Input must be a letter (a - z).");
            }

            return letterPosition;
        }

        private string FormatRow(int letterPosition, int rowNumber)
        {
            var innerSpacers = string.Empty;
            var outerSpacers = string.Empty;

            var numberOfOuterSpacers = letterPosition - rowNumber;

            for (int i = 0; i < numberOfOuterSpacers; i++)
            {
                outerSpacers += _dividerCharacter;
            }

            if (rowNumber == 0)
            {
                return $"{outerSpacers}{_alphabet[rowNumber]}{outerSpacers}";
            }
            else
            {
                for (int i = letterPosition; i > numberOfOuterSpacers; i--)
                {
                    if (rowNumber == 1 || i == 2)
                    {
                        innerSpacers += _dividerCharacter;
                    }
                    else
                    {
                        innerSpacers += _dividerCharacter + _dividerCharacter;
                    }
                }

                return $"{outerSpacers}{_alphabet[rowNumber]}{innerSpacers}{_alphabet[rowNumber]}{outerSpacers}";
            }
        }
    }
}