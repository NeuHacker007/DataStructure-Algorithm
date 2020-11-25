#### Solution

##### Iteration

First of all, please refer to this article for the solution in case of binary tree. This [article](https://leetcode.com/articles/binary-tree-preorder-transversal/) offers the same ideas with a bit of generalisation.

First of all, here is the definition of the tree Node which we would use in the following implementation.

Let's start from the root and then at each iteration pop the current node out of the stack and push its child nodes. In the implemented strategy we push nodes into output list following the order `Top->Bottom` and `Left->Right`, that naturally reproduces preorder traversal.

```C#
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
```

**Complexity Analysis**

- Time complexity : we visit each node exactly once, and for each visit, the complexity of the operation (i.e. appending the child nodes) is proportional to the number of child nodes n (n-ary tree). Therefore the overall time complexity is O(N), where N is the number of nodes, i.e. the size of tree.

- Space complexity : depending on the tree structure, we could keep up to the entire tree, therefore, the space complexity is \mathcal{O}(N)O(N).
