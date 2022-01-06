/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-05-2022 21:10:39
 * LastEditTime: 01-05-2022 21:47:18
 * FilePath: \CSharpLeetCodeSolution\Solution\L.10.Regular.Expression.Matching.Hard\LeetCode10.cs
 * Description: 
 */


/*
 dp[i][j]: whether s[0..i] and p[0..j] matched

 s: X X X X X X       i
 p: Y Y Y Y Y  j

 Scenario 1: p[5] is alpha and s[5] == p[5]
    s: X X X X X X       i only Alpha letters
       0 1 2 3 4 5
    p: Y Y Y Y Y Y       j
       0 1 2 3 4 5
  
    if the both p and s' last position is the same,
    then the trueness are determined by its previous trueness
    ie p[0 .. 4] == s[0 .. 4]
    
    dp[i][j] = dp[i - 1][j - 1] && s[i] == p[j];

scenario 2: p[5] is '.'
    s:  X X X X X X       i only Alpha letters
        0 1 2 3 4 5
    p:  Y Y Y Y Y .       j
        0 1 2 3 4 5

    dp[i][j] == dp[i - 1][j - 1];

scenario 3: p[5] is '*'

Possible 1: 
    s[5] == p[4] 
    s:  X X X X X Z       i only Alpha letters
        0 1 2 3 4 5
    p:  Y Y Y Y Z *       j
        0 1 2 3 4 5
or  p[4] = '.'
    s:  X X X X X Z       i only Alpha letters
        0 1 2 3 4 5
    p:  Y Y Y Y . *       j
        0 1 2 3 4 5
    dp[i][j] == s[i] == p[j-1] || p[j-1] == '.'

Possible 2: 
    * reprezents 0 
    s:  X X X X X Z       i only Alpha letters
        0 1 2 3 4 5
    p:  Y Y Y Y 0 0        j
        0 1 2 3 4 5
    
    if this is the case, then we need consider 
    whether s[0 .. 5] and p[0 .. 3] matches 
    dp[i][j] = dp[i - 1][j] 
*/

namespace DPSolution
{
    public class LeetCode10
    {
        public static bool IsMatch(string s, string p)
        {
            var m = s.Length;
            var n = p.Length;

            bool[][] dp = new bool[m + 1][];

            for (int i = 0; i < m + 1; i++)
            {
                dp[i] = new bool[n + 1];

                for (int j = 0; j < n + 1; j++)
                {
                    dp[i][j] = false;
                }
            }

            s = "#" + s;
            p = "#" + p;
            /* 
                dp[0][0] = true;
                    s: 
                    p: 
                dp[0][j] only in below case s and p are match
                    s: 
                    p: Y * Y * Y * Y * 
            */

            dp[0][0] = true;

            for (int j = 2; j <= n; j++)
            {
                dp[0][j] = p[j] == '*' && dp[0][j - 2];
            }
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (char.IsLetter(p[j]))
                    {
                        dp[i][j] = s[i] == p[j] && dp[i - 1][j - 1];
                    }
                    else if (p[j] == '.')
                    {
                        dp[i][j] = dp[i - 1][j - 1];
                    }
                    else if (p[j] == '*')
                    {
                        var possible1 = (s[i] == p[j - 1] || p[j - 1] == '.') && dp[i - 1][j];
                        var possible2 = dp[i][j - 2];
                        dp[i][j] = possible1 || possible2;
                    }
                }
            }
            return dp[m][n];
        }
    }
}