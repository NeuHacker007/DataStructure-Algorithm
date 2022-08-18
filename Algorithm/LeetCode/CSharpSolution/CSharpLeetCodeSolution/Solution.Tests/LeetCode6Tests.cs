// 
// Project: Solution.Tests
// Author:yifan zhang
// Date: 08/17/2022 9:10 PM
// Created: 08/17/2022 9:10 PM
// FileName: LeetCode6Tests.cs
// Description:
using NUnit;
using NUnit.Framework;

namespace Solution.Tests;

[TestFixture]
public class LeetCode6Tests
{
    [TestCase("PAYPALISHIRING",3, "PAHNAPLSIIGYIR")]
    [TestCase("PAYPALISHIRING",4, "PINALSIGYAHRPI")]
    [TestCase("PAYPALISHIRING",1, "PAYPALISHIRING")]
    public void ZigZag_Convert(string s, int rowNums, string expected)
    {
        var result = LeetCode6.Convert(s, rowNums);
        
        Assert.That(result, Is.EqualTo(expected));
    }
}