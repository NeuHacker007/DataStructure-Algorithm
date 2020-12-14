### Solution

#### Approach 2: Iterative Preorder Traversal: Tweak the Order of the Output
Let's start from the root, and at each iteration, pop the current node out of the stack and push its child nodes. In the implemented strategy, we push nodes into stack following the order Top->Bottom and Left->Right. Since DFS postorder transversal is Bottom->Top and Left->Right the output list should be reverted after the end of the loop.

```java
class Solution {
    public List<Integer> postorderTraversal(TreeNode root) {
        LinkedList<Integer> output = new LinkedList();
        Deque<TreeNode> stack = new ArrayDeque();
        
        if (root == null) return output;

        stack.push(root);
        while (!stack.isEmpty()) {
            root = stack.pop();
            output.addFirst(root.val);
            if (root.left != null) stack.push(root.left);
            if (root.right != null) stack.push(root.right);
        }

        return output;
    }
}
```

**Complexity Analysis**

* Time complexity: O(N), where NN is the number of nodes. We visit each node exactly once, thus the time complexity is O(N).

* Space complexity: O(N). Up to O(H) to keep the stack, where HH is a tree height. In the worst case of the skewed tree H=N.

---

Approach 3: Iterative Postorder Traversal
Algorithm

The idea is to fulfill the stack following right->node->left strategy. One could pop the last node out of the stack and check if it's the leftmost leaf. If yes, it's time to update the output. Otherwise, one should swap the last two nodes in the stack and repeat all these steps.

```java
class Solution {
    public List<Integer> postorderTraversal(TreeNode root) {
        List<Integer> output = new ArrayList();
        Deque<TreeNode> stack = new ArrayDeque();
        
        while (root != null || !stack.isEmpty()) {
            // push nodes: right -> node -> left
            while (root != null) {
                if (root.right != null) {
                    stack.push(root.right);    
                }
                stack.push(root);
                root = root.left;    
            }
            
            root = stack.pop();
            
            // if the right subtree is not yet processed
            if (!stack.isEmpty() && root.right == stack.peek()) {
                stack.pop();
                stack.push(root);
                root = root.right;  
            // if we're on the leftmost leaf  
            } else {
                output.add(root.val);
                root = null;     
            }   
        }

        return output;
    }
}
```

