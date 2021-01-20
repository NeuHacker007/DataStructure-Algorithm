/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-20-2021 13:57:57
 * LastEditTime: 01-20-2021 14:08:45
 * FilePath: \CSharpLeetCodeSolution\Solution\L.337.House.Robber.III.Medium\LeetCode337.cs
 * Description: 
 */
using System;
namespace Solution
{
    public class LeetCode337TreeNode
    {
        public int val;
        public LeetCode337TreeNode left;
        public LeetCode337TreeNode right;
        public LeetCode337TreeNode(int val = 0, LeetCode337TreeNode left = null, LeetCode337TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode337
    {
        public static int Rob(LeetCode337TreeNode root)
        {
            var ans = Helper(root);
            return Math.Max(ans[0], ans[1]);
        }

        private static int[] Helper(LeetCode337TreeNode root)
        {
            if (root == null) return new int[] { 0, 0 };
            var left = Helper(root.left);
            var right = Helper(root.right);

            var rob = root.val + left[1] + right[1];
            var notRob = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);

            return new int[] { rob, notRob };
        }
    }


}