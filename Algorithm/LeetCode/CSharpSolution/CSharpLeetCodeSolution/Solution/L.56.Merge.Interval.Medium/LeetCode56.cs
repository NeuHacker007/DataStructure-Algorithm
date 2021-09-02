/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 09-01-2021 21:10:08
 * LastEditTime: 09-01-2021 21:18:48
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

            intervals.OrderBy(i => i[0]);

            List<int[]> result = new List<int[]>();

            result.Add(intervals[0]);

            foreach (var interval in intervals)
            {
                if (result[result.Count - 1][1] < interval[0])
                {
                    result.Add(interval);
                }
                else
                {
                    result[result.Count - 1][1] = Math.Max(result[result.Count - 1][1], interval[1]);
                }


            }
            return result.ToArray();
        }
    }
}