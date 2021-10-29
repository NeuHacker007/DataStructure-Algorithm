/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-29-2021 13:16:54
 * LastEditTime: 10-29-2021 13:42:01
 * FilePath: \CSharpLeetCodeSolution\Solution\L.828.Count.Unique.Characters.of.All.Substrings.of.a.General.String.Hard\leetcode828.cs
 * Description: 
 */

namespace DPSolution
{
    public class LeetCode828
    {
        public static int UniqueLetterString(string s)
        {
            var res = 0;
            if (string.IsNullOrEmpty(s)) return res;

            // lastShowPosition[i] represents the last showing position of char x before i
            var lastShowPosition = new int[26];
            // keeps track of how many substrings ending in s[i] have s[i] as unique value
            var contribution = new int[26];
            // Current sum of unique char for current S[i];
            var curr = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var currIndex = s[i] - 'A'; // get 0-26 index;
                curr -= contribution[currIndex];
                contribution[currIndex] = i + 1 - lastShowPosition[currIndex];
                curr += contribution[currIndex];
                lastShowPosition[currIndex] = i + 1;

                res += curr;
            }
            return res;
        }
    }

}