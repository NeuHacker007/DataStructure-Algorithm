// 
// Project: Solution.Tests
// Author:yifan zhang
// Date: 12/03/2021 1:37 PM
// Created: 12/03/2021 1:37 PM
// FileName: LeetCode1254Tests.cs
// Description:

using System;
using NUnit.Framework;

namespace Solution.Tests;

[TestFixture]
public class LeetCode1254Tests
{
    private static int[][] grid1 = new[]
    {
        new int[] { 1, 1, 1, 1, 1, 1, 1, 0 },
        new int[] { 1, 0, 0, 0, 0, 1, 1, 0 },
        new int[] { 1, 0, 1, 0, 1, 1, 1, 0 },
        new int[] { 1, 0, 0, 0, 0, 1, 0, 1 },
        new int[] { 1, 1, 1, 1, 1, 1, 1, 0 }
    };

    private static int[][] grid2 = new[]
    {
        new int[] { 0, 0, 1, 0, 0 },
        new int[] { 0, 1, 0, 1, 0 },
        new int[] { 0, 1, 1, 1, 0 }
    };

    private static int[][] grid3 = new[]
    {
        new int[] { 1, 1, 1, 1, 1, 1, 1 },
        new int[] { 1, 0, 0, 0, 0, 0, 1 },
        new int[] { 1, 0, 1, 1, 1, 0, 1 },
        new int[] { 1, 0, 1, 0, 1, 0, 1 },
        new int[] { 1, 0, 1, 1, 1, 0, 1 },
        new int[] { 1, 0, 0, 0, 0, 0, 1 },
        new int[] { 1, 1, 1, 1, 1, 1, 1 }
    };

    private static int[][] grid4 = new[]
    {
        new int[] { 1, 1, 1, 1, 1, 1, 1 },
        new int[] { 1, 1, 1, 1, 1, 1, 1 },
        new int[] { 1, 1, 1, 1, 1, 1, 1 },
        new int[] { 1, 1, 1, 1, 1, 1, 1 },
        new int[] { 1, 1, 1, 1, 1, 1, 1 },
        new int[] { 1, 1, 1, 1, 1, 1, 1 }
    };

    private static int[][] grid5 = new[]
    {
        new int[] { 0, 0, 0, 0, 0, 0, 0 },
        new int[] { 0, 0, 0, 0, 0, 0, 0 },
        new int[] { 0, 0, 0, 0, 0, 0, 0 },
        new int[] { 0, 0, 0, 0, 0, 0, 0 },
        new int[] { 0, 0, 0, 0, 0, 0, 0 },
        new int[] { 0, 0, 0, 0, 0, 0, 0 }

    };

    private static Object[] numOfCloseIslandCases =
    {
        new Object[] { grid1, 2},
        new Object[] { grid2, 1},
        new Object[] { grid3, 2},
        new Object[] { grid4, 0},
        new Object[] { grid5, 0},

    };

    [Test]
    [TestCaseSource("numOfCloseIslandCases")]
    public void ClosedIsland_WhenCalled_ReturnNumOfClosedIlands(int[][] grid, int expectedResult)
    {
        var result = DFSSolution.LeetCode1254.ClosedIsland(grid);

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}