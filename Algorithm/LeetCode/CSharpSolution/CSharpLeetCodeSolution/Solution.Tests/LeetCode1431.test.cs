// Project: Solution.Tests
// Author:yfeva
// Date: 05/04/2024 11:05
// Created: 05/04/2024 11:05
// FileName: LeetCode1431.test.cs
// Description:

using System.Collections.Generic;
using NUnit.Framework;
using Solution.L._1431.KidsWithTheGreatestNumberOfCandies.Easy;

namespace Solution.Tests;

[TestFixture]
public class LeetCode1431_test
{
    [TestCase(new int[] {2,3,5,1,3}, 3, new bool[]{true,true,true,false, true})]
    [TestCase(new int[] {4,2,1,1,2}, 1, new bool[]{true,false,false,false, false})]
    [TestCase(new int[] {12,1,12}, 10, new bool[]{true,false,true})]
    public void Leecode1431_KidsWithCandies_ShouldReturnCorrectBooleanList(
        int[] candies, 
        int extraCandies, 
        bool[] expectedResult)
    {

        var result = LeetCode1431.KidsWithCandies(candies, extraCandies);
        
        CollectionAssert.AreEqual(expectedResult, result);
    }
}