using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public class LeetCode15
    {
        public static IList<IList<int>> Get3Sum(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> result = new List<IList<int>>();

            for (int i = 0; i < nums.Length && nums[i] <= 0; ++i)
            {
                if (i == 0 || nums[i - 1] != nums[i])
                {
                    TwoSum(nums, i, result);
                }
            }

            return result;
        }


        private static void TwoSum(int[] nums, int index, IList<IList<int>> resultList)
        {
            // TODO fix the test failure
            int low = index + 1;
            int high = nums.Length - 1;

            while (low < high)
            {
                int sum = nums[index] + nums[low] + nums[high];
                if (sum < 0 || low > (index + 1) && nums[low] == nums[low - 1])
                {
                    low++;
                } else if (sum > 0 || high < nums.Length - 1 && nums[high] == nums[high + 1])
                {
                    high--;
                }
                else
                {
                    List<int> temp = new List<int>();
                    temp.Add(nums[index]);
                    temp.Add(nums[low++]);
                    temp.Add(nums[high--]);

                    resultList.Add(temp);
                }
            }
        }
    }
}
