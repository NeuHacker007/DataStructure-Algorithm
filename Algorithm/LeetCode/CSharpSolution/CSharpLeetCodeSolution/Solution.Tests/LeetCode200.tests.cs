using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Solution.Tests
{
    [TestFixture]
    class LeetCode200Tests
    {
        private static readonly char[][] GridTestCases =
        {
            new char[] {'1', '1', '1', '1', '0'},
            new char[] {'1', '1', '0', '1', '0'},
            new char[] {'1', '1', '0', '0', '0'},
            new char[] {'0', '0', '0', '0', '0'}

        };

        private static Object[] _numsOfIslandsCases =
        {
            new Object[] { GridTestCases, 1}
        }; 
        [Test]
        [TestCaseSource("_numsOfIslandsCases")]
        public void GetNumsOfIslands_WhenCalled_ReturnNumsOfIsland(char[][] grid, int expectedResult)
        {
            var result = LeetCode200.GetNumsOfIslands(grid);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

    }
}
