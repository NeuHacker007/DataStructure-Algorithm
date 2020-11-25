using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Solution.Tests
{
    [TestFixture]
    class LeetCode763Tests
    {
        private static readonly IList<int> expectedResult = new List<int>()
        {
            {9},
            {7},
            {8}
        };

        private static object[] testCases = new Object[]
        {
            new object[]{ "ababcbacadefegdehijhklij", expectedResult}
        };
        [Test]
        [TestCaseSource("testCases")]
        public void PartitionLabels_WhenCalled_ReturnPartitionLabelsLength(string str, IList<int> expectedResult)
        {
            var result = LeetCode763.PartitionLabels(str);


            Assert.That(result, Is.EquivalentTo(expectedResult));
        }
    }
}
