using System;

namespace Solution
{
    public class LeetCode110TreeNode
    {
        public int val;
        public LeetCode110TreeNode left;
        public LeetCode110TreeNode right;
        public LeetCode110TreeNode(int val = 0, LeetCode110TreeNode left = null, LeetCode110TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode110
    {
        public static bool IsBalancedBinaryTree(LeetCode110TreeNode root)
        {
            if (root == null) return true;
            var left = GetHeight(root.left);
            var right = GetHeight(root.right);

            if (Math.Abs(left - right) <= 1)
            {
                return IsBalancedBinaryTree(root.left) && IsBalancedBinaryTree(root.right);
            }
            return false;
        }

        private static int GetHeight(LeetCode110TreeNode root)
        {
            if (root == null) return 0;

            return 1 + Math.Max(GetHeight(root.left), GetHeight(root.right));
        }
    }

}