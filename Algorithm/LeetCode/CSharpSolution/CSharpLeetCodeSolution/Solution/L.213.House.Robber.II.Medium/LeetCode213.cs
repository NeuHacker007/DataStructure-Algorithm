/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 02-15-2022 20:55:30
 * LastEditTime: 02-15-2022 21:31:59
 * FilePath: \CSharpLeetCodeSolution\Solution\L.213.House.Robber.II.Medium\LeetCode213.cs
 * Description: 
 */
using System;
namespace DPSolution
{
    public class LeetCode213
    {
        /*
         since it is the circle and for each round we only have two option rob or not rob,
         so, we had following analysis

         1. The last room nums[n-1] is robbed, based on the rules, 
            the first room cannot be robbed again. 
            So, start from the nums[1] to the end nums[i]
              
              rob = norob[i -1] + nums[i];
              norob = Max(rob[i-1], norob[i-1]);

            nums: X X X X X X X X X i 
                  N [               ]
            rob     [             ]+i
            norob
          2. the first room nums[0] is robbed, the last room nums[n-1] must be norob
            nums: X X X X X X X X X i
                  [               ] N                 
        */
        public static int Rob(int[] nums)
        {
            int n = nums.Length;

            if (n == 0) return 0;
            if (n == 1) return nums[0];

            int result = 0;
            // if the last room is robbed 
            int rob = nums[1];
            int norob = 0;
            for (int i = 2; i < n; i++)
            {
                int rob_tmp = rob;
                int norob_tmp = norob;
                rob = norob_tmp + nums[i];
                norob = Math.Max(rob_tmp, norob_tmp);
            }
            result = Math.Max(rob, norob);


            // if first room is not robbed
            rob = nums[0];
            norob = 0;
            for (int i = 1; i < n - 1; i++)
            {
                int rob_tmp = rob;
                int norob_tmp = norob;
                rob = norob_tmp + nums[i];
                norob = Math.Max(rob_tmp, norob_tmp);
            }

            result = Math.Max(result, Math.Max(rob, norob));

            return result;

        }
    }
}
