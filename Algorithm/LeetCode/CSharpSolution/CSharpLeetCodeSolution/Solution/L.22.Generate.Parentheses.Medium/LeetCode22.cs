/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-25-2022 08:30:53
 * LastEditTime: 10-25-2022 08:54:56
 * FilePath: \CSharpLeetCodeSolution\Solution\L.22.Generate.Parentheses.Medium\LeetCode22.cs
 * Description: 
 */
using System.Collections.Generic;
using System.Text;
namespace BackTrackSolution
{
    public class LeetCode22
    {
        public static IList<string> GenerateParenthesis(int n)
        {
            IList<string> ans = new List<string>();
            BackTrack(ans, new StringBuilder(), 0, 0, n);
            return ans;
        }

        private static void BackTrack(IList<string> ans, StringBuilder cur, int open, int close, int max)
        {
            if (cur.Length == max * 2)
            {
                ans.Add(cur.ToString());
                return;
            }

            if (open < max)
            {
                cur.Append("(");
                BackTrack(ans, cur, open + 1, close, max);
                cur.Remove(cur.Length - 1, 1);
            }

            if (close < open)
            {
                cur.Append(")");
                BackTrack(ans, cur, open, close + 1, max);
                cur.Remove(cur.Length - 1, 1);
            }
        }
    }
}