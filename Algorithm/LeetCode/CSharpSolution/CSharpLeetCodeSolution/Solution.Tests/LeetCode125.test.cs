// Project: Solution.Tests
// Author:yfeva
// Date: 04/30/2024 20:04
// Created: 04/30/2024 20:04
// FileName: LeetCode125.test.cs
// Description:

using NUnit.Framework;
using Solution.L._125.ValidPalinarome.Easy;

namespace Solution.Tests;

[TestFixture]
public class LeetCode125_test
{
    [TestCase("")]
    [TestCase("A man, a plan, a canal: Panama")]
    public void IsPalindrome_ShouldReturnTrue(string s)
    {
       var result =  LeetCode125.IsPalindrome(s);
       Assert.IsTrue(result);
    }
    [TestCase("race a car")]
    public void IsPalindrome_ShouldReturnFalse(string s)
    {
        var result =  LeetCode125.IsPalindrome(s);
        Assert.IsFalse(result);
    }
}