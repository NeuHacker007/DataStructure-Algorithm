using System;
namespace Solution
{

    public class LeetCode543TreeNode
    {
        public int val;
        public LeetCode543TreeNode left;
        public LeetCode543TreeNode right;
        public LeetCode543TreeNode(int val = 0, LeetCode543TreeNode left = null, LeetCode543TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode543
    {
        static int ans;
        public static int DiameterOfBinaryTree(LeetCode543TreeNode root)
        {
            ans = 1;
            depth(root);
            return ans - 1;
        }

        private static int depth(LeetCode543TreeNode root)
        {
            if (root == null) return 0;

            var L = depth(root.left);
            var R = depth(root.right);

            ans = Math.Max(ans, L + R + 1);
            return Math.Max(L, R) + 1;
        }
    }
}