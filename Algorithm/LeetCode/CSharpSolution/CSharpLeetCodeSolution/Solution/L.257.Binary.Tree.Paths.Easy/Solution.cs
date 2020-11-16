using System.Collections.Generic;

namespace Solution {
    public class LeetCode257TreeNode {
        public int val;
        public LeetCode257TreeNode left;
        public LeetCode257TreeNode right;
        public LeetCode257TreeNode (int val = 0, LeetCode257TreeNode left = null, LeetCode257TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public bool IsLeaftNode () {
            return left == null && right == null;
        }
    }

    public class LeetCode257 {
        public static IList<string> BinaryTreePaths (LeetCode257TreeNode root) {
            var paths = new List<string> ();
            PreOrder (root, "", paths);
            return paths;
        }

        private static void PreOrder (LeetCode257TreeNode root, string path, List<string> paths) {
            if (root == null) return;
            path += root.val.ToString ();
            if (root.IsLeaftNode ()) {
                paths.Add (path);
            } else {
                path += "->";
                PreOrder (root.left, path, paths);
                PreOrder (root.right, path, paths);
            }
        }
    }
}