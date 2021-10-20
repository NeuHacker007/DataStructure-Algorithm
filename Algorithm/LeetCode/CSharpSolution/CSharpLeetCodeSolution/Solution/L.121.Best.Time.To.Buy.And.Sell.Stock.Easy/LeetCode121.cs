/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-19-2021 21:46:08
 * LastEditTime: 10-19-2021 21:54:38
 * FilePath: \CSharpLeetCodeSolution\Solution\L.121.Best.Time.To.Buy.And.Sell.Stock.Easy\LeetCode121.cs
 * Description: 
 */

using System;
namespace DPSolution
{
    public class LeetCode121
    {
        public static int MaxProfit(int[] prices)
        {
            var dp = new int[prices.Length, 2];

            for (int i = 0; i < prices.Length; i++)
            {
                if (i - 1 == -1)
                {
                    dp[i, 0] = 0;
                    dp[i, 1] = -prices[i];
                    continue;
                }

                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], -prices[i]);
            }

            return dp[prices.Length - 1, 0];
        }

        public static int MaxProfit2(int[] prices)
        {
            var minPrices = int.MaxValue;
            var maxProfix = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrices)
                {
                    minPrices = prices[i];
                }
                else if (prices[i] - minPrices > maxProfix)
                {
                    maxProfix = prices[i] - minPrices;
                }
            }
            return maxProfix;
        }
    }
}