/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-09-2021 16:28:44
 * LastEditTime: 11-09-2021 16:45:27
 * FilePath: \CSharpLeetCodeSolution\Solution\L.322.Coin.Change.Medium\LeetCode322.cs
 * Description: 
 */

using System;

namespace DPSolution
{
    public class LeetCode322
    {
        public static int CoinChange(int[] coins, int amount)
        {
            var dp = new int[amount + 1];
            Array.Fill(dp, amount + 1);
            dp[0] = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                foreach (var coin in coins)
                {
                    if (i - coin < 0) continue;
                    dp[i] = Math.Min(dp[i], 1 + dp[i - coin]);
                }

            }

            return (dp[amount] == amount + 1) ? -1 : dp[amount];
        }
    }
}