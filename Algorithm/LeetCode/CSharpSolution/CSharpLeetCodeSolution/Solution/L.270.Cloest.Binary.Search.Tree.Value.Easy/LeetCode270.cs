using System;

namespace Solution
{
    public class LeetCode270TreeNode
    {
        public int val;
        public LeetCode270TreeNode left;
        public LeetCode270TreeNode right;
        public LeetCode270TreeNode(int val = 0, LeetCode270TreeNode left = null, LeetCode270TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode270
    {
        public static int ClosestValue(LeetCode270TreeNode root, double target)
        {
            if (root == null) return -1;

            var res = root.val > target ? ClosestValue(root.left, target) : ClosestValue(root.right, target);

            if (res == -1)
            {
                return root.val;
            }

            return Math.Abs(root.val - target) > Math.Abs(res - target) ? res : root.val;

        }
    }

}