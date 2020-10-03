using System.Collections.Generic;

namespace Solution {

    public class LeetCode653TreeNode {
        public int val;
        public LeetCode653TreeNode left;
        public LeetCode653TreeNode right;
        public LeetCode653TreeNode (int val = 0, LeetCode653TreeNode left = null, LeetCode653TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode653 {

        public static List<int> sortedTreeResults = new List<int>();
        public static bool FindTarget (LeetCode653TreeNode root, int k) {
            InOrder(root);
            
            foreach(var item in sortedTreeResults) {
                var targetNum = k - item;
                if (item != targetNum && sortedTreeResults.Contains(targetNum)) {
                    return true;
                }
            }

            return false;
        }

        private static void InOrder(LeetCode653TreeNode root) {
            if (root == null) return;

            InOrder(root.left);
            sortedTreeResults.Add(root.val);
            InOrder(root.right);
        }
    }

}