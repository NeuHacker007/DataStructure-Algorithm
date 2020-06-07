using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public class LeetCode15
    {
        //Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

        //    Note:

        //The solution set must not contain duplicate triplets.

        //    Example:

        //Given array nums = [-1, 0, 1, 2, -1, -4],

        //A solution set is:
        //[
        //[-1, 0, 1],
        //[-1, -1, 2]
        //]

        // TODO: Test case fails, missing a result in result set
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();
            for (int i = 0; i < nums.Length && nums[i] <= 0; ++i)
            {
                if (i == 0 || nums[i - 1] != nums[i])
                {
                    twoSumII(nums, i, result);
                }
            }
            return result;
        }

        private static void twoSumII(int[] nums, int i, List<IList<int>> result)
        {
            int low = i + 1;
            int high = nums.Length - 1;

            while (low < high)
            {
                int sum = nums[i] + nums[low] + nums[high];
                if (sum < 0 || (low > (i + 1) && nums[low] == nums[low - 1]))
                    low++;
                else if (sum > 0 || high < nums.Length - 1 && nums[high] == nums[high + 1])
                {
                    high--;
                }
                else
                {
                    List<int> temp = new List<int>();
                    temp.Add(nums[i]);
                    temp.Add(nums[low++]);
                    temp.Add(nums[high--]);
                    result.Add(temp);
                }
            }
        }
    }
}
