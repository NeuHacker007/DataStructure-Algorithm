/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 02-03-2022 14:02:35
 * LastEditTime: 02-03-2022 15:23:35
 * FilePath: \CSharpLeetCodeSolution\Solution\L.53.Maximum.Subarray.Easy\LeetCode53.cs
 * Description: 
 */

using System;
namespace DPSolution
{
    public class LeetCode53
    {
        // dp[i]: Max sum of contiguous Subarray of Nums[0 .. i]
        public static int MaxSubArray(int[] nums)
        {
            int n = nums.Length;
            int[] dp = new int[n];
            dp[0] = nums[0];
            int result = nums[0];

            for (int i = 1; i < n; i++)
            {
                dp[i] = Math.Max(nums[i], dp[i - 1] + nums[i]);
                result = Math.Max(result, dp[i]);
            }
            return result;
        }
    }
}