using App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class TestHelper
    {
        public static Validator generateValidator()
        {
            Validator validator = new Validator();

            Rule amexRule = new Rule(new int[] { 34, 37 }, new int[] { 15 });
            validator.addRule("AMEX", amexRule);

            Rule discoverRule = new Rule(new int[] { 6011 }, new int[] { 16 });
            validator.addRule("Discover", discoverRule);

            Rule masterCardRule = new Rule(new int[] { 51, 55 }, new int[] { 16 });
            validator.addRule("MasterCard", masterCardRule);

            Rule visaRule = new Rule(new int[] { 4 }, new int[] { 13, 16 });
            validator.addRule("Visa", visaRule);

            return validator;
        }
    }
}
