using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using App;

namespace Test
{
    [TestClass]
    public class ValidatorTest
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        private static Validator _validator;
        private static int[] _startingDigit = { 4 };
        private static int[] _length = { 13, 16 };
        private static string _flag = "Visa";

        private static Rule _rule = new Rule(_startingDigit, _length);

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            _validator = TestHelper.generateValidator();
        }

        [TestMethod]
        public void ValidatorShouldBeInitializedWithNoRules()
        {
            Validator validator = new Validator();
            Assert.IsFalse(validator.hasRules());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), Validator.INVALID_FLAG)]
        public void AddRuleWithInvalidFlagShouldThrowException()
        {
            _validator.addRule(null, _rule);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), Validator.INVALID_FLAG)]
        public void AddInvalidRuleShouldThrowException()
        {
            _validator.addRule(_flag, null);

        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), Validator.RULE_NOT_FOUND)]
        public void ValidatorShouldThrowExceptionWhenRuleNotExist()
        {
            _validator.getRule("ABC");
        }

        [TestMethod]
        public void RuleShouldBeStoredProperly()
        {
            Rule rule = _validator.getRule(_flag);
            Equals(_rule.startingDigit, rule.startingDigit);
            Equals(_rule.length, rule.length);
        }

        [TestMethod]
        public void ValidatorShouldEvaluateAsValid()
        {
            Assert.IsTrue(Validator.IsValid("4408041234567893"));
            Assert.IsTrue(Validator.IsValid("4111111111111111"));
            Assert.IsTrue(Validator.IsValid("4012888888881881"));
            Assert.IsTrue(Validator.IsValid("378282246310005"));
            Assert.IsTrue(Validator.IsValid("5105105105105100"));
        }

        [TestMethod]
        public void ValidatorShouldEvaluateAsInvalid()
        {
            Assert.IsFalse(Validator.IsValid("4111111111111"));
            Assert.IsFalse(Validator.IsValid("5105105105105106"));
            Assert.IsFalse(Validator.IsValid("9111111111111111"));
        }

        [TestMethod]
        public void ValidatorShouldEvaluateFlagProperly()
        {
            Equals("VISA", _validator.evaluateFlag("4111111111111111"));
            Equals("VISA", _validator.evaluateFlag("4012888888881881"));
            Equals("AMEX", _validator.evaluateFlag("378282246310005"));
            Equals("Discover", _validator.evaluateFlag("6011111111111117"));
            Equals("MasterCard", _validator.evaluateFlag("5105105105105100"));
        }

    }
}