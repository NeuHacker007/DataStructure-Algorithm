/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-18-2022 10:59:58
 * LastEditTime: 10-18-2022 11:17:40
 * FilePath: \CSharpLeetCodeSolution\Solution\L.16.3Sum.Cloest.Medium\LeetCode16.cs
 * Description: 
 */

using System;
namespace TwoPointerSolution
{
    public class LeetCode16
    {
        public static int Solution1(int[] nums, int target)
        {
            int diff = int.MaxValue;
            int size = nums.Length;
            Array.Sort(nums);

            int i = 0;
            while (i < size && diff != 0)
            {
                int lo = i + 1;
                int hi = size - 1;
                while (lo < hi)
                {
                    int sum = nums[i] + nums[lo] + nums[hi];
                    if (Math.Abs(target - sum) < Math.Abs(diff))
                    {
                        diff = target - sum;
                    }

                    if (sum < target)
                    {
                        lo++;
                    }
                    else
                    {
                        hi--;
                    }
                }

                i++;
            }


            return target - diff;
        }
    }
}