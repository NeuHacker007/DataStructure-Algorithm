/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 03-07-2022 08:43:22
 * LastEditTime: 03-07-2022 09:23:15
 * FilePath: \CSharpLeetCodeSolution\Solution\L.221.Maximal.Square.Medium\LeetCode221.cs
 * Description: 
 */
using System;
namespace DPSolution
{

    public class LeetCode221
    {
        public static int MaximalSquare(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            int[][] dp = new int[m + 1][];

            for (int i = 0; i <= m; i++)
            {
                dp[i] = new int[n + 1];

                for (int j = 0; j <= n; j++)
                {
                    dp[i][j] = 0;
                }
            }

            var answer = 0;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (matrix[i - 1][j - 1] == '1')
                    {
                        dp[i][j] = Math.Min(dp[i - 1][j - 1], Math.Min(dp[i][j - 1], dp[i - 1][j])) + 1;

                        answer = Math.Max(answer, dp[i][j]);
                    }
                }
            }

            return answer * answer;
        }
    }

}