/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 02-15-2022 10:52:37
 * LastEditTime: 02-15-2022 12:45:01
 * FilePath: \CSharpLeetCodeSolution\Solution\L.198.House.Robber.Medium\LeetCode198.cs
 * Description: 
 */
using System;
namespace DPSolution
{
    public class LeetCode198
    {    /*
         dp[i]: the maximum amount of money you can rob tonight without alerting the police for room[0 .. i]

         nums: X X X X X X X X X i

         dp[i] = Max(dp[i-2] + nums[i], dp[i-1]);   
    
        */
        public static int Rob(int[] nums)
        {
            int n = nums.Length;

            if (n == 0) return 0;
            if (n == 1) return nums[0];
            int[] dp = new int[n];
            Array.Fill(dp, 0);
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < n; i++)
            {
                dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
            }
            return dp[n - 1];
        }
    }
}