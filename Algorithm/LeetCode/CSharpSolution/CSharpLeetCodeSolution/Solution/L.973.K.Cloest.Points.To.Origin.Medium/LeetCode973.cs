/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-07-2021 16:12:30
 * LastEditTime: 10-07-2021 16:14:54
 * FilePath: \CSharpLeetCodeSolution\Solution\L.973.K.Cloest.Points.To.Origin.Medium\LeetCode973.cs
 * Description: 
 */
using System;
using System.Collections.Generic;
using System.Linq;


namespace ArraySolution
{
    //TODO: Add the Problem.MD and Solution.MD 
    public class LeetCode973
    {
        public static int[][] KClosest(int[][] points, int k)
        {
            Dictionary<int[], int> map = new Dictionary<int[], int>();

            foreach (var point in points)
            {
                var distance = (int)(Math.Pow(point[0], 2) + Math.Pow(point[1], 2));

                map.Add(point, distance);
            }

            var sortedMap = map.OrderBy(m => m.Value).ToDictionary(p => p.Key, v => v.Value);

            List<int[]> sortedResult = new List<int[]>();

            foreach (var item in sortedMap.Keys)
            {
                sortedResult.Add(item);
            }

            return sortedResult.Take(k).ToArray();
        }
    }

}