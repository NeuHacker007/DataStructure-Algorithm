using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFSSolution;
using NUnit.Framework;

namespace Solution.Tests
{
    [TestFixture]
    public class LeetCode1905Tests
    {
        private static int[][] input1Grid1 = new[]
        {
            new int[] { 1, 1, 1, 0, 0 },
            new int[] { 0, 1, 1, 1, 1 },
            new int[] { 0, 0, 0, 0, 0 },
            new int[] { 1, 0, 0, 0, 0 },
            new int[] { 1, 1, 0, 1, 1 }
        };

        private static int[][] input1Grid2 = new[]
        {
            new int[] { 1, 1, 1, 0, 0 },
            new int[] { 0, 0, 1, 1, 1 },
            new int[] { 0, 1, 0, 0, 0 },
            new int[] { 1, 0, 1, 1, 0 },
            new int[] { 0, 1, 0, 1, 0 },
        };

        private static int[][] input2Grid1 = new[]
        {
            new int[] { 1,0,1,0,1 },
            new int[] { 1,1,1,1,1 },
            new int[] { 0,0,0,0,0 },
            new int[] { 1,1,1,1,1 },
            new int[] {1,0,1,0,1 }
        };

        private static int[][] input2Grid2 = new[]
        {
            new int[] { 0,0,0,0,0 },
            new int[] {1,1,1,1,1 },
            new int[] { 0,1,0,1,0 },
            new int[] { 0,1,0,1,0 },
            new int[] { 1,0,0,0,1 },
        };


        private static Object[] countSubIslands =
        {
            new Object[] { input1Grid1, input1Grid2, 3},
            new Object[] { input2Grid1, input2Grid2, 2},

        };

        [Test]
        [TestCaseSource("countSubIslands")]
        public void CountSubIslands(int[][] grid1, int[][] grid2, int expectedResult)
        {
            var result = LeetCode1905.CountSubIslands(grid1, grid2);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
