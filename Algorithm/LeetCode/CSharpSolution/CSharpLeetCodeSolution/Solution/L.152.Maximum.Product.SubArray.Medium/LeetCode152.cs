/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 02-03-2022 10:07:21
 * LastEditTime: 02-03-2022 10:18:59
 * FilePath: \CSharpLeetCodeSolution\Solution\L.152.Maximum.Product.SubArray.Medium\LeetCode152.cs
 * Description: 
 */
using System;
namespace DPSolution
{
    public class LeetCode152
    {
        /*
            DPMax[i] :  the maxium product of contiguous subarray of nums[0 .. i] i > 0
            DPMin[i] :  the minium product of contiguous subarray of nums[0 .. i] i < 0
                                i-1 * i
            nums: [X X X X X X X X] i

        
             dpMin[i] =   Min (dpMax[i-1] * nums[i], dpMin[i -1] * nums[i], nums[i]);
             dpMax[i] = Max (dpMax[i-1] * nums[i], dpMin[i -1] * nums[i], nums[i]);
            
        */
        public static int MaxProduct(int[] nums)
        {
            int n = nums.Length;

            int[] dpMax = new int[n];
            int[] dpMin = new int[n];
            dpMax[0] = nums[0];
            dpMin[0] = nums[0];
            int result = nums[0];
            for (int i = 1; i < n; i++)
            {
                dpMax[i] = Max(dpMax[i - 1] * nums[i], dpMin[i - 1] * nums[i], nums[i]);
                dpMin[i] = Min(dpMax[i - 1] * nums[i], dpMin[i - 1] * nums[i], nums[i]);

                result = Math.Max(result, dpMax[i]);
            }

            return result;

        }
        private static int Max(int a, int b, int c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        private static int Min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
    }

}
