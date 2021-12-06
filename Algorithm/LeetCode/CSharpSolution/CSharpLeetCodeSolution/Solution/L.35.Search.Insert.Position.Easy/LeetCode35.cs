/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 05-14-2021 09:27:57
 * LastEditTime: 05-14-2021 09:33:45
 * FilePath: \CSharpLeetCodeSolution\Solution\L.35.Search.Insert.Position.Easy\LeetCode35.cs
 * Description: 
 */

namespace LcArraySolution
{

    public class LeetCode35
    {
        public static int SearchInsert(int[] nums, int target)
        {
            var low = 0;
            var high = nums.Length - 1;

            while (low <= high)
            {
                var mid = (high - low) / 2 + low;

                if (target == nums[mid])
                {
                    return mid;
                }
                else if (target < nums[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }

            }
            return low;
        }
    }
}