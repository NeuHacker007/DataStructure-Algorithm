// 
// Project: Solution.Tests
// Author:yifan zhang
// Date: 10/25/2022 8:39 AM
// Created: 10/25/2022 8:39 AM
// FileName: LeetCode22.test.cs
// Description:

using System.Collections.Generic;
using BackTrackSolution;
using NUnit.Framework;

namespace Solution.Tests;

[TestFixture]
public class LeetCode22_test
{
    [Test]
    [TestCase(3, new string[] {"((()))","(()())","(())()","()(())","()()()"})]
    [TestCase(1, new string[] {"()"})]
    public void Call_GenerateParenthesis_Should_ReturnMaxMatchedParenthesis(int n, string[] expection)
    {
        var result = LeetCode22.GenerateParenthesis(n);
        
        Assert.That(result, Is.EquivalentTo(expection));
    }
}