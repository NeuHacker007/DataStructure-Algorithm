/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-25-2022 14:46:36
 * LastEditTime: 01-25-2022 15:07:16
 * FilePath: \CSharpLeetCodeSolution\Solution\L.122.Best.Tiime.To.Buy.And.Sell.Stock.II.Medium\LeetCode122.cs
 * Description: 
 */
using System;
namespace DPSolution
{
    public class LeetCode122
    {
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            int hold = -prices[0];
            int notHold = 0;

            foreach (var price in prices)
            {
                var sell = hold + price;

                hold = Math.Max(notHold - price, hold);
                notHold = Math.Max(notHold, sell);
                maxProfit = Math.Max(hold, notHold);
            }

            return maxProfit;
        }
    }
}

namespace Solution
{
    public class LeetCode122
    {
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }

            return maxProfit;
        }
    }
}