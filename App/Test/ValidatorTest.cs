using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using App;

namespace Test
{
    [TestClass]
    public class ValidatorTest
    {
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
        public void ValidatorShouldThrowExeceptionWithInvalidCcNumber()
        {
            
        }
    }
}
