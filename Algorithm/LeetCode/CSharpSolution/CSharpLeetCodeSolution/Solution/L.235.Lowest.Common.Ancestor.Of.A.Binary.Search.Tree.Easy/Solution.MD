#### Solution

We can solve this using the approaches to find [LCA in a binary tree](https://leetcode.com/articles/lowest-common-ancestor-of-a-binary-tree/).

But, binary search tree's property could be utilized, to come up with a better algorithm.

Lets review properties of a BST:


> 1. Left subtree of a node N contains nodes whose values are lesser than or equal to node N's value.
> 2. Right subtree of a node N contains nodes whose values are greater than node N's value.
> 3. Both left and right subtrees are also BSTs.
Approach 1: Recursive Approach


#### Approach 1: Recursive Approach
**Intuition**

Lowest common ancestor for two nodes `p` and `q` would be the last ancestor node common to both of them. Here `last` is defined in terms of the depth of the node. The below diagram would help in understanding what `lowest` means.

![](235_LCA_Binary_1.png)

Note: One of `p` or `q` would be in the left subtree and the other in the right subtree of the LCA node.

Following cases are possible:

![](235_LCA_Binary_2.png)

**Algorithm**

> 1. Start traversing the tree from the root node.
> 2. If both the nodes `p` and `q` are in the right subtree, then continue > the search with right subtree starting step 1.
> 3. If both the nodes `p` and `q` are in the left subtree, then continue the search with left subtree starting step 1.
> 4. If both step 2 and step 3 are not true, this means we have found the node which is common to node `p`'s and `q`'s subtrees. and hence we return this common node as the LCA.

```Java
class Solution {
    public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {

        // Value of current node or parent node.
        int parentVal = root.val;

        // Value of p
        int pVal = p.val;

        // Value of q;
        int qVal = q.val;

        if (pVal > parentVal && qVal > parentVal) {
            // If both p and q are greater than parent
            return lowestCommonAncestor(root.right, p, q);
        } else if (pVal < parentVal && qVal < parentVal) {
            // If both p and q are lesser than parent
            return lowestCommonAncestor(root.left, p, q);
        } else {
            // We have found the split point, i.e. the LCA node.
            return root;
        }
    }
}
```

**Complexity Analysis**

* Time Complexity: O(N)O(N), where NN is the number of nodes in the BST. In the worst case we might be visiting all the nodes of the BST.

* Space Complexity: O(N)O(N). This is because the maximum amount of space utilized by the recursion stack would be NN since the height of a skewed BST could be NN.

---

#### Approach 2: Iterative Approach
**Algorithm**

The steps taken are also similar to approach 1. The only difference is instead of recursively calling the function, we traverse down the tree iteratively. This is possible without using a stack or recursion since we don't need to backtrace to find the LCA node. In essence of it the problem is iterative, it just wants us to find the split point. The point from where p and q won't be part of the same subtree or when one is the parent of the other.

```java
class Solution {
    public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {

        // Value of p
        int pVal = p.val;

        // Value of q;
        int qVal = q.val;

        // Start from the root node of the tree
        TreeNode node = root;

        // Traverse the tree
        while (node != null) {

            // Value of ancestor/parent node.
            int parentVal = node.val;

            if (pVal > parentVal && qVal > parentVal) {
                // If both p and q are greater than parent
                node = node.right;
            } else if (pVal < parentVal && qVal < parentVal) {
                // If both p and q are lesser than parent
                node = node.left;
            } else {
                // We have found the split point, i.e. the LCA node.
                return node;
            }
        }
        return null;
    }
}
```