/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-04-2021 09:36:37
 * LastEditTime: 10-04-2021 09:44:26
 * FilePath: \CSharpLeetCodeSolution\Solution\L.42.Trapping.Rain.Water.Hard\LeetCode42.cs
 * Description: 
 */
using System;
namespace SlidingWindowSolution
{
    public class LeetCode42
    {
        public static int Trap(int[] height)
        {
            if (height.Length == 0) return 0;

            int left = 0;
            int right = height.Length - 1;

            int res = 0;

            int l_max = height[0]; // Left point
            int r_max = height[height.Length - 1]; // right point

            while (left <= right)
            {
                l_max = Math.Max(l_max, height[left]);
                r_max = Math.Max(r_max, height[right]);

                if (l_max < r_max)
                {
                    res += l_max - height[left];
                    left++;
                }
                else
                {
                    res += r_max - height[right];

                    right--;
                }
            }

            return res;
        }
    }
}