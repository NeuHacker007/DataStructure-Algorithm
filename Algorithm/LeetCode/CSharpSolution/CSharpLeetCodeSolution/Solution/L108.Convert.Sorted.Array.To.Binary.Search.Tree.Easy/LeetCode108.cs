namespace Solution {
    public class LeetCode108TreeNode {
        public int val;
        public LeetCode108TreeNode left;
        public LeetCode108TreeNode right;
        public LeetCode108TreeNode (int val = 0, LeetCode108TreeNode left = null, LeetCode108TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode108 {
        static int[] inputNums;
        #region Left Middle Point
        public static LeetCode108TreeNode SortedArrayToBSTLeftMiddle (int[] nums) {
            inputNums = nums;

            return BuildBSTInPreOrderLeftMiddle (0, inputNums.Length - 1);
        }

        private static LeetCode108TreeNode BuildBSTInPreOrderLeftMiddle (int left, int right) {
            if (left > right) return null;
            // find the middle point 
            var middleIndex = (right - left) / 2 + left;
            // construct the node 
            var root = new LeetCode108TreeNode (inputNums[middleIndex]);
            // build the left tree
            root.left = BuildBSTInPreOrderLeftMiddle (left, middleIndex - 1);
            // build the right tree
            root.right = BuildBSTInPreOrderLeftMiddle (middleIndex + 1, right);
            return root;
        }
        #endregion

    }
}