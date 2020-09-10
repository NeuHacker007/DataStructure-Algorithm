using System.Collections.Generic;
namespace Solution {
    public class LeetCode590Node {
        
        public int val;
        public IList<LeetCode590Node> children;

        public LeetCode590Node () { }

        public LeetCode590Node (int _val) {
            val = _val;
        }

        public LeetCode590Node (int _val, IList<LeetCode590Node> _children) {
            val = _val;
            children = _children;
        }
    }
    public class LeetCode590 {
        static IList<int> results = new List<int>();
        public static IList<int> PostOrderTraversal(LeetCode590Node root) {
            PostOrder(root);
            return results;
        }

        private static void PostOrder(LeetCode590Node root) {
            if (root == null) return;

            foreach (var child in root.children) {
                PostOrder(child);
            }
            results.Add(root.val);
        }
    }
}