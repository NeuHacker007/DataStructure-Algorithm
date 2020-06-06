using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Solution.Tests
{
    [TestFixture]
    class LeetCode5Tests
    {

        //TODO: to be implemented.
        [Test]
        [TestCase("babad", "bab", "aba")]
        [TestCase("cbbd", "bb","")]
        [TestCase("abcde", "a", "e")]
        public void GetLongestPalindromicStr(string str, string expected, string altResult)
        {
            var result = LeetCode5.GetLongestPalindromicStr(str);

            Assert.True(result.Equals(expected) || result.Equals(altResult));
        }


    }
}
