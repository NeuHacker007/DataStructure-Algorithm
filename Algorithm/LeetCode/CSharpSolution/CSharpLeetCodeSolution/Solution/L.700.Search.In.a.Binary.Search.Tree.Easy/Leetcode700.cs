namespace Solution {
    public class LeetCode700Node {
        public int val;
        public LeetCode700Node left;
        public LeetCode700Node right;
        public LeetCode700Node (int val = 0, LeetCode700Node left = null, LeetCode700Node right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }

    }
    public class LeetCode700 {
        public static LeetCode700Node SearchBST (LeetCode700Node root, int val) {
            if (root == null || root.val == val) return root;

            return root.val > val ? SearchBST (root.left, val) : SearchBST (root.right, val);
        }
    }
}