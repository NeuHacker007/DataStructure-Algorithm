/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 09-01-2021 21:10:08
 * LastEditTime: 09-21-2021 20:39:25
 * FilePath: \CSharpLeetCodeSolution\Solution\L.56.Merge.Interval.Medium\LeetCode56.cs
 * Description: 
 */
using System;
using System.Linq;
using System.Collections.Generic;
namespace LcArraySolution
{
    public class LeetCode56
    {
        public static int[][] Merge(int[][] intervals)
        {
            if (intervals.Length <= 1) return intervals;

            // OrderBy doesn't change the intervals arry 
            // it gives a new array.
            var orderedIntervals = intervals.OrderBy(i => i[0]).ToArray();

            List<int[]> result = new List<int[]>();

            result.Add(orderedIntervals[0]);

            foreach (var orderInterval in orderedIntervals)
            {
                if (result[result.Count - 1][1] < orderInterval[0])
                {
                    result.Add(orderInterval);
                }
                else
                {
                    result[result.Count - 1][1] = Math.Max(result[result.Count - 1][1], orderInterval[1]);
                }


            }
            return result.ToArray();
        }
    }
}