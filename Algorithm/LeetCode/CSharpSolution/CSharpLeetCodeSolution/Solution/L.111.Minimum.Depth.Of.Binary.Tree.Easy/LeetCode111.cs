/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-30-2020 21:12:29
 * LastEditTime: 11-30-2020 21:21:10
 * FilePath: \CSharpLeetCodeSolution\Solution\L.111.Minimum.Depth.Of.Binary.Tree.Easy\LeetCode111.cs
 * Description: 
 */
using System;

namespace Solution
{
    public class LeetCode111TreeNode
    {
        public int val;
        public LeetCode111TreeNode left;
        public LeetCode111TreeNode right;
        public LeetCode111TreeNode(int val = 0, LeetCode111TreeNode left = null, LeetCode111TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode111
    {
        public static int MinDepth(LeetCode111TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return 1;
            var minDepth = int.MaxValue;
            if (root.left != null)
            {
                minDepth = Math.Min(MinDepth(root.left), minDepth);
            }
            if (root.right != null)
            {
                minDepth = Math.Min(MinDepth(root.right), minDepth);
            }

            return minDepth + 1;
        }

        public static int MinDepthV2(LeetCode111TreeNode root)
        {
            if (root == null) return 0;

            if (root.left == null) return 1 + MinDepthV2(root.right);
            if (root.right == null) return 1 + MinDepthV2(root.left);

            return 1 + Math.Min(MinDepthV2(root.left), MinDepthV2(root.right));
        }
    }
}
