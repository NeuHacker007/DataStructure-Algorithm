using System.Collections.Generic;
namespace Solution {
    public class LeetCode589Node {
        public int val;
        public IList<LeetCode589Node> children;

        public LeetCode589Node () { }

        public LeetCode589Node (int _val) {
            val = _val;
        }

        public LeetCode589Node (int _val, IList<LeetCode589Node> _children) {
            val = _val;
            children = _children;
        }
    }
    public class LeetCode589 {

        static IList<int> results = new List<int> ();
        public static IList<int> PreOrderTraversal (LeetCode589Node root) {
            PreOrder (root);

            return results;
        }

        private static void PreOrder (LeetCode589Node root) {
            if (root == null) return;
            results.Add (root.val);
            foreach (var child in root.children) {
                PreOrder (child);
            }
        }

        public static IList<int> PreOrderNonRecursive (LeetCode589Node root) {
            Stack<LeetCode589Node> stack = new Stack<LeetCode589Node>();
            IList<int> results = new List<int>();

            if (root == null) return results;
            
            stack.Push(root);

            while (stack.Count != 0) {
                var node = stack.Pop();
                results.Add(node.val);
                var temp = (List<LeetCode589Node>) node.children;
                temp.Reverse();
                foreach (var child in temp) {
                    stack.Push(child);
                }
            }

            return results;
        }
    }

}