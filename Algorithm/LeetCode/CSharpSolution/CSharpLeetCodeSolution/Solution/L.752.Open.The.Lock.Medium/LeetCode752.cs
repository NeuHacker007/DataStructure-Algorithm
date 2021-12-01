/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-30-2021 19:37:02
 * LastEditTime: 11-30-2021 19:48:44
 * FilePath: \CSharpLeetCodeSolution\Solution\L.752.Open.The.Lock.Medium\LeetCode752.cs
 * Description: 
 */
using System.Collections.Generic;
namespace BFSSolution
{
    public class LeetCode752
    {
        public static int OpenLock(string[] deadends, string target)
        {
            var deadsList = new HashSet<string>();

            foreach (var deadend in deadends)
            {
                deadsList.Add(deadend);
            }


            var q1 = new HashSet<string>();
            var q2 = new HashSet<string>();
            var visited = new HashSet<string>();

            var step = 0;
            q1.Add("0000");
            q2.Add(target);

            while (q1.Count != 0 && q2.Count != 0)
            {
                var temp = new HashSet<string>();

                foreach (var curr in q1)
                {
                    if (deadsList.Contains(curr)) continue;
                    if (q2.Contains(curr)) return step;

                    visited.Add(curr);

                    for (int i = 0; i < 4; i++)
                    {
                        var up = PlusOne(curr, i);
                        if (!visited.Contains(up)) temp.Add(up);

                        var down = MinusOne(curr, i);
                        if (!visited.Contains(down)) temp.Add(down);
                    }
                }
                step++;

                q1 = q2;
                q2 = temp;
            }

            return -1;
        }

        private static string PlusOne(string s, int index)
        {
            var array = s.ToCharArray();

            array[index] = array[index] != '9' ? (char)(array[index] + 1) : '0';
            return string.Join("", array);
        }

        private static string MinusOne(string s, int index)
        {
            var array = s.ToCharArray();

            array[index] = array[index] != '0' ? (char)(array[index] - 1) : '9';
            return string.Join("", array);
        }
    }
}