using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Solution;

namespace Solution.Tests
{
    [TestFixture]
    class LeetCode1Tests
    {
        [Test]
        [TestCase(new int[]{ 2, 7, 11, 15 }, 9, new int[] {0, 1})]
        [TestCase(new int[]{  }, 9, new int[] {})]
        public void TwoSum_WhenCalled_ReturnIndexArrayAddedToTarget(int[] nums, int target, int[] expected)
        {
            var result = LeetCode1.TwoSum(nums, target);

            Assert.That(result, Is.EquivalentTo(expected));
        }
    }
}
