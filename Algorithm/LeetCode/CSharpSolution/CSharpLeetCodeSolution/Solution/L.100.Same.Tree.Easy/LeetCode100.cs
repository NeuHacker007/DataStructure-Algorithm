namespace Solution {
    public class LeetCode100TreeNode {
        public int val;
        public LeetCode100TreeNode left;
        public LeetCode100TreeNode right;
        public LeetCode100TreeNode (int val = 0, LeetCode100TreeNode left = null, LeetCode100TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode100 {
        public static bool IsSameTree (LeetCode100TreeNode t1, LeetCode100TreeNode t2) {

            if (t1 == null && t2 == null) return true;
            if (t1 == null || t2 == null) return false;

            if (t1.val != t2.val) return false;

            return IsSameTree (t1.left, t2.left) && IsSameTree (t1.right, t2.right);

        }
    }

}