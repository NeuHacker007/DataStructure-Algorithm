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
    public class LeetCode1020Tests
    {
        private static int[][] grid1 = new []
        {
            new int[]{0,0,0,0},
            new int[]{1,0,1,0},
            new int[]{0,1,1,0},
            new int[]{0,0,0,0}
        };

        private static int[][] grid2 = new[]
        {
            new int[]{0,1,1,0},
            new int[]{0,0,1,0},
            new int[]{0,0,1,0},
            new int[]{0,0,0,0}
        };

        private static Object[] numofEnclaves = new Object[]
        {
            new Object[]{grid1, 3},
            new Object[]{grid2, 0}
        };
        
        [Test]
        [TestCaseSource("numofEnclaves")]
        public void NumEnclaves_WhenCalled_ReturnNumOfEnclaves(int[][] grid, int expectedResult)
        {
            var result = LeetCode1020.NumEnclaves(grid);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
