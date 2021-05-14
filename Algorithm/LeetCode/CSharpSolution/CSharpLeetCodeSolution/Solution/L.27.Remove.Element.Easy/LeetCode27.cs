/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 05-14-2021 15:38:47
 * LastEditTime: 05-14-2021 15:41:44
 * FilePath: \CSharpLeetCodeSolution\Solution\L.27.Remove.Element.Easy\LeetCode27.cs
 * Description: 
 */

namespace LcArraySolution
{
    public class LeetCode27
    {
        public static int RemoveElement(int[] nums, int val)
        {
            var p1 = 0;

            for (var p2 = 0; p2 < nums.Length; p2++)
            {
                if (nums[p2] != val)
                {
                    nums[p1] = nums[p2];
                    p1++;
                }
            }
            return p1;
        }
    }

}
