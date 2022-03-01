/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 02-28-2022 20:48:10
 * LastEditTime: 02-28-2022 21:34:25
 * FilePath: \CSharpLeetCodeSolution\Solution\L.313.Super.Ugly.Number.Medium\LeetCode313.cs
 * Description: 
 */

using System;
namespace DPSolution
{
    public class LeetCode313
    {
        public static int NthSuperUglyNumber(int n, int[] primes)
        {
            int m = primes.Length;
            int[] index = new int[m];
            int[] dp = new int[n];


            for (int i = 1; i < n; i++)
            {
                int min = int.MaxValue;

                for (int j = 0; j < m; j++)
                {
                    min = Math.Min(min, dp[index[j]] * primes[j]);
                }

                dp[i] = min;

                for (int j = 0; j < m; j++)
                {
                    if (dp[i] == dp[index[j]] * primes[j])
                    {
                        index[j]++;
                    }
                }
            }
            return dp[n - 1];
        }
    }
}