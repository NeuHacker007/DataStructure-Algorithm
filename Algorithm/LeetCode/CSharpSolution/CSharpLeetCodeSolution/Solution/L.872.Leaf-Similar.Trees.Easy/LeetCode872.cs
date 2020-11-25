using System.Collections.Generic;

namespace Solution {
    public class LeetCode872TreeNode {
        public int val;
        public LeetCode872TreeNode left;
        public LeetCode872TreeNode right;
        public LeetCode872TreeNode (int val = 0, LeetCode872TreeNode left = null, LeetCode872TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode872 {
        public static bool IsLeafSimilar (LeetCode872TreeNode root1, LeetCode872TreeNode root2) {
            var leafColl1 = new List<int> ();
            var leafColl2 = new List<int> ();

            GetLeafNodes (root1, leafColl1);
            GetLeafNodes (root2, leafColl2);
            
            if (leafColl1.Count != leafColl2.Count) return false;
            
            for (var i = 0; i < leafColl1.Count; i++) {
                if (leafColl1[i] != leafColl2[i]) {
                    return false;
                }
            }

            return true;

        }

        // this is DFS, preorder traversal
        private static void GetLeafNodes (LeetCode872TreeNode root, IList<int> leafColl) {
            if (root == null) return;

            if (root.left == null && root.right == null) {
                leafColl.Add (root.val);
            }

            GetLeafNodes (root.left, leafColl);
            GetLeafNodes (root.right, leafColl);
        }
    }
}