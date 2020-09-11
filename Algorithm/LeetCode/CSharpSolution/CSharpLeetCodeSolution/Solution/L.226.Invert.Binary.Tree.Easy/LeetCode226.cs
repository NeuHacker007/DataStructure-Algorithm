namespace Solution {

    public class LeetCode226TreeNode {
        public int val;
        public LeetCode226TreeNode left;
        public LeetCode226TreeNode right;
        public LeetCode226TreeNode (int val = 0, LeetCode226TreeNode left = null, LeetCode226TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode226 {
        public static LeetCode226TreeNode InvertTree (LeetCode226TreeNode root) {
            if (root == null) return null;

            InvertTree (root.left);
            InvertTree (root.right);

            var temp = root.right;
            root.right = root.left;
            root.left = temp;

            return root;
        }
    }

}