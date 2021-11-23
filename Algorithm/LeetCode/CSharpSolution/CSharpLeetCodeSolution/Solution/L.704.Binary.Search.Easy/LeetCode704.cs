/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-23-2021 16:07:49
 * LastEditTime: 11-23-2021 16:08:51
 * FilePath: \CSharpLeetCodeSolution\Solution\L.704.Binary.Search.Easy\LeetCode704.cs
 * Description: 
 */

namespace BinarySearchSolution
{

    public class LeetCode704
    {
        public static int Search(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
    }

}