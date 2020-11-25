namespace Solution {

    public class LeetCode965TreeNode {
        public int val;
        public LeetCode965TreeNode left;
        public LeetCode965TreeNode right;
        public LeetCode965TreeNode (int val = 0, LeetCode965TreeNode left = null, LeetCode965TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode965 {
        public static bool IsUnivalTree (LeetCode965TreeNode root) {
            // pre-order traversal
            var left = root.left == null || (root.val == root.left.val && IsUnivalTree (root.left));
            // pre-order traversal
            var right = root.right == null || (root.val == root.right.val && IsUnivalTree (root.right));

            return left && right;
        }

    }
}