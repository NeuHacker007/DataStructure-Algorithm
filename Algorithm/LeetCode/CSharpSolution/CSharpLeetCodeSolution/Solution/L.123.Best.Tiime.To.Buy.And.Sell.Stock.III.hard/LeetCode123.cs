/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-25-2022 18:01:48
 * LastEditTime: 01-25-2022 21:20:26
 * FilePath: \CSharpLeetCodeSolution\Solution\L.123.Best.Tiime.To.Buy.And.Sell.Stock.III.hard\LeetCode123.cs
 * Description: 
 */
using System;
namespace DPSolution
{
    public class LeetCode123
    {
        /*
            i： 第 i 天
            1. 第i天 我已经买入1只股票 要么是刚买的 要么是之前买的
                                今天刚买的       之前买的
                hold1[i]  = max(0 - price[i]，hold1[i-1])
            2. 第i天 我已经卖了1只股票
                                今天刚卖的               之前卖的 
                sold1[i] = max(hold1[i -1] + price[i], sold[i-1])
            3. 第i天 我已经买入第二只股票
                                之前卖出，今天买入       之前一直持有，什么都不做      
                hold2[i] = max(sold1[i-1] - price[i], hold2[i-1])
            4. 第i天 我卖掉第二只股票
                               前一天还持有，今天卖了 ， 之前就卖了
                sold2[i] = max(hold2[i-1] + price[i], sold2[i-1])

            最后一天
                  max（sold1， sold2）；
        */
        public static int MaxProfit(int[] prices)
        {
            int hold1 = int.MinValue; // 如果hold1 初始为0 那么Math.Max(0 - price, hold1_tmp) 会取到 0 但是刚开始买第一只股票收益应当是 -price。所以此处应当初始为 负无穷大
            int hold2 = int.MinValue; // 同上
            int sold1 = 0;
            int sold2 = 0;

            foreach (var price in prices)
            {
                int hold1_tmp = hold1;
                int sold1_tmp = sold1;
                int hold2_tmp = hold2;
                int sold2_tmp = sold2;

                hold1 = Math.Max(0 - price, hold1_tmp);
                sold1 = Math.Max(hold1 + price, sold1_tmp);
                hold2 = Math.Max(sold1 - price, hold2_tmp);
                sold2 = Math.Max(hold2 + price, sold2_tmp);
            }

            return Math.Max(sold1, sold2);
        }
    }
}