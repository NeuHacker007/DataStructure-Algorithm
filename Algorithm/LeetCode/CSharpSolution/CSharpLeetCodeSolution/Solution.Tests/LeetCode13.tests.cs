using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Solution.Tests
{
    [TestFixture]
    class LeetCode13Tests
    {

        [Test]
        [TestCase("III",3)]
        public void RomanToIntV1_WhenCalled_ReturnIntegerRepresentByRoman(string s, int expectedResult)
        {
           var result = LeetCode13.RomanToIntV1(s);

           Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
