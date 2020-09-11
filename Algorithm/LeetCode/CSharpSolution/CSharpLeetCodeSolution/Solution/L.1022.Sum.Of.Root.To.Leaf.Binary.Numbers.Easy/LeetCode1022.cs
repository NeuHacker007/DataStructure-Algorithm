namespace Solution {

    public class LeetCode1022TreeNode {
        public int val;
        public LeetCode1022TreeNode left;
        public LeetCode1022TreeNode right;
        public LeetCode1022TreeNode (int val = 0, LeetCode1022TreeNode left = null, LeetCode1022TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode1022 {

        #region  Recursive
        static int ans = 0;
        public static int SumRootToLeafRecursive (LeetCode1022TreeNode root) {
            PreOrder (root, 0);
            return ans;
        }

        private static void PreOrder (LeetCode1022TreeNode root, int currSum) {
            if (root == null) return;
            //visit the root;
            currSum = (currSum << 1) | root.val;
            // base case
            if (root.left == null && root.right == null) {
                ans += currSum;
            }
            // visit the left
            PreOrder (root.left, currSum);
            //visit the right;
            PreOrder (root.right, currSum);

        }
        #endregion 

        #region Non Recursive 
        #endregion

        #region Morris PreOrder Traversal
        #endregion

    }

}