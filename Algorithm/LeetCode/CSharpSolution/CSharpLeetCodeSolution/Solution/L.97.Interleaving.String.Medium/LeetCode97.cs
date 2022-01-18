/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-18-2022 13:16:21
 * LastEditTime: 01-18-2022 13:40:05
 * FilePath: \CSharpLeetCodeSolution\Solution\L.97.Interleaving.String.Medium\LeetCode97.cs
 * Description: 
 */
namespace DPSolution
{
    public class LeetCode97
    {
        /*
            s1: X X X X X i
            s2: Y Y Y Y Y Y Y j

            s3: Z Z Z Z Z Z Z Z
         
         dp[i][j] : whether s3[0: i + j] is formed by the interleaving of s1[0 .. i] and s2[0 .. j];
        */
        public static bool IsInterleave(string s1, string s2, string s3)
        {
            var m = s1.Length;
            var n = s2.Length;
            var l = s3.Length;

            if (m + n != l) return false;

            s1 = "#" + s1;
            s2 = "#" + s2;
            s3 = "#" + s3;

            bool[][] dp = new bool[m + 1][];

            for (int i = 0; i < m + 1; i++)
            {
                dp[i] = new bool[n + 1];
                for (int j = 0; j < n + 1; j++)
                {
                    dp[i][j] = false;
                }
            }
            dp[0][0] = true;

            for (int i = 1; i <= m; i++)
            {
                dp[i][0] = s1[i] == s3[i] && dp[i - 1][0];
            }

            for (int j = 1; j <= n; j++)
            {
                dp[0][j] = s1[j] == s3[j] && dp[0][j - 1];
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s1[i] == s3[i + j] && dp[i - 1][j] == true)
                    {
                        dp[i][j] = true;
                    }
                    else if (s2[j] == s3[i + j] && dp[i][j - 1] == true)
                    {
                        dp[i][j] = true;
                    }
                }
            }

            return dp[m][n];
        }
    }

}