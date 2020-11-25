using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Solution.Tests
{
    [TestFixture]
    class LeetCode819Tests
    {
        [Test]
        [TestCase("Bob hit a ball, the hit BALL flew far after it was hit.", new string[] { "hit" }, "ball")]
        [TestCase("Bob hit a ball, the hit BALL flew far after it was hit.", new string[] {  }, "hit")]
        [TestCase("", new string[] {  }, "")]
        public void GetMostCommonWord_WhenCalled_ReturnMostFrequentWordsInParagraphAndNotInBannedListInLowerCase(string paragraph, string[] banned, string expectedResult)
        {
            var result = LeetCode819.GetMostCommonWord(paragraph, banned);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
