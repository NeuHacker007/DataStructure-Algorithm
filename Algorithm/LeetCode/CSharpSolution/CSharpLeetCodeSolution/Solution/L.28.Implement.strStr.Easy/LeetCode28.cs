/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-10-2022 08:54:09
 * LastEditTime: 01-10-2022 08:59:38
 * FilePath: \CSharpLeetCodeSolution\Solution\L.28.Implement.strStr.Easy\LeetCode28.cs
 * Description: 
 */

namespace StringSolution
{
    public class LeetCode28
    {
        public static int StrStr(string haystack, string needle)
        {
            var m = haystack.Length;
            var n = needle.Length;
            if (m < n)
            {
                return -1;
            }
            else if (n == 0)
            {
                return 0;
            }

            var loopTimes = m - n;

            for (int i = 0; i <= loopTimes; i++)
            {
                if (haystack.Substring(i, n).Equals(needle))
                {
                    return i;
                }
            }

            return -1;

        }
    }

}