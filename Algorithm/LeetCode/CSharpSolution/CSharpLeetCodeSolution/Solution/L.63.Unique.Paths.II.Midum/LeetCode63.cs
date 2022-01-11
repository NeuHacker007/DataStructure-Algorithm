/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-11-2022 14:16:11
 * LastEditTime: 01-11-2022 14:24:49
 * FilePath: \CSharpLeetCodeSolution\Solution\L.63.Unique.Paths.II.Midum\LeetCode63.cs
 * Description: 
 */

namespace DPSolution
{
    public class LeetCode63
    {
        public static int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var m = obstacleGrid.Length;
            var n = obstacleGrid[0].Length;

            if (obstacleGrid[0][0] == 1) return 0;

            obstacleGrid[0][0] = 1;
            // dp[0][j]
            for (int j = 1; j < n; j++)
            {
                obstacleGrid[0][j] = obstacleGrid[0][j] == 0 && obstacleGrid[0][j - 1] == 1 ? 1 : 0;
            }
            // dp[i][0]

            for (int i = 1; i < m; i++)
            {
                obstacleGrid[i][0] = obstacleGrid[i][0] == 0 && obstacleGrid[i - 1][0] == 1 ? 1 : 0;
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (obstacleGrid[i][j] == 0)
                    {
                        obstacleGrid[i][j] = obstacleGrid[i - 1][j] + obstacleGrid[i][j - 1];
                    }
                    else
                    {
                        obstacleGrid[i][j] = 0;
                    }
                }
            }

            return obstacleGrid[m - 1][n - 1];
        }
    }
}