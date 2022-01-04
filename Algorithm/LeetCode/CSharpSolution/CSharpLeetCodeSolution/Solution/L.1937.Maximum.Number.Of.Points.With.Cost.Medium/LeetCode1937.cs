/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-03-2022 20:08:20
 * LastEditTime: 01-03-2022 20:47:41
 * FilePath: \CSharpLeetCodeSolution\Solution\L.1937.Maximum.Number.Of.Points.With.Cost.Medium\LeetCode1937.cs
 * Description: 
 */
using System;
namespace DPSolution
{
    public class LeetCode1937
    {
        public long MaxPoints(int[][] points)
        {
            var rowLength = points.Length;
            var colLength = points[0].Length;

            var dp = new long[rowLength][];

            for (int row = 0; row < rowLength; row++)
            {
                dp[row] = new long[colLength];

                for (int col = 0; col < colLength; col++)
                {
                    dp[row][col] = int.MinValue;
                }
            }

            for (int col = 0; col < colLength; col++)
            {
                dp[0][col] = points[0][col];
            }

            for (int row = 1; row < rowLength; row++)
            {
                var rollingMax = long.MinValue;

                for (int col = 0; col < colLength; col++)
                {
                    rollingMax = Math.Max(rollingMax, dp[row - 1][col] + col);
                    dp[row][col] = Math.Max(dp[row][col], rollingMax + points[row][col] - col);
                }
                rollingMax = long.MinValue;
                for (int col = colLength - 1; col >= 0; col--)
                {
                    rollingMax = Math.Max(rollingMax, dp[row - 1][col] - col);
                    dp[row][col] = Math.Max(dp[row][col], rollingMax + points[row][col] + col);
                }
            }
            var result = long.MinValue;
            for (int col = 0; col < colLength; col++)
            {
                result = Math.Max(result, dp[rowLength - 1][col]);
            }
            return result;
        }
    }

}