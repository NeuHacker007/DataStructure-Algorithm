/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 02-14-2022 13:20:22
 * LastEditTime: 02-14-2022 13:44:18
 * FilePath: \CSharpLeetCodeSolution\Solution\L.188.Best.Time.To.Buy.And.Sell.Stock.IV.Hard\LeetCode188.cs
 * Description: 
 */
using System;
namespace DPSolution
{
    public class LeetCode188
    {
        public int MaxProfit(int k, int[] prices)
        {
            /*
                stock Price: X X X X X X i
                 
                DP[i][k]: on the ith day, we complete the K transactions, the maxmium profit. 
                
                ** A complete transaction includes both sell and hold operation

                For each day, we have 2 options, sell or hold so 
                
                Choice 1: Sell
                    sold[i -1][k] : on the i-1 th day, we aready completed K transactions, 
                                    so on i th day, we don't need to do anything

                    or 
                    
                    hold[i-1][k-1] + prices[i] : on the i-1 th day, we still held 1 stock,
                                                 and on the i th day, we sell it. 

                    sold[i][k] = Max(sold[i-1][k], hold[i-1][k-1] + prices[i]);
                Choice 2: Hold
                    hold[i-1][k]: on the i-1 th day, we aready completed K transactions, 
                                  so on i th day, we don't need to do anything
                    or
                    sold[i-1][k] - prices[i]: on the i-1 th day, we aready completed K transactions, 
                                              so on i th day, we hold a stock
                 hold[i][k] = Max(hold[i-1][k], sold[i-1][k] - prices[i]);
                
                return Max(sold[n-1][k]) k -> 0 ... k
            */

            int n = prices.Length;

            int[] hold = new int[k + 1];
            int[] sold = new int[k + 1];

            Array.Fill(hold, int.MinValue / 2);
            Array.Fill(sold, int.MinValue / 2);


            for (int i = 0; i < n; i++)
            {
                int[] hold_old = hold;
                int[] sold_old = sold;

                for (int j = 1; j <= k; j++)
                {
                    sold[j] = Math.Max(sold_old[j], hold_old[j] + prices[i]);
                    hold[j] = Math.Max(hold_old[j], sold[j - 1] - prices[i]);
                }

            }

            int result = int.MinValue;

            for (int j = 0; j <= k; j++)
            {
                result = Math.Max(result, sold[j]);
            }

            return result;
        }
    }
}