/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-19-2022 14:37:27
 * LastEditTime: 01-19-2022 14:53:48
 * FilePath: \CSharpLeetCodeSolution\Solution\L.115.Distinct.Subsequences.Hard\LeetCode115.cs
 * Description: 
 */


namespace DPSolution
{
    public class LeetCode115
    {
        public static int NumDistinct(string s, string t)
        {
            var m = s.Length;
            var n = t.Length;
            s = "#" + s;
            t = "#" + t;
            int[][] dp = new int[m + 1][];

            for (int i = 0; i < m + 1; i++)
            {
                dp[i] = new int[n + 1];
                for (int j = 0; j < n + 1; j++)
                {
                    dp[i][j] = 0;
                }
            }
            dp[0][0] = 1; // s: t: => 1
            // dp[0][j] s: t: YYYYY => 0
            // dp[i][0] s: XXXX t: 
            for (int i = 0; i < n; i++)
            {
                dp[i][0] = 1;
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s[i] == t[j])
                    {
                        dp[i][j] += dp[i - 1][j - 1];
                    }
                    dp[i][j] += dp[i - 1][j];
                }
            }
            return dp[m][n];
        }
    }

    /*
        dp[i][j]: nums of subsequence of s[0 .. i] equals t[0 .. j]

        s: X X X X X X X i
        t: Y Y Y Y Y Y j

        if (s[i] == t[j]) {
            dp[i][j] += dp[i-1][j-1];
        }

        dp[i][j] += dp[i-1][j];
    */
}
