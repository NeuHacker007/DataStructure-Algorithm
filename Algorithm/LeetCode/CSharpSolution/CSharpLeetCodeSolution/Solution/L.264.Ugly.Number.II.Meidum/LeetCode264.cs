/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 02-28-2022 14:46:05
 * LastEditTime: 02-28-2022 15:04:15
 * FilePath: \CSharpLeetCodeSolution\Solution\L.264.Ugly.Number.II.Meidum\LeetCode264.cs
 * Description: 
 */
using System;
namespace DPSolution
{
    public class LeetCode264
    {
        /*
         dp[i] : the ith ugly number 
         
         dp[i] = Min(dp[i] * 2, dp[i] * 3, dp[i] * 5)
        */
        public static int NthUglyNumber(int n)
        {
            int[] dp = new int[n];
            dp[0] = 1;
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            for (int i = 1; i < n; i++)
            {
                dp[i] = Math.Min(dp[p1] * 2, Math.Min(dp[p2] * 3, dp[p3] * 5));
                if (dp[p1] * 2 == dp[i])
                {
                    p1++;
                }
                if (dp[p2] * 3 == dp[i])
                {
                    p2++;
                }
                if (dp[p3] * 5 == dp[i])
                {
                    p3++;
                }
            }

            return dp[n - 1];
        }
    }

}