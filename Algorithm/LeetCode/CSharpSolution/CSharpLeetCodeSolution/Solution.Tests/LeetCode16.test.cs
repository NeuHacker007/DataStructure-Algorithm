// 
// Project: Solution.Tests
// Author:yifan zhang
// Date: 10/18/2022 11:09 AM
// Created: 10/18/2022 11:09 AM
// FileName: LeetCode16.test.cs
// Description:

using NUnit.Framework;
using TwoPointerSolution;

namespace Solution.Tests;

[TestFixture]
public class LeetCode16_test
{
    [Test]
    [TestCase(new int[] {-1,2,1,-4}, 1, 2)]
    [TestCase(new int[] {0,0,0}, 1, 0)]
    public void Call_Solution1_ShouldReturn_SumOf3NumsClosestToTarget(int[] nums, int target, int expectedResult)
    {
        int result = LeetCode16.Solution1(nums, target);
        
        Assert.That(result == expectedResult);
    }
}