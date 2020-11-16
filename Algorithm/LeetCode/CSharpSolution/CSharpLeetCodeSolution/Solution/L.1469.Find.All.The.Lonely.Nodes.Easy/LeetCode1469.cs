using System;
using System.Collections.Generic;
namespace Solution {

    public class LeetCode1469Node {
        public int val;
        public LeetCode1469Node left;
        public LeetCode1469Node right;
        public LeetCode1469Node (int val = 0, LeetCode1469Node left = null, LeetCode1469Node right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public class LeetCode1469 {
            static IList<int> results = new List<int> ();

            public static IList<int> GetLonelyNodes (LeetCode1469Node root) {

                AddLonelyNodes (root);
                return results;
            }

            private static void AddLonelyNodes (LeetCode1469Node root) {
                if (root == null) return;

                if (HasRightChild (root)) {
                    results.Add (root.right.val);
                }

                if (HasLeftChild (root)) {
                    results.Add (root.left.val);
                }

                AddLonelyNodes (root.left);
                AddLonelyNodes (root.right);
            }

            private static bool HasRightChild (LeetCode1469Node root) {
                return root.left == null && root.right != null;
            }

            private static bool HasLeftChild (LeetCode1469Node root) {
                return root.left != null && root.right == null;
            }
        }
    }
}