using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    //Given a string s, find the longest palindromic substring in s.You may assume that the maximum length of s is 1000.

    //Example 1:

    //Input: "babad"
    //Output: "bab"
    //Note: "aba" is also a valid answer.

    //Example 2:

    //Input: "cbbd"
    //Output: "bb"


    public class LeetCode5
    {
        public static string GetLongestPalindromicStr(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";

            var start = 0;
            var end = 0;
            //          b     a    b   a   d
            // Step1
            // start    |
            // end      |  
            // Step2
           
            for (int i = 0; i < str.Length; i++)
            {
                var len1 = ExpandCenter(str, i,i);
                var len2 = ExpandCenter(str, i, i + 1);
                
                var len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
                Console.WriteLine($"i = {i}, len1={len1}, len2={len2}, len={len}, start={start}, end={end}, longStr={str.Substring(start, end - start + 1)}");
            }

            return str.Substring(start, end - start + 1);
        }

        private static int ExpandCenter(string s, int left, int right)
        {
            int l = left;
            int r = right;

            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                l--;
                r++;
            }

            return r - l - 1;
        }
    }
}
