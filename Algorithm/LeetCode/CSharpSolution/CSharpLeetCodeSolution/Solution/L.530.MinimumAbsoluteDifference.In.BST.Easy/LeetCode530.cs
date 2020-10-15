using System;
namespace Solution {
    public class LeetCode530TreeNode {
        public int val;
        public LeetCode530TreeNode left;
        public LeetCode530TreeNode right;
        public LeetCode530TreeNode (int val = 0, LeetCode530TreeNode left = null, LeetCode530TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode530 {

        static int pre = int.MinValue;
        static int ans = int.MaxValue;
        public static int GetMinimumDifference (LeetCode530TreeNode root) {
            Helper (root);

            return ans;
        }

        private static void Helper (LeetCode530TreeNode root) {
            if (root == null) return;

            Helper (root.left);
            if (pre != int.MinValue) {
                ans = Math.Min (ans, root.val - pre);
            }
            pre = root.val;
            Helper (root.right);
        }
    }

}