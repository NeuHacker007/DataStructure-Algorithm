/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 02-02-2022 13:41:33
 * LastEditTime: 02-02-2022 20:47:53
 * FilePath: \CSharpLeetCodeSolution\Solution\L.139.Word.Brak.Medium\LeetCode139.cs
 * Description: 
 */
using System;
using System.Collections.Generic;
namespace BacktrackSoluton
{
    public class LeetCode139
    {
        public static bool WordBreak(string s, IList<string> wordDict)
        {
            bool?[] memo = new bool?[s.Length];
            return Backtrack(s, 0, memo, wordDict) ?? false;
        }

        private static bool? Backtrack(string s, int start, bool?[] memo, IList<string> wordDict)
        {
            if (s.Length == start)
            {
                return true;
            }

            if (memo[start] != null)
            {
                return memo[start];
            }

            for (int end = start + 1; end <= s.Length; end++)
            {
                if (wordDict.Contains(s.Substring(start, end - start))
                    && Backtrack(s, end, memo, wordDict).Value)
                {
                    memo[start] = true;
                    return true;
                }
            }

            memo[start] = false;
            return false;
        }
    }
}

namespace DPSolution
{
    public class LeetCode139
    {

        /*
            dp[i]: s[0 .. i] can be a word in the word Dict
                       j
            s: X X X X [X X X i]
        */
        public static bool WordBreak(string s, IList<string> wordDict)
        {
            int n = s.Length;
            bool[] dp = new bool[n + 1];
            Array.Fill(dp, false);
            dp[0] = true;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] && wordDict.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[n];

        }
    }
}