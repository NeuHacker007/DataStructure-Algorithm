using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Solution.Tests
{
    [TestFixture]
    class LeetCode692Tests
    {
        public static object[] testCase =
        {
            new object[]{ new string[]{"i", "love", "leetcode", "i", "love", "coding"}, 2, new string[]{"i", "love"}},
            new object[]{ new string[]{ "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is" }, 4 , new string[]{ "the", "is", "sunny", "day" } }

        };

        [Test]
        [TestCaseSource("testCase")]
        public void GetMostFreqKWords_WhenCalled_TopKFrequentWords(string[] words, int k, string[] expected)
        {
            var actual = LeetCode692.GetMostFreqKWords(words, k).ToArray();

            Assert.That(actual, Is.EquivalentTo(expected));
        }


    }
}
