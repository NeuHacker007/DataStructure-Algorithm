using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public class LeetCode167
    {
        //Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.

        //    The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.

        //    Note:

        //Your returned answers (both index1 and index2) are not zero-based.
        //    You may assume that each input would have exactly one solution and you may not use the same element twice.

        //    Example:

        //Input: numbers = [2, 7, 11, 15], target = 9
        //Output: [1,2]
        //Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.


        public static int[] TwoSumII(int[] nums, int target)
        {
            List<int> result = new List<int>();

            int low = 0;
            int high = nums.Length - 1;

            while (low < high)
            {
                var temp = nums[low] + nums[high];

                if (temp == target)
                {
                    result.Add(low + 1);
                    result.Add(high + 1);
                    break;
                } else if (temp > target)
                {
                    high--;
                }
                else
                {
                    low++;
                }
            }


            return result.ToArray();
        }
    }
}
