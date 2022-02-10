/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 02-09-2022 13:34:14
 * LastEditTime: 02-10-2022 09:29:07
 * FilePath: \CSharpLeetCodeSolution\Solution\L.174.Dungeon.Game.Hard\LeetCode174.cs
 * Description: 
 */
using System;
namespace DPSolution
{
    public class LeetCode174
    {
        public static int CalculateMinimumHP(int[][] dungeon)
        {
            int m = dungeon.Length;
            int n = dungeon[0].Length;

            int[][] dp = new int[m][];

            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    dp[i][j] = 1;
                }
            }

            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (i == m - 1 && j == n - 1)
                    {
                        dp[m - 1][n - 1] = 1;
                    }
                    else if (i == m - 1)
                    {
                        dp[i][j] = dp[i][j + 1] - dungeon[i][j + 1];
                    }
                    else if (i == n - 1)
                    {
                        dp[i][j] = dp[i + 1][j] - dungeon[i + 1][j];
                    }
                    else
                    {
                        dp[i][j] = Math.Min(dp[i][j + 1] - dungeon[i][j + 1], dp[i + 1][j] - dungeon[i + 1][j]);
                    }

                    dp[i][j] = Math.Max(dp[i][j], 1);

                }
            }

            dp[0][0] = dp[0][0] - dungeon[0][0];

            dp[0][0] = Math.Max(dp[0][0], 1);

            return dp[0][0];
        }
    }
}