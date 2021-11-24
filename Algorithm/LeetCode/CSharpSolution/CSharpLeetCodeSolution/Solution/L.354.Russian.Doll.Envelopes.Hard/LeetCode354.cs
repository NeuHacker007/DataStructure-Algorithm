/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-24-2021 12:29:40
 * LastEditTime: 11-24-2021 12:42:38
 * FilePath: \CSharpLeetCodeSolution\Solution\L.354.Russian.Doll.Envelopes.Hard\LeetCode354.cs
 * Description: 
 */
using System;
namespace BinarySearchSolution
{
    public class LeetCode354
    {
        public static int MaxEnvelopes(int[][] envelopes)
        {
            var n = envelopes.Length;
            Array.Sort(envelopes, (a, b) => a[0] == b[0] ? b[1] - a[1] : a[0] - b[0]);
            var heights = new int[n];
            for (int i = 0; i < n; i++)
            {
                heights[i] = envelopes[i][1];
            }

            return LongestSubsequence(heights);
        }

        private static int LongestSubsequence(int[] nums)
        {
            int piles = 0;
            int n = nums.Length;


            var top = new int[n];
            for (int i = 0; i < n; i++)
            {
                var poker = nums[i];
                var left = 0;
                var right = piles;
                while (left < right)
                {
                    var mid = left + (right - left) / 2;

                    if (top[mid] >= poker)
                    {
                        right = mid;
                    }
                    else if (top[mid] < poker)
                    {
                        left = mid + 1;
                    }
                }

                if (left == piles) piles++;

                top[left] = poker;
            }

            return piles;

        }
    }

}