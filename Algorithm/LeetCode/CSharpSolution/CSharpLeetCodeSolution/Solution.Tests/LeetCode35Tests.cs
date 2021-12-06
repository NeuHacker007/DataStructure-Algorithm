using System;
using NUnit.Framework;
using LcArraySolution;

namespace Solution.Tests
{
    [TestFixture]
    public class LeetCode35Tests
    {
        private static int[] tc1 = new[]
        {
            1,3,5,6
        };
        private static int[] tc2 = new[]
        {
            1
        };
        private static Object[] leetCode35TestsCases = new Object []
        {
            new Object[] {tc1, 5, 2},
            new Object[] {tc1, 2, 1},
            new Object[] {tc1, 7, 4},
            new Object[] {tc1, 0, 0},
            new Object[] {tc2, 0, 0}
        };
        [TestCase]
        [TestCaseSource("leetCode35TestsCases")]
        public void SearchInsert_WhenCalled_ReturnInsertPosition(int[] nums, int target, int expectedResult)
        {
            var result = LeetCode35.SearchInsert(nums, target);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}