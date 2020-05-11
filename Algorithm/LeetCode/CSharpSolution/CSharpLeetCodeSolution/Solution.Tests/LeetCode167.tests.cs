using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Solution.Tests
{
    [TestFixture]
    class LeetCode167Tests
    {
        [Test]
        [TestCase(new int[] {2, 7, 11, 15}, 9, new int[] {1, 2})]
        [TestCase(new int[] {2, 8, 11, 15}, 9, new int[] {})]
        [TestCase(new int[] {}, 9, new int[] {})]

        public void TwoSumII_WhenCalled_ReturnIndexesThatMadeupSumEqualToTarget(int[] nums, int target, int[] expectedResult)
        {
            var result = LeetCode167.TwoSumII(nums, target);

            Assert.That(result, Is.EquivalentTo(expectedResult));
        }
    }
}
