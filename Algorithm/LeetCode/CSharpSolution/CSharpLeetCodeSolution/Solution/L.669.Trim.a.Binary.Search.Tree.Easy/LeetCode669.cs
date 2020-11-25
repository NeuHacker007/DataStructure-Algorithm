namespace Solution {

    public class LeetCode669TreeNode {
        public int val;
        public LeetCode669TreeNode left;
        public LeetCode669TreeNode right;
        public LeetCode669TreeNode (int val = 0, LeetCode669TreeNode left = null, LeetCode669TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class LeetCode669 {
        public static LeetCode669TreeNode TrimBST (LeetCode669TreeNode root, int low, int high) {
            if (root == null) return root;

            if (root.val < low) {
                return TrimBST (root.left, low, high);
            }

            if (root.val > high) {
                return TrimBST (root.right, low, high);
            }

            root.left = TrimBST (root.left, low, high);
            root.right = TrimBST (root.right, low, high); 

            return root;
        }
    }

}