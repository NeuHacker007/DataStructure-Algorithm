using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Solution.Tests
{
    [TestFixture]
    class LeetCode227Test
    {

        [Test]
        [TestCase("3+2*2", 7)]
        [TestCase("3/2", 1)]
        [TestCase(" 3+5 / 2 ", 5)]
        [TestCase(" 333+5 / 2 ", 335)]
        public void Calculate_WhenCalled_ReturnValueOfExpression(string input, int expectedResult)
        {
            var result = LeetCode227.Calculate(input);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
