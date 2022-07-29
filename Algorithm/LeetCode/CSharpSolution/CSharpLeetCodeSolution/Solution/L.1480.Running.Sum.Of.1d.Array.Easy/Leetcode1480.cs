/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 07-29-2022 16:48:34
 * LastEditTime: 07-29-2022 16:50:42
 * FilePath: \CSharpLeetCodeSolution\Solution\L.1480.Running.Sum.Of.1d.Array.Easy\Leetcode1480.cs
 * Description: 
 */

using System;

namespace LeetCode75Plan
{
    public class LeetCode1480
    {
        public static int[] RunningSum(int[] nums)
        {
            if (nums.Length <= 0) return new int[0];

            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] += nums[i - 1];
            }

            return nums;
        }
    }
}

