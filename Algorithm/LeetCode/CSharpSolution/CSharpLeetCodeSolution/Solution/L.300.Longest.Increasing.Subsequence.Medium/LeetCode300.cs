/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-10-2021 09:16:59
 * LastEditTime: 11-10-2021 17:51:24
 * FilePath: \CSharpLeetCodeSolution\Solution\L.300.Longest.Increasing.Subsequence.Medium\LeetCode300.cs
 * Description: 
 */
using System;
namespace DPSolution
{
    public class LeetCode300
    {
        public static int LengthOfLTS(int[] nums)
        {
            // dp[i] -> 以 nums[i] 为结尾的最长递增子序列的长度
            var dp = new int[nums.Length];
            // base case: 最长递增子序列最起码要包含自己所以初始为1 
            Array.Fill(dp, 1);
            // 根据刚才我们对 dp 数组的定义，现在想求 dp[5] 的值，
            // 也就是想求以 nums[5] 为结尾的最长递增子序列。
            // nums[5] = 3，既然是递增子序列，我们只要找到前面那些结尾比 3 小的子序列，
            // 然后把 3 接到最后，就可以形成一个新的递增子序列，而且这个新的子序列长度加一。

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }
            // result 应该为DP数组当中的最大值
            var result = 0;

            for (int i = 0; i < dp.Length; i++)
            {
                result = Math.Max(result, dp[i]);
            }

            return result;

        }
    }
}

namespace BinarySearchSolution
{
    public class LeetCode300
    {
        public static int LengthOfLIS(int[] nums)
        {
            var top = new int[nums.Length];
            var piles = 0;

            for (int i = 0; i < nums.Length; i++)
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
                    else
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