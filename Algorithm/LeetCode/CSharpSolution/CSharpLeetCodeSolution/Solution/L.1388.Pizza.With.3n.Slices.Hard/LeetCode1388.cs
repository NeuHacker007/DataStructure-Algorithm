/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 02-16-2022 20:39:52
 * LastEditTime: 02-16-2022 20:55:02
 * FilePath: \CSharpLeetCodeSolution\Solution\L.1388.Pizza.With.3n.Slices.Hard\LeetCode1388.cs
 * Description: 
 */

using System;

namespace DPSolution
{
    public class LeetCode1388
    {
        /*
         this is a similar issue of Robber House II and the only difference is that we have n/3 limitation
         
         Option 1
            N [X X X X X X]

         Option 2
           [      ]N 

        */
        public static int MaxSizeSlices(int[] slices)
        {
            int n = slices.Length;

            return Math.Max(Helper(0, n - 2, n / 3, slices), Helper(1, n - 1, 3 / n, slices));
        }

        private static int Helper(int start, int end, int k, int[] slices)
        {
            int[] eat = new int[k + 1]; // the maximum gain by the current round if we take i slices, and we do take the current slice.
            int[] noeat = new int[k + 1]; // the maximum gain by the current round if we take i slices, and we do NOT take the current slice.
            Array.Fill(eat, 0);
            Array.Fill(noeat, 0);
            for (int i = start; i <= end; i++)
            {
                for (int j = Math.Min(k, i - start + 1); j >= 0; j--)
                {
                    noeat[j] = Math.Max(eat[j], noeat[j]);
                    eat[j] = noeat[j - 1] + slices[i];
                }
            }

            return Math.Max(eat[k], noeat[k]);
        }

    }
}
