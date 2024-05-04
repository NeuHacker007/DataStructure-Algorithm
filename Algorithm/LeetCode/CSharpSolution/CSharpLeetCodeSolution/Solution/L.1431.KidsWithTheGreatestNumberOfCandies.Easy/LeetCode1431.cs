// Project: Solution
// Author:yfeva
// Date: 05/04/2024 11:05
// Created: 05/04/2024 11:05
// FileName: LeetCode1431.cs
// Description:

using System.Collections.Generic;
using System.Linq;

namespace Solution.L._1431.KidsWithTheGreatestNumberOfCandies.Easy;

public class LeetCode1431
{
    public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        int maxCandies = candies.Max();
        IList<bool> results = new List<bool>(candies.Length);
        foreach (var candy in candies)
        {
            results.Add(candy + extraCandies >= maxCandies);
        }
        
        return results;
    }
}