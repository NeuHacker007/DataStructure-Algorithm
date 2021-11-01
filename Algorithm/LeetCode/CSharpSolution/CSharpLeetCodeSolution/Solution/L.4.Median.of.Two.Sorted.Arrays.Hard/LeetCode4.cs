/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-01-2021 09:34:14
 * LastEditTime: 11-01-2021 10:05:29
 * FilePath: \CSharpLeetCodeSolution\Solution\L.4.Median.of.Two.Sorted.Arrays.Hard\LeetCode4.cs
 * Description: 
 */
using System;
using System.Collections.Generic;
using System.Linq;
namespace BinarySearchSolution
{

    public class LeetCode4
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var list = new List<int>();

            foreach (var item in nums1)
            {
                list.Add(item);
            }

            foreach (var item in nums2)
            {
                list.Add(item);
            }


            var sorted = list.OrderBy(l => l).ToArray();

            if (sorted.Length % 2 == 0)
            {
                var lowIndex = sorted.Length / 2 - 1;
                var highIndex = sorted.Length / 2;

                return (double)(sorted[lowIndex] + sorted[highIndex]) / 2;
            }
            else
            {
                return (double)sorted[(sorted.Length - 1) / 2];
            }
        }

        public static double FindMedianSortedArraysBinarySearch(int[] nums1, int[] nums2)
        {
            var n1 = nums1.Length;
            var n2 = nums2.Length;
            if (n1 > n2)
            {
                Swap(ref nums1, ref nums2);
                n1 = nums1.Length;
                n2 = nums2.Length;
            }

            var k = (n1 + n2 + 1) / 2;

            var left = 0;
            var right = n1;
            int m1;
            int m2;
            while (left < right)
            {
                m1 = left + (right - left) / 2;
                m2 = k - m1;

                if (nums1[m1] < nums2[m2 - 1])
                {
                    left = m1 + 1;
                }
                else
                {
                    right = m1;
                }
            }

            m1 = left;
            m2 = k - m1;

            var c1 = Math.Max(m1 <= 0 ? int.MinValue : nums1[m1 - 1],
                             m2 <= 0 ? int.MinValue : nums2[m2 - 1]);

            if ((n1 + n2) % 2 == 1)
            {
                return c1;
            }

            var c2 = Math.Min(m1 >= n1 ? int.MaxValue : nums1[m1],
                            m2 >= n2 ? int.MaxValue : nums2[m2]);

            return (c1 + c2) * 0.5;
        }

        public static void Swap(ref int[] nums1, ref int[] nums2)
        {
            var temp = nums1;
            nums1 = nums2;
            nums2 = temp;
        }

    }

}