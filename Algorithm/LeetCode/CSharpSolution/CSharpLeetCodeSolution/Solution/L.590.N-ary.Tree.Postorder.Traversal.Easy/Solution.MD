# Solution

### How to traverse the tree

First of all, please refer to this article for the solution in case of binary tree. This article offers the same ideas with a bit of generalisation.

There are two general strategies to traverse a tree:

- Breadth First Search (BFS)

  We scan through the tree level by level, following the order of height, from top to bottom. The nodes on higher level would be visited before the ones with lower levels.

- Depth First Search (DFS)

  In this strategy, we adopt the depth as the priority, so that one would start from a root and reach all the way down to certain leaf, and then back to root to reach another branch.

  The DFS strategy can further be distinguished as preorder, inorder, and postorder depending on the relative order among the root node, left node and right node.

On the following figure the nodes are numerated in the order you visit them, please follow `1-2-3-4-5` to compare different strategies.

![](145_transverse.png)

**Iteration**

Let's start from the root and then at each iteration pop the current node out of the stack and push its child nodes. In the implemented strategy we push nodes into stack following the order `Top->Bottom` and `Left->Right`. Since DFS postorder traversal is `Bottom->Top` and `Left->Right` the output list should be reverted after the end of loop.

```Java
class Solution {
  public List<Integer> postorder(Node root) {
    LinkedList<Node> stack = new LinkedList<>();
    LinkedList<Integer> output = new LinkedList<>();
    if (root == null) {
      return output;
    }

    stack.add(root);
    while (!stack.isEmpty()) {
      Node node = stack.pollLast();
      output.addFirst(node.val);
      for (Node item : node.children) {
        if (item != null) {
          stack.add(item);
        }
      }
    }
    return output;
  }
}
```

**Complexity Analysis**

- Time complexity : we visit each node exactly once, thus the time complexity is O(N), where N is the number of nodes, i.e. the size of tree.
- Space complexity : depending on the tree structure, we could keep up to the entire tree, therefore, the space complexity is O(N).
