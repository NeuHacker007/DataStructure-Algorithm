/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 02-02-2022 09:09:26
 * LastEditTime: 02-02-2022 13:08:29
 * FilePath: \CSharpLeetCodeSolution\Solution\L.140.Word.BreakII.Hard\LeetCode140.cs
 * Description: 
 */
using System;
using System.Collections.Generic;
using System.Text;
namespace BackTrackSolution
{
    public class LeetCode140
    {
        public static IList<string> WordBreak(string s, IList<string> wordDict)
        {
            IList<string> result = new List<string>();
            BackTrack(s, 0, new StringBuilder(), new StringBuilder(), wordDict, result);
            return result;
        }

        private static void BackTrack(string s,
                                      int start,
                                      StringBuilder currentWord,
                                      StringBuilder phrase,
                                      IList<string> wordDict,
                                      IList<string> result)
        {
            if (s.Length == start)
            {
                if (wordDict.Contains(currentWord.ToString()))
                {
                    var p = currentWord.ToString() + phrase.ToString();
                    result.Add(p);
                }
                return;
            }

            currentWord.Append(s[start]);
            BackTrack(s, start + 1, currentWord, phrase, wordDict, result);
            currentWord.Length--;

            if (wordDict.Contains(currentWord.ToString()))
            {
                var toAppend = currentWord.ToString() + "";
                phrase.Append(toAppend);
                BackTrack(s, start, new StringBuilder(), phrase, wordDict, result);
                phrase.Length -= toAppend.Length;
            }
        }
    }
}