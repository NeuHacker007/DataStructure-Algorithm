/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 05-14-2021 15:01:38
 * LastEditTime: 05-14-2021 15:12:49
 * FilePath: \CSharpLeetCodeSolution\Solution\L.26.Remove.Duplicates.From.Sorted.Array.Easy\LeetCode26.cs
 * Description: 
 */

namespace LcArraySolution
{
    public class LeetCode26
    {
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            var i = 0;

            for (var j = 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }

    }

}