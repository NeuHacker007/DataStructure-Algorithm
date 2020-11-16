using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    //Given an array of integers, return indices of the two numbers such that they add up to a specific target.

    //You may assume that each input would have exactly one solution, and you may not use the same element twice.

    //Example:

    //Given nums = [2, 7, 11, 15], target = 9,

    //Because nums[0] + nums[1] = 2 + 7 = 9,
    //return [0, 1].


    public class LeetCode1
    {
        public static int[] TwoSum(int[] nums, int target)
        {
             Dictionary<int, int> dic = new Dictionary<int, int>();

             for (int i = 0; i < nums.Length; i++)
             {
                 var temp = target - nums[i];
                 if (dic.ContainsKey(temp))
                 {
                     return new[] {dic[temp], i};
                 }
                 else
                 {
                     if (!dic.ContainsKey(nums[i]))
                     {
                         dic.Add(nums[i], i);
                     }
                 }
             }

             return new int[]{};
        }
    }
}
