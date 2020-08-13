using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public class LeetCode560
    {
        //Given an array of integers and an integer k, you need to find the total number of continuous subarrays whose sum equals to k.

        //    Example 1:

        //Input:nums = [1,1,1], k = 2
        //Output: 2


        //Constraints:

        //The length of the array is in range[1, 20, 000].
        //The range of numbers in the array is [-1000, 1000] and the range of the integer k is [-1e7, 1e7].


        public static int SubArraySumBruteForce(int[] nums, int k)
        {
            // Time complexity : O(n^3) Considering every possible subarray takes O(n^2) time.
            // For each of the subarray we calculate the sum taking O(n) time in the worst case,
            // taking a total of O(n^3) time
            var counter = 0;

            for (var start = 0; start < nums.Length; start++)
            {
                for (var end = start + 1; end <= nums.Length; end++)
                {
                    var sum = 0;
                    for (var i = start; i < end; i++)
                    {
                        sum += nums[i];
                    }

                    if (sum == k)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        public static int SubArraySumCumulativeSum(int[] nums, int k)
        {
            var counter = 0;
            var sum = new int[nums.Length + 1];
            sum[0] = 0;

            for (var i = 1; i <= nums.Length; i++)
            {
                sum[i] = sum[i - 1] + nums[i - 1];
            }

            for (var start = 0; start < nums.Length; start++)
            {
                for (var end = start + 1; end <= nums.Length; end++)
                {
                    if (sum[end] - sum[start] == k)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        public static int SubArraySumWithoutSpace(int[] nums, int k)
        {
            var counter = 0;

            for (var start = 0; start < nums.Length; start++)
            {
                var sum = 0;

                for (var end = start; end < nums.Length; end++)
                {
                    sum += nums[end];
                    if (sum == k)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        public static int SubArraySumHashMap(int[] nums, int k)
        {

            var counter = 0;

            var sum = 0;

            Dictionary<int, int> hashMap = new Dictionary<int, int> { { 0, 1 } };


            for (var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (hashMap.ContainsKey(sum - k))
                {
                    counter += hashMap[sum - k];
                }

                if (hashMap.ContainsKey(sum))
                {
                    hashMap[sum]++;
                }
                else
                {
                    hashMap.Add(sum, 1);
                }
            }

            return counter;
        }
    }
}
