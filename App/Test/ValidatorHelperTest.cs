using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App;

namespace Test
{
    [TestClass]
    public class ValidatorHelperTest
    {
        private static ValidatorHelper _helper;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            _helper = new ValidatorHelper(TestHelper.generateValidator());
        }

        [TestMethod]
        public void ItShouldBuildTheCorrectString()
        {
            Equals("Visa: 4111111111111111 (" + ValidatorHelper.VALID_CREDIT_CARD + ").", _helper.validationMessage("4111111111111111"));
            Equals("Visa: 4111111111111 (" + Validator.INVALID_CREDIT_CARD + ").", _helper.validationMessage("4111111111111"));
            Equals("Visa: 4012888888881881 (" + ValidatorHelper.VALID_CREDIT_CARD + ").", _helper.validationMessage("4012888888881881"));
            Equals("Amex: 378282246310005 (" + ValidatorHelper.VALID_CREDIT_CARD + ").", _helper.validationMessage("378282246310005"));
            Equals("Discover: 6011111111111117 (" + ValidatorHelper.VALID_CREDIT_CARD + ").", _helper.validationMessage("6011111111111117"));
            Equals("MasterCard: 5105105105105100 (" + ValidatorHelper.VALID_CREDIT_CARD + ").", _helper.validationMessage("5105105105105100"));
            Equals("MasterCard: 5105105105105106 (" + ValidatorHelper.INVALID_CREDIT_CARD + ").", _helper.validationMessage("5105105105105100"));
            Equals("Unknown: 5105105105105106 (" + ValidatorHelper.INVALID_CREDIT_CARD + ").", _helper.validationMessage("9111111111111111"));
        }
    }
}
