using System;
using System.Collections.Generic;

namespace App
{
    public class Validator
    {
        public const string INVALID_FLAG = "Credit card flag must have a value.";
        public const string INVALID_RULE = "Rule can't be null.";
        public const string FLAG_NOT_FOUND = "There is no rule for this flag.";

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
                throw new KeyNotFoundException(FLAG_NOT_FOUND);
            }

            return rules[flag];
        }

    }
}