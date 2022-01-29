/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-27-2022 09:28:28
 * LastEditTime: 01-28-2022 21:27:16
 * FilePath: \CSharpLeetCodeSolution\Solution\L.131.Palindrome.Partitioning.Medium\LeetCode131.cs
 * Description: 
 */
using System.Collections.Generic;
namespace DFSSolution
{
    public class LeetCode131
    {
        private static IList<IList<string>> result = new List<IList<string>>();
        public static IList<IList<string>> Partition(string s)
        {
            Helper(s, 0, new List<string>());
            return result;
        }

        private static void Helper(string s, int start, IList<string> currentList)
        {
            if (start == s.Length)
            {
                result.Add(new List<string>(currentList));
                return;
            }

            for (int end = start; end < s.Length; end++)
            {
                if (IsPalindrome(s, start, end))
                {
                    currentList.Add(s.Substring(start, end - start + 1));
                    Helper(s, end + 1, currentList);
                    currentList.RemoveAt(currentList.Count - 1);
                }
            }
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