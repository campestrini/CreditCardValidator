using System;
using System.Collections.Generic;
using System.Linq;

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

        public bool isValid(string creditCardNumber)
        {
            Console.WriteLine(creditCardNumber);

            bool isValid = false;
            int[] cc = Array.ConvertAll(creditCardNumber.ToCharArray(), c => (int)char.GetNumericValue(c));
            Array.Reverse(cc);
         
            for (int i = 1; i < cc.Length; i++)
            {
                if (i % 2 == 1)
                {
                    int digit = cc[i] * 2;

                    if (digit > 9)
                    {
                        digit = SumOfDigits(digit);
                    }
                    cc[i] = digit;
                }
            }

            if (cc.Sum() % 10 == 0)
            {
                isValid = true;
            }
            
            return isValid;
        }

        private static int SumOfDigits(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }

        public string evaluateFlag(string creditCardNumber)
        {
            string flag = FLAG_NOT_FOUND;

            foreach (KeyValuePair<string, Rule> pair in rules)
            {
                Rule rule = pair.Value;
                string[] startingDigit = rule.startingDigit.Select(n => Convert.ToString(n)).ToArray();

                foreach (string digit in startingDigit)
                {
                    string slicedCreditCard = creditCardNumber.Substring(0, digit.Length);

                    if (digit.Equals(slicedCreditCard))
                    {
                        flag = pair.Key;
                        break;
                    }
                }
            }
            return flag;
        }
    }
}