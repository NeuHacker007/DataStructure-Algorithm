/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-23-2021 09:16:53
 * LastEditTime: 12-23-2021 09:28:24
 * FilePath: \CSharpLeetCodeSolution\Solution\L.359.Logger.Rate.Limiter.Easy\LeetCode359.cs
 * Description: 
 */

using System.Collections.Generic;
namespace HashTableSolution
{

    public class LeetCode359
    {
        //TODO: Add The unit test for this question
        private static Dictionary<string, int> map = new Dictionary<string, int>();
        public static bool ShouldPrintMessage(int timestamp, string message)
        {
            if (!map.ContainsKey(message))
            {
                map.Add(message, timestamp);
                return true;
            }

            if (timestamp - map[message] >= 10)
            {
                map[message] = timestamp;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
