using System.Collections.Generic;
namespace Solution {
    public class LeetCode897TreeNode {
        public int val;
        public LeetCode897TreeNode left;
        public LeetCode897TreeNode right;
        public LeetCode897TreeNode (int val = 0, LeetCode897TreeNode left = null, LeetCode897TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode897 {

        static IList<int> results = new List<int> ();
        public static LeetCode897TreeNode IncreasingBST (LeetCode897TreeNode root) {

            InOrder (root);

            var ans = new LeetCode897TreeNode ();
            var cur = ans;

            foreach (var item in results) {
                cur.right = new LeetCode897TreeNode (item);
                cur = cur.right;
            }
            return ans.right;
        }
        private static void InOrder (LeetCode897TreeNode root) {
            if (root == null) return;

            InOrder (root.left);
            results.Add (root.val);
            InOrder (root.right);
        }

    }

}