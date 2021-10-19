/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-19-2021 14:00:43
 * LastEditTime: 10-19-2021 15:20:06
 * FilePath: \CSharpLeetCodeSolution\Solution\L.350.Intersection.Of.Two.Arrays.II.Easy\LeetCode350.cs
 * Description: 
 */

using System.Collections.Generic;
using System.Linq;
using System;
namespace ArraySolution
{
    public class LeetCode350
    {
        public static int[] Intersect(int[] nums1, int[] nums2)
        {

            Array.Sort(nums1);
            Array.Sort(nums2);
            var p1 = 0;
            var p2 = 0;
            var result = new List<int>();
            while (p1 < nums1.Length && p2 < nums2.Length)
            {
                if (nums1[p1] == nums2[p2])
                {
                    result.Add(nums1[p1]);
                    p1++;
                    p2++;
                }
                else if (nums1[p1] < nums2[p2])
                {
                    p1++;
                }
                else
                {
                    p2++;
                }
            }

            return result.ToArray();
        }
    }
}