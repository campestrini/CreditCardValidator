using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using App;

namespace Test
{
    public class ValidatorTest
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        private static Validator _validator = new Validator();
        private static int[] _startingDigit = { 23 };
        private static int[] _length = { 16 };
        private static string _flag = "Visa";

        private static Rule _rule = new Rule(_startingDigit, _length);

        [TestMethod]
        public void ValidatorShouldBeInitializedWithNoRules()
        {
            Assert.IsFalse(_validator.hasRules());
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
        [ExpectedException(typeof(KeyNotFoundException), Validator.FLAG_NOT_FOUND)]
        public void ValidatorShouldThrowExceptionWhenRuleNotExist()
        {
            _validator.getRule("ABC");
        }

        [TestMethod]
        public void RuleShouldBeStoredProperly()
        {
            _validator.addRule(_flag, _rule);
            Rule rule = _validator.getRule(_flag);
            Equals(_rule.startingDigit, rule.startingDigit);
            Equals(_rule.length, rule.length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), Validator.INVALID_CREDIT_CARD)]
        public void ValidatorShouldThrowExeceptionWithInvalidCcNumber()
        {
            _validator.isValid(0);
            _validator.isValid(-1);
        }

        [TestMethod]
        public void ValidatorShouldEvaluateAsValid()
        {
            Assert.IsTrue(_validator.isValid(4111111111111111));
            Assert.IsTrue(_validator.isValid(4012888888881881));
            Assert.IsTrue(_validator.isValid(378282246310005));
            Assert.IsTrue(_validator.isValid(5105105105105100));
        }

        [TestMethod]
        public void ValidatorShouldEvaluateAsInvalid()
        {
            Assert.IsFalse(_validator.isValid(4111111111111));
            Assert.IsFalse(_validator.isValid(5105105105105106));
            Assert.IsFalse(_validator.isValid(9111111111111111));
        }

    }
}