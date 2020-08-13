using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Solution.Tests
{
    [TestFixture]
    public class LeetCode560Tests
    {
        [Test]
        [TestCase(new int[] { 1, 1, 1 }, 2, 2)]
        [TestCase(new int[] { 1, 1, 1 }, 1, 3)]
        [TestCase(new int[] { 1, 1, 1 }, 3, 1)]
        [TestCase(new int[] { 1, 1, 1 }, 0, 0)]
        public void SubArraySumBruteForce_ReturnCount(int[] nums, int k, int expectedResult)
        {
            var result = LeetCode560.SubArraySumBruteForce(nums, k);

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        [TestCase(new int[] { 1, 1, 1 }, 2, 2)]
        [TestCase(new int[] { 1, 1, 1 }, 1, 3)]
        [TestCase(new int[] { 1, 1, 1 }, 3, 1)]
        [TestCase(new int[] { 1, 1, 1 }, 0, 0)]
        public void SubArraySumCumulativeSum_ReturnCount(int[] nums, int k, int expectedResult)
        {
            var result = LeetCode560.SubArraySumBruteForce(nums, k);

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        [TestCase(new int[] { 1, 1, 1 }, 2, 2)]
        [TestCase(new int[] { 1, 1, 1 }, 1, 3)]
        [TestCase(new int[] { 1, 1, 1 }, 3, 1)]
        [TestCase(new int[] { 1, 1, 1 }, 0, 0)]
        public void SubArraySumWithoutSpace_ReturnCount(int[] nums, int k, int expectedResult)
        {
            var result = LeetCode560.SubArraySumBruteForce(nums, k);

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        [TestCase(new int[] { 1, 1, 1 }, 2, 2)]
        [TestCase(new int[] { 1, 1, 1 }, 1, 3)]
        [TestCase(new int[] { 1, 1, 1 }, 3, 1)]
        [TestCase(new int[] { 1, 1, 1 }, 0, 0)]
        public void SubArraySumHashMap_ReturnCount(int[] nums, int k, int expectedResult)
        {
            var result = LeetCode560.SubArraySumBruteForce(nums, k);

            Assert.AreEqual(result, expectedResult);
        }
    }
}
