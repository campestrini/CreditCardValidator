using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App;

namespace Test
{
    [TestClass]
    public class ValidatorHelperTest
    {
        [TestMethod]
        public void ItShouldBuildTheCorrectString()
        {
            Validator validator = TestHelper.generateValidator();
            ValidatorHelper.buildString(4111111111111111);

            Equals("VISA", validator.evaluateFlag(4012888888881881));
            Equals("AMEX", validator.evaluateFlag(378282246310005));
            Equals("Discover", validator.evaluateFlag(6011111111111117));
            Equals("MasterCard", validator.evaluateFlag(5105105105105100));


        }
    }
}
