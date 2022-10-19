/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-18-2022 21:38:19
 * LastEditTime: 10-18-2022 21:38:20
 * FilePath: \CSharpLeetCodeSolution\Solution\L.259.3Sum.Smaller.Medium\LeetCode259.cs
 * Description: 
 */

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using DPSolution;

namespace TwoPointerSolution;

public class LeetCode259
{
    public static int Solution1(int[] nums, int target)
    {
        int size = nums.Length;
        if (size < 3)
        {
            return 0;
        }
        
        Array.Sort(nums);

        int count = 0;

        int i = 0;

        while (i < size - 2)
        {
            if (nums[i] + nums[i + 1] + nums[i + 2] >= target)
            {
                break;
            }

            int lo = i + 1;
            int hi = size - 1;

            while (lo < hi)
            {
                int sum = nums[i] + nums[lo] + nums[hi];
                if (sum < target)
                {
                    count += hi - lo;
                    lo++;
                }
                else
                {
                    hi--;
                }
            }
            
            i++;

        }
        return count;
    }

    public static int Solution2(int[] nums, int target)
    {
        Array.Sort(nums);
        int result = 0;
        for (int i = 0; i < nums.Length - 2; i++)
        {
            result += Helper(nums, i + 1, target - nums[i]);
        }
        return result;
    }

    private static int Helper(int[] nums, int startIndex, int target)
    {
        int sum = 0;

        int lo = startIndex;
        int hi = nums.Length - 1;

        while (lo < hi)
        {
            if (nums[lo] + nums[hi] < target)
            {
                sum += hi - lo;
                lo++;
            }
            else
            {
                hi--;
            }
        }

        return sum;
    }
}

