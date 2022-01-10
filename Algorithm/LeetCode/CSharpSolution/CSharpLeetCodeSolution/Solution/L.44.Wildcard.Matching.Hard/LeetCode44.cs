/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-09-2022 20:53:58
 * LastEditTime: 01-09-2022 21:10:02
 * FilePath: \CSharpLeetCodeSolution\Solution\L.44.Wildcard.Matching.Hard\LeetCode44.cs
 * Description: 
 */

namespace DpSolution
{
    public class LeetCode44
    {
        public static bool IsMatch(string s, string p)
        {
            var m = s.Length;
            var n = p.Length;
            s = "#" + s;
            p = "#" + p;

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
            for (int j = 1; j <= n; j++)
            {
                if (p[j] != '*') break;
                dp[0][j] = true;
            }

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (p[j] == '?')
                    {
                        dp[i][j] = dp[i - 1][j - 1];
                    }
                    else if (p[j] == '*')
                    {
                        // This for loop can be optimized 
                        // by below DP formular using recursion thoughts
                        // for (int k = 0; k <= i; k++)
                        // {
                        //     if (dp[k][j - 1]) dp[i][j] = true;
                        // }
                        // if p doesn't use *, then 
                        // we need check whether i and j -1 position is match or not
                        bool possible1 = dp[i][j - 1];
                        // if p use '*' 
                        bool possible2 = dp[i - 1][j];
                        dp[i][j] = possible1 || possible2;
                    }
                    else if (s[i] == p[j])
                    {
                        dp[i][j] = dp[i - 1][j - 1];
                    }
                }
            }

            return dp[m][n];
        }
    }
}