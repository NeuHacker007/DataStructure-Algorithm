#### 314.  Binary Tree Vertical Order Traversal

---

Given the `root` of a binary tree, return ***the vertical order traversal** of its nodes' values*. (i.e., from top to bottom, column by column).

If two nodes are in the same row and column, the order should be from **left to right**.

 

**Example 1:**

![](C:\Drive H Work\DataStructure-Algorithm\Algorithm\LeetCode\CSharpSolution\CSharpLeetCodeSolution\Solution\L.314.Binary.Tree.Vertical.Order.Traversal.Medium\img\vtree1.jpg)

```
Input: root = [3,9,20,null,null,15,7]
Output: [[9],[3,15],[20],[7]]
```

**Example 2:**

![](C:\Drive H Work\DataStructure-Algorithm\Algorithm\LeetCode\CSharpSolution\CSharpLeetCodeSolution\Solution\L.314.Binary.Tree.Vertical.Order.Traversal.Medium\img\vtree2-1.jpg)

```
Input: root = [3,9,8,4,0,1,7]
Output: [[4],[9],[3,0,1],[8],[7]]
```

**Example 3:**

![](C:\Drive H Work\DataStructure-Algorithm\Algorithm\LeetCode\CSharpSolution\CSharpLeetCodeSolution\Solution\L.314.Binary.Tree.Vertical.Order.Traversal.Medium\img\vtree2.jpg)

```
Input: root = [3,9,8,4,0,1,7,null,null,null,2,5]
Output: [[4],[9,5],[3,0,1],[8,2],[7]]
```

**Example 4:**

```
Input: root = []
Output: []
```

 

**Constraints:**

- The number of nodes in the tree is in the range `[0, 100]`.
- `-100 <= Node.val <= 100`
