/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-11-2022 09:06:59
 * LastEditTime: 01-11-2022 09:10:10
 * FilePath: \CSharpLeetCodeSolution\Solution\L.58.Length.Of.Last.Word.Easy\LeetCode58.cs
 * Description: 
 */

namespace StringSolution
{
    public class LeetCode58
    {
        public static int LengthOfLastWord(string s)
        {
            var m = s.Length;
            var count = 0;
            for (int i = m - 1; i >= 0; i--)
            {
                if (s[i] != ' ')
                {
                    count++;
                }
                else if (count > 0)
                {
                    return count;
                }
            }

            return count;
        }
    }

}
