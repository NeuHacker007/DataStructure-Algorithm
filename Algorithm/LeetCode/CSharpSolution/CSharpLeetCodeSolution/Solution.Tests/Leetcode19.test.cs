// 
// Project: Solution.Tests
// Author:yifan zhang
// Date: 10/21/2022 7:52 PM
// Created: 10/21/2022 7:52 PM
// FileName: Leetcode19.test.cs
// Description:

using LinkedListSolution;
using NUnit.Framework;

namespace Solution.Tests;

[TestFixture]
public class Leetcode19_test
{
    [Test]
    [Category("Auxilary Test")]
    [TestCase(new int[] {1,2,3,4,5})]
    public void PrintElementsOfLists(int[] nums)
    {
        TestListData testData = new TestListData();
        foreach (var num in nums)
        {
            testData.Add(num);
        }

        var result = testData.PrintElements;
        
        Assert.That(result, Is.EqualTo("12345"));
    }
}