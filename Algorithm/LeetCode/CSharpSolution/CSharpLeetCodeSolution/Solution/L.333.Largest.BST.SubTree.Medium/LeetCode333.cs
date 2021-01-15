/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-14-2021 10:03:12
 * LastEditTime: 01-14-2021 10:15:39
 * FilePath: \CSharpLeetCodeSolution\Solution\L.333.Largest.BST.SubTree.Medium\LeetCode333.cs
 * Description: 
 */
using System;
namespace Solution
{
    public class LeetCode333TreeNode
    {
        public int val;
        public LeetCode333TreeNode left;
        public LeetCode333TreeNode right;
        public LeetCode333TreeNode(int val = 0, LeetCode333TreeNode left = null, LeetCode333TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode333
    {
        private class SubtreeInfo
        {
            public bool valid = true;
            public int size = 0;
            public int min = int.MinValue;
            public int max = int.MaxValue;
        }
        public static int LargestBSTSubtree(LeetCode333TreeNode root)
        {
            return Helper(root).size;

        }

        private static SubtreeInfo Helper(LeetCode333TreeNode root)
        {
            if (root == null) return new SubtreeInfo();

            var left = Helper(root.left);
            var right = Helper(root.right);

            if (!left.valid || !right.valid || left.max >= root.val || right.min <= root.val)
            {
                left.valid = false;
                left.size = Math.Max(left.size, right.size);
            }
            else
            {
                left.valid = true;
                left.size = 1 + left.size + right.size;
            }

            left.min = Math.Min(root.val, Math.Min(left.min, right.min));
            right.max = Math.Max(root.val, Math.Max(left.max, right.max));
            return left;
        }


    }
}
