using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Solution {
    public class LeetCode124Node {
        public int val;
        public LeetCode124Node left;
        public LeetCode124Node right;

        public LeetCode124Node (int val = 0, LeetCode124Node left = null, LeetCode124Node right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode124 {
        private static int _answer = int.MinValue;
        public static int MaxPathSum (LeetCode124Node root) {
            GetMaxPathSum (root);
            return _answer;
        }

        private static int GetMaxPathSum (LeetCode124Node root) {
            if (root == null) {
                return 0;
            }

            var left = Math.Max (0, GetMaxPathSum (root.left));
            var right = Math.Max (0, GetMaxPathSum (root.right));

            _answer = Math.Max (_answer, left + right + root.val);

            return root.val + Math.Max (left, right);
        }
    }
}