using System;
using System.Collections.Generic;
namespace Solution {
    public class LeetCode559Node {
        public int Val;
        public IList<LeetCode559Node> Children;

        public LeetCode559Node (int val, IList<LeetCode559Node> children) {
            this.Val = val;
            this.Children = children;
        }
    }
    public class LeetCode559 {
        static int max = 0;
        public static int MaxDepthRecursive (LeetCode559Node root) {
            // the root node considered as 1 
            MaxDepth (root, 1);
            return max;
        }

        private static void MaxDepth (LeetCode559Node root, int level) {
            if (root == null) return;

            // Pre-order traversal
            // first visit the node 
            max = Math.Max (max, level);

            foreach (var child in root.Children) {
                // go to next level (deeper)
                MaxDepth (child, level + 1);
            }

        }
    }
}