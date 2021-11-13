/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-11-2021 08:56:32
 * LastEditTime: 11-12-2021 21:24:42
 * FilePath: \CSharpLeetCodeSolution\Solution\L.72.Edit.Distance.Hard\LeetCode72.cs
 * Description: 
 */
using System;
namespace DPSolution
{

    public class LeetCode72
    {
        public static int MinDistance(string word1, string word2)
        {
            var m = word1.Length;
            var n = word2.Length;

            int[][] dp = new int[m + 1][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[n + 1];
            }

            for (int i = 1; i <= m; i++)
            {
                dp[i][0] = i;
            }

            for (int i = 1; i <= n; i++)
            {
                dp[0][i] = i;
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                    {
                        dp[i][j] = dp[i - 1][j - 1];
                    }
                    else
                    {
                        dp[i][j] = Min(
                            dp[i - 1][j] + 1,
                            dp[i][j - 1] + 1,
                            dp[i - 1][j - 1]
                        );
                    }
                }
            }

            return dp[m][n];
        }

        private static int Min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
    }

}