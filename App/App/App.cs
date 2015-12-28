using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class App
    {
        static void Main()
        {
            Validator validator = new Validator();
            Rule amexRule = new Rule(new int[] { 34, 37 }, new int[] { 15 });
            validator.addRule("AMEX", amexRule);

            long creditCard = 4111111111111111;
            bool valid = validator.isValid(creditCard);


        }
    }
}
