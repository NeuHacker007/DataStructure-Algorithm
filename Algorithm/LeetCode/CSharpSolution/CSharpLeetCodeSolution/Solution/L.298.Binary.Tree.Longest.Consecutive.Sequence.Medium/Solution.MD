### Solution

----

#### Approach #1 (Top Down Depth-first Search) [Accepted]

**Algorithm**

A top down approach is similar to an in-order traversal. We use a variable `length` to store the current consecutive path length and pass it down the tree. As we traverse, we compare the current node with its parent node to determine if it is consecutive. If not, we reset the length.

```java
private int maxLength = 0;
public int longestConsecutive(TreeNode root) {
    dfs(root, null, 0);
    return maxLength;
}

private void dfs(TreeNode p, TreeNode parent, int length) {
    if (p == null) return;
    length = (parent != null && p.val == parent.val + 1) ? length + 1 : 1;
    maxLength = Math.max(maxLength, length);
    dfs(p.left, p, length);
    dfs(p.right, p, length);
}
```

@lightmark presents [a neat approach](https://leetcode.com/discuss/66486/short-and-simple-c-solution) without storing the maxLength as a global variable.

```java
public int longestConsecutive(TreeNode root) {
    return dfs(root, null, 0);
}

private int dfs(TreeNode p, TreeNode parent, int length) {
    if (p == null) return length;
    length = (parent != null && p.val == parent.val + 1) ? length + 1 : 1;
    return Math.max(length, Math.max(dfs(p.left, p, length),
                                     dfs(p.right, p, length)));
}
```

**Complexity analysis**

- Time complexity : *O*(*n*). The time complexity is the same as an in-order traversal of a binary tree with *n* nodes.
- Space complexity : *O*(*n*). The extra space comes from implicit stack space due to recursion. For a skewed binary tree, the recursion could go up to *n* levels deep.

------

#### Approach #2 (Bottom Up Depth-first Search) [Accepted]

**Algorithm**

The bottom-up approach is similar to a post-order traversal. We return the consecutive path length starting at current node to its parent. Then its parent can examine if its node value can be included in this consecutive path.

```java
private int maxLength = 0;
public int longestConsecutive(TreeNode root) {
    dfs(root);
    return maxLength;
}

private int dfs(TreeNode p) {
    if (p == null) return 0;
    int L = dfs(p.left) + 1;
    int R = dfs(p.right) + 1;
    if (p.left != null && p.val + 1 != p.left.val) {
        L = 1;
    }
    if (p.right != null && p.val + 1 != p.right.val) {
        R = 1;
    }
    int length = Math.max(L, R);
    maxLength = Math.max(maxLength, length);
    return length;
}
```

**Complexity analysis**

- Time complexity : *O*(*n*). The time complexity is the same as a post-order traversal in a binary tree, which is *O*(*n*).
- Space complexity : *O*(*n*). The extra space comes from implicit stack space due to recursion. For a skewed binary tree, the recursion could go up to *n* levels deep.

