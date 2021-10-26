/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-26-2021 08:46:45
 * LastEditTime: 10-26-2021 08:56:37
 * FilePath: \CSharpLeetCodeSolution\Solution\L.11.Container.With.Most.Water.Medium\LeetCode11.cs
 * Description: 
 */
 using System;
namespace TwoPointerSolution
{
    public class LeetCode11 {
        public static int MaxArea(int[] heights){
            if (heights.Length == 0) return 0;

            var left = 0;
            var right = heights.Length -1;
            var maxArea = 0;
            while (left < right)
            {
                 maxArea = Math.Max(maxArea, Math.Min(heights[left], heights[right]) * (right - left));
                if (heights[left] < heights[right]){
                    left++;
                } else {
                    right--;
                }

            }
            return maxArea;
        }
    }
}