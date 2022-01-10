/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-10-2022 13:23:31
 * LastEditTime: 01-10-2022 13:27:39
 * FilePath: \CSharpLeetCodeSolution\Solution\L.62.Unique.Paths.Meidum\LeetCode62.cs
 * Description: 
 */
namespace DPSolution
{
    public class LeetCode62
    {

        public static int UniquePaths(int m, int n)
        {
            // DP[i][j]: dp[0 .. i][0 .. j] represents number of unique paths for current i and j;
            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    dp[i][j] = 1;
                }
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                }
            }

            return dp[m - 1][n - 1];

        }
    }
}