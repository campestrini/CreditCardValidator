using System;

namespace App
{
    public class Rule
    {
        public const string INVALID_STARTING_DIGIT = "Starting point must have a value.";
        public const string INVALID_LENGTH = "Legth must have a value greater than zero.";

        public int[] startingDigit { get; }
        public int[] length { get; }

        public Rule(int[] startingDigit, int[] length)
        {
            this.validateStartingDigit(startingDigit);
            this.validateLength(length);

            this.startingDigit = startingDigit;
            this.length = length;
        }

        private void validateStartingDigit(int[] startingPoint)
        {
            if (startingPoint == null || startingPoint.Length == 0)
            {
                throw new ArgumentException(INVALID_STARTING_DIGIT);
            }
        }

        private void validateLength(int[] length)
        {
            if (length == null || length.Length == 0)
            {
                throw new ArgumentException(INVALID_LENGTH);
            }

            foreach (int element in length)
            {
                if (element <= 0)
                {
                    throw new ArgumentException(INVALID_LENGTH);
                }
            }
        }
    }
}