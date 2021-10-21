/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-21-2021 08:54:33
 * LastEditTime: 10-21-2021 08:57:44
 * FilePath: \CSharpLeetCodeSolution\Solution\L.387.First.Unique.Character.in.a.string.Easy\LeetCode387.cs
 * Description: 
 */
using System.Collections.Generic;
namespace StringSolution
{
    public class LeetCode387
    {
        public static int FirstUniqueChar(string s)
        {

            var map = new Dictionary<char, int>();

            foreach (var ch in s)
            {
                if (!map.ContainsKey(ch))
                {
                    map.Add(ch, 1);
                }
                else
                {
                    map[ch]++;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (map[s[i]] == 1) return i;
            }

            return -1;
        }
    }
}