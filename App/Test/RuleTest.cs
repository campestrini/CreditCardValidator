using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App;

namespace Test
{
    [TestClass]
    public class RuleTest
    {
        private static int[] _validStartingDigit = { 6011 };
        private static int[] _validLenght = { 13, 16 };

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), Rule.INVALID_STARTING_DIGIT)]
        public void RuleConstructorWithInvalidStartingPointShouldThrowAnException()
        {
            int[] startingDigit = null;
            Rule rule = new Rule(startingDigit, _validLenght);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), Rule.INVALID_LENGTH)]
        public void RuleConstructorWithInvalidLengthShouldThrowAnException()
        {
            int[] length = null;
            Rule rule = new Rule(_validStartingDigit, length);
        }
        [TestMethod]
        public void RuleShouldBeConstructedProperly()
        {
            Rule rule = new Rule(_validStartingDigit, _validLenght);
            Equals(_validStartingDigit, rule.startingDigit);
            Equals(_validLenght, rule.length);
        }
    }
}
