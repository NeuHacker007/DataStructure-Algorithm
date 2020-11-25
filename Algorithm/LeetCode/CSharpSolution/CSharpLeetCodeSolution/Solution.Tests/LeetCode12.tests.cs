using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Solution.Tests
{
    [TestFixture]
    class LeetCode12Tests
    {
        [Test]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(9, "IX")]
        [TestCase(58, "LVIII")]
        [TestCase(1994, "MCMXCIV")]
        public void intToRomanV1_WhenCalled_ReturnRomanNumber(int num, string expectedResult)
        {
            var result = LeetCode12.intToRomanV1(num);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
