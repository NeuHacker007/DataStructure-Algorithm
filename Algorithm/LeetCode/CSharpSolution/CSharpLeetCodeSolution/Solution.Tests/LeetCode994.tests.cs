using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Solution.Tests
{
    public class LeetCode994Tests
    {
 
        [Theory]
        [ClassData(typeof(OrangeRottingTestData))]
        public void OrangeRotting_WhenCalled_ReturnRottenElapseTime(int[][] grid, int expectedResult)
        {
            var result = LeetCode994.OrangeRotting(grid);

            Assert.Equal(expectedResult, result);
        }
    }

    public class OrangeRottingTestData : IEnumerable<object[]>
    {
        readonly int[][] testCase1 = new int[][]
        {
            new int[] {2, 1, 1},
            new int[] {1, 1, 0},
            new int[] {0, 1, 1},
        };

        readonly int[][] testCase2 = new int[][]
        {
            new int[] {2, 1, 1},
            new int[] {0, 1, 1},
            new int[] {1, 0, 1},
        };

        readonly int[][] testCase3 = new int[][]
        {
            new int[] {0,2},
        };
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]{testCase1, 4};
            yield return new object[]{testCase2, -1};
            yield return new object[]{testCase3, 0};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
