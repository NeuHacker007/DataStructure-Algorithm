/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-26-2021 12:40:02
 * LastEditTime: 10-26-2021 13:09:31
 * FilePath: \CSharpLeetCodeSolution\Solution\L.17.Letter.Combinations.Of.a.phone.number.Medium\LeetCode17.cs
 * Description: 
 */
using System.Collections.Generic;
using System.Text;
namespace BackTrackSolution
{
    public class LeetCode17
    {
        static Dictionary<char, string> map = new Dictionary<char, string>(){
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}

         };
        public static IList<string> LetterCombination(string digits)
        {
            var result = new List<string>();
            BackTraceHelper(digits, new StringBuilder(), result, 0);

            return result;
        }

        public static void BackTraceHelper(string digits, StringBuilder sb, IList<string> result, int index)
        {
            if (index == digits.Length)
            {
                result.Add(sb.ToString());

                return;
            }

            var possibles = map[digits[index]];
            foreach (var item in possibles)
            {
                sb.Append(item);
                BackTraceHelper(digits, sb, result, index + 1);
                sb.Remove(sb.Length - 1, 1);
            }
           
        }
    }
}