namespace Solution {
    public class LeetCode404TreeNode {
        public int val;
        public LeetCode404TreeNode left;
        public LeetCode404TreeNode right;
        public LeetCode404TreeNode (int val = 0, LeetCode404TreeNode left = null, LeetCode404TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public bool IsLeavesNode () {
            return left == null && right == null;
        }
    }

    public class LeetCode404 {
        static int sum = 0;
        public static int SumLeftLeaves (LeetCode404TreeNode root) {
            PreOrder (root, root);
            return sum;
        }

        private static void PreOrder (LeetCode404TreeNode root, LeetCode404TreeNode parent) {
            if (root == null) return;

            if (root.IsLeavesNode () && root == parent.left) {
                sum += root.val;
            } else {
                PreOrder (root.left, root);
                PreOrder (root.right, root);
            }
        }
    }
}