// 
// Project: Solution
// Author:yifan zhang
// Date: 11/22/2023 10:08 PM
// Created: 11/22/2023 10:08 PM
// FileName: LeetCode18.cs
// Description:

using System;
using System.Collections;
using System.Collections.Generic;

namespace Solution.L._18._4Sum.Medium;

public class LeetCode18
{
    public static IList<IList<int>> Solution(int[] nums, int target)
    {
        IList<IList<int>> result = new List<IList<int>>();
        int length = nums.Length;
        int p1 = 0;
        int p2 = 0;
        long sum = 0;
        Array.Sort(nums);
        for (p1 = 0; p1 < length - 3; p1++)
        {
            for (p2 = p1 + 1; p2 < length - 2; p2++)
            {
                int left = p2 + 1;
                int right = length - 1;

                while (left < right)
                {
                    sum = (long)nums[p1] + (long)nums[p2] + (long)nums[left] + (long)nums[right];
                    if (sum == target)
                    {
                        // add results 
                        CheckAndAdd(result, nums[p1], nums[p2], nums[left], nums[right]);
                        left++;
                        right--;
                    }
                    else if (sum > target)
                    {
                        right--;
                    }
                    else
                    {
                        left++;
                    }
                }

                while (p2 < length - 2 && nums[p2 + 1] == nums[p2])
                {
                    p2++;
                }
            }

            while (p1 < length - 3 && nums[p1 + 1] == nums[p1])
            {
                p1++;
            }
        }


        return result;
    } 
    
    private static void CheckAndAdd(IList<IList<int>> result, int a, int b, int c, int d) {
        if (result.Count == 0) {
            result.Add(new List<int> {a, b, c, d});
        }
        else if (result[result.Count-1][0] != a || result[result.Count-1][1] != b || result[result.Count-1][2] != c) {
            result.Add(new List<int> {a, b, c, d});
        }
        return;
    }
}