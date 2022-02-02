/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-28-2022 21:34:04
 * LastEditTime: 01-29-2022 23:22:26
 * FilePath: \CSharpLeetCodeSolution\Solution\L.132.Palindrome.Partitioning.II.Hard\LeetCode132.cs
 * Description: 
 */

using System;

namespace DPSolution
{
    public class LeetCode132
    {
        /*
               0        j
            s: X X X X [X X i]
            if (IsPalindrome(j -> i) )
                dp[i] == Min(dp[i], dp[j-1] + 1);
            dp[i] : minimum number for a palindrome partitioning of s[0 .. i]
        */
        public static int MinCut(string s)
        {
            int n = s.Length;

            int[] dp = new int[n];
            Array.Fill(dp, int.MaxValue);
            dp[0] = 1; // single character is palindrome and only have 1 type of cut
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (IsPalindrome(s, j, i))
                    {
                        if (j == 0)
                        {
                            // All string is palindrome
                            dp[i] = 1;
                        }
                        else
                        {
                            dp[i] = Math.Min(dp[i], dp[j - 1] + 1);
                        }

                    }
                }
            }
            // n palindrome partion need n-1 cuts. So, we minus 1.  
            return dp[n - 1] - 1;
        }
        private static bool IsPalindrome(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[start++] != s[end--]) return false;
            }

            return true;
        }

    }
}
