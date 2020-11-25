using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public class LeetCode763
    {
        //A string S of lowercase English letters is given.We want to partition
        //this string into as many parts as possible so that each letter appears in at most one part,
        //and return a list of integers representing the size of these parts.
        //    Example 1:
        //Input: S = "ababcbacadefegdehijhklij"
        //Output: [9,7,8]
        //Explanation:
        //The partition is "ababcbaca", "defegde", "hijhklij".
        //This is a partition so that each letter appears in at most one part.
        //    A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits S into less parts.
        //    Note:
        //S will have length in range[1, 500].
        //S will consist of lowercase English letters ('a' to 'z') only.

        public static IList<int> PartitionLabels(string str)
        {
            var last = new int[26];

            for (int i = 0; i < str.Length; ++i)
            {
                last[str[i] - 'a'] = i;
            }

            List<int> ans = new List<int>();

            var startPos = 0;
            var endPos = 0;


            for (int i = 0; i < str.Length; ++i)
            {
                endPos = Math.Max(endPos, last[str[i] - 'a']);

                if (i == endPos)
                {
                    ans.Add(i - startPos + 1);
                    startPos = i + 1;
                }
            }

            return ans;

        }
    }
}
