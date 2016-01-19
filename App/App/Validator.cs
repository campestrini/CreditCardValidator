using System;
using System.Collections.Generic;

namespace App
{
    public class Validator
    {
        public const string INVALID_FLAG = "Credit card flag must have a value.";
        public const string INVALID_RULE = "Rule can't be null.";
        public const string RULE_NOT_FOUND = "There is no rule for this flag.";
        public const string INVALID_CREDIT_CARD = "Credit card number must be greater than zero.";
        public const string FLAG_NOT_FOUND = "Unknown";
        public Dictionary<string, Rule> rules;

        public Validator()
        {
            this.rules = new Dictionary<string, Rule>();
        }

        public bool hasRules()
        {
            return Convert.ToBoolean(rules.Count);
        }

        public void addRule(string flag, Rule rule)
        {
            if (String.IsNullOrEmpty(flag))
            {
                throw new ArgumentException(INVALID_FLAG);
            }
            else if (rule == null)
            {
                throw new ArgumentException(INVALID_RULE);
            }

            rules.Add(flag, rule);
        }

        public Rule getRule(string flag)
        {
            if (!rules.ContainsKey(flag))
            {
                throw new KeyNotFoundException(RULE_NOT_FOUND);
            }

            return rules[flag];
        }

        public bool isValid(long creditCardNumber)
        {

            bool isValid = false;

            if (creditCardNumber <= 0)
            {
                throw new ArgumentException(INVALID_CREDIT_CARD);
            }

            List<int> digits = ListOfDigits(creditCardNumber);
            digits.Reverse();

            for (int i = 1; i < digits.Count; i++)
            {
                if (i % 2 == 1)
                {
                    int n = digits[i] * 2;
                    if (n > 9)
                    {
                        n = SumOfDigits(ListOfDigits(n));
                    }

                    digits[i] = n;
                }
            }

            int finalSum = SumOfDigits(digits);

            if (finalSum % 10 == 0)
            {
                isValid = true;
            }

            return isValid;

        }

        private static int SumOfDigits(List<int> digits)
        {
            int sum = 0;

            foreach (int digit in digits)
            {
                sum = sum + digit;
            }

            return sum;
        }

        private static List<int> ListOfDigits(long number)
        {
            List<int> digits = new List<int>();
            foreach (char n in number.ToString().ToCharArray())
            {
                digits.Add((int)char.GetNumericValue(n));
            }

            return digits;
        }


        public string evaluateFlag(long creditCard)
        {
            string flag = FLAG_NOT_FOUND;

            foreach (KeyValuePair<string, Rule> pair in rules)
            {
                Rule rule = pair.Value;
                int[] startingDigit = rule.startingDigit;

                List<int> cc = ListOfDigits(creditCard);

                foreach (int d in startingDigit)
                {
                    List<int> digit = ListOfDigits(d);

                    for (int i = 0; i < digit.Count; i++)
                    {
                        if(digit[i] != cc[i])
                        {
                            break;
                        }

                        flag = pair.Key;
                    }
                }
            }

            return flag;
        }
    }
}