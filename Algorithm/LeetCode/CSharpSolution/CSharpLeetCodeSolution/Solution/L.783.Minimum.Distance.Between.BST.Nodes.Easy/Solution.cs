using System;
namespace Solution {
    public class LeetCode783TreeNode {
        public int val;
        public LeetCode783TreeNode left;
        public LeetCode783TreeNode right;
        public LeetCode783TreeNode (int val = 0, LeetCode783TreeNode left = null, LeetCode783TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode783 {
        static int result = int.MaxValue;
        static int pre = -1;
        public static int MinDiffInBST (LeetCode783TreeNode root) {
            helper (root);
            return result;
        }

        private static void helper (LeetCode783TreeNode root) {
            if (root == null) return;

            helper (root.left);

            if (pre != -1) {
                result = Math.Min (result, root.val - pre);
            }
            pre = root.val;
            helper (root.right);
        }

    }

}