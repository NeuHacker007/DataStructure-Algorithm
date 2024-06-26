#### Solution

---

#### Approach 1: Sort an Almost Sorted Array Where Two Elements Are Swapped

**Intuition**

Let's start from straightforward but not optimal solution with a linear time and space complexity. This solution serves to identify and discuss all subproblems.

It's known that [inorder traversal of BST is an array sorted in the ascending order](https://leetcode.com/articles/delete-node-in-a-bst/). Here is how one could compute an inorder traversal

```java
public void inorder(TreeNode root, List<Integer> nums) {
  if (root == null) return;
  inorder(root.left, nums);
  nums.add(root.val);
  inorder(root.right, nums);
}
```

Here two nodes are swapped, and hence inorder traversal is an almost sorted array where only two elements are swapped. To identify two swapped elements in a sorted array is a classical problem that could be solved in linear time. Here is a solution code

```java
public int[] findTwoSwapped(List<Integer> nums) {
  int n = nums.size();
  int x = -1, y = -1;
  for(int i = 0; i < n - 1; ++i) {
    if (nums.get(i + 1) < nums.get(i)) {
      y = nums.get(i + 1);
      // first swap occurence
      if (x == -1) x = nums.get(i);
      // second swap occurence
      else break;
    }
  }
  return new int[]{x, y};
}
```

When swapped nodes are known, one could traverse the tree again and swap their values.

![](img/iinorde.png)

**Algorithm**

Here is the algorithm:

1. Construct inorder traversal of the tree. It should be an almost sorted list where only two elements are swapped.
2. Identify two swapped elements x and y in an almost sorted array in linear time.
3. Traverse the tree again. Change value x to y and value y to x.

**Implementation**

```java
class Solution {
  public void inorder(TreeNode root, List<Integer> nums) {
    if (root == null) return;
    inorder(root.left, nums);
    nums.add(root.val);
    inorder(root.right, nums);
  }

  public int[] findTwoSwapped(List<Integer> nums) {
    int n = nums.size();
    int x = -1, y = -1;
    for(int i = 0; i < n - 1; ++i) {
      if (nums.get(i + 1) < nums.get(i)) {
        y = nums.get(i + 1);
        // first swap occurence
        if (x == -1) x = nums.get(i);
        // second swap occurence
        else break;
      }
    }
    return new int[]{x, y};
  }

  public void recover(TreeNode r, int count, int x, int y) {
    if (r != null) {
      if (r.val == x || r.val == y) {
        r.val = r.val == x ? y : x;
        if (--count == 0) return;
      }
      recover(r.left, count, x, y);
      recover(r.right, count, x, y);
    }
  }

  public void recoverTree(TreeNode root) {
    List<Integer> nums = new ArrayList();
    inorder(root, nums);
    int[] swapped = findTwoSwapped(nums);
    recover(root, 2, swapped[0], swapped[1]);
  }
}
```

**Complexity Analysis**

- Time complexity : \mathcal{O}(N)O(*N*). To compute inorder traversal takes \mathcal{O}(N)O(*N*) time, to identify and to swap back swapped nodes \mathcal{O}(N)O(*N*) in the worst case.

- Space complexity : \mathcal{O}(N)O(*N*) since we keep inorder traversal `nums` with N elements.

  

------

#### What Is Coming Next

In approach 1 we discussed three easy subproblems of this hard problem:

1. Construct inorder traversal.
2. Find swapped elements in an almost sorted array where only two elements are swapped.
3. Swap values of two nodes.

Now we will discuss three more approaches, and basically they are all the same :

- Merge steps 1 and 2, i.e. identify swapped nodes during the inorder traversal.
- Swap node values.

The difference in-between the following approaches is in a chosen method to implement inorder traversal :

- Approach 2 : Iterative.
- Approach 3 : Recursive.
- Approach 4 : Morris.

![](img/mmorris.png)

Iterative and recursive approaches here do less than *one pass*, and they both need up to \mathcal{O}(H)O(*H*) space to keep stack, where H is a tree height.

Morris approach is *two pass* approach, but it's a constant-space one.



------

#### Approach 2: Iterative Inorder Traversal

**Intuition**

Here we construct inorder traversal by iterations and identify swapped nodes at the same time, in one pass.

> Iterative inorder traversal is simple: go left as far as you can, then one step right. Repeat till the end of nodes in the tree.

To identify swapped nodes, track the last node `pred` in the inorder traversal (i.e. the *predecessor* of the current node) and compare it with current node value. If the current node value is smaller than its predecessor `pred` value, the swapped node is here.

There are only two swapped nodes here, and hence one could break after having the second node identified.

Doing so, one could get directly nodes (and not only their values), and hence swap node values in \mathcal{O}(1)O(1) time, drastically reducing the time needed for step 3.

[Don't use Stack in Java, use ArrayDeque instead](https://docs.oracle.com/javase/8/docs/api/java/util/Stack.html).

```java
class Solution {
  public void swap(TreeNode a, TreeNode b) {
    int tmp = a.val;
    a.val = b.val;
    b.val = tmp;
  }

  public void recoverTree(TreeNode root) {
    Deque<TreeNode> stack = new ArrayDeque();
    TreeNode x = null, y = null, pred = null;

    while (!stack.isEmpty() || root != null) {
      while (root != null) {
        stack.add(root);
        root = root.left;
      }
      root = stack.removeLast();
      if (pred != null && root.val < pred.val) {
        y = root;
        if (x == null) x = pred;
        else break;
      }
      pred = root;
      root = root.right;
    }

    swap(x, y);
  }
}
```



**Complexity Analysis**

- Time complexity: \mathcal{O}(N)O(*N*) in the worst case when one of the swapped nodes is a rightmost leaf.

- Space complexity : up to \mathcal{O}(N)O(*N*) to keep the stack in the worst case when the tree is completely lean.

  

------

#### Approach 3: Recursive Inorder Traversal

Iterative approach 2 could be converted into recursive one.

Recursive inorder traversal is extremely simple: follow `Left->Node->Right` direction, i.e. do the recursive call for the *left* child, then do all the business with the node (= if the node is the swapped one or not), and then do the recursive call for the *right* child.

On the following figure the nodes are numerated in the order you visit them, please follow `1-2-3-4-5` to compare different DFS strategies.

![](img/ddfs.png)

```java
class Solution {
  TreeNode x = null, y = null, pred = null;

  public void swap(TreeNode a, TreeNode b) {
    int tmp = a.val;
    a.val = b.val;
    b.val = tmp;
  }

  public void findTwoSwapped(TreeNode root) {
    if (root == null) return;
    findTwoSwapped(root.left);
    if (pred != null && root.val < pred.val) {
      y = root;
      if (x == null) x = pred;
      else return;
    }
    pred = root;
    findTwoSwapped(root.right);
  }

  public void recoverTree(TreeNode root) {
    findTwoSwapped(root);
    swap(x, y);
  }
}
```

**Complexity Analysis**

- Time complexity: \mathcal{O}(N)O(*N*) in the worst case when one of the swapped nodes is a rightmost leaf.

- Space complexity : up to \mathcal{O}(N)O(*N*) to keep the stack in the worst case when the tree is completely lean.

  

------

#### Approach 4: Morris Inorder Traversal

We discussed already iterative and recursive inorder traversals, which both have great time complexity though use up to \mathcal{O}(N)O(*N*) to keep stack. We could trade in performance to save space.

The idea of Morris inorder traversal is simple: to use no space but to traverse the tree.

> How that could be even possible? At each node one has to decide where to go: left or right, traverse left subtree or traverse right subtree. How one could know that the left subtree is already done if no additional memory is allowed?

The idea of [Morris](https://www.sciencedirect.com/science/article/pii/0020019079900681) algorithm is to set the *temporary link* between the node and its [predecessor](https://leetcode.com/articles/delete-node-in-a-bst/): `predecessor.right = root`. So one starts from the node, computes its predecessor and verifies if the link is present.

- There is no link? Set it and go to the left subtree.
- There is a link? Break it and go to the right subtree.

There is one small issue to deal with : what if there is no left child, i.e. there is no left subtree? Then go straightforward to the right subtree.



```java
class Solution {
  public void swap(TreeNode a, TreeNode b) {
    int tmp = a.val;
    a.val = b.val;
    b.val = tmp;
  }

  public void recoverTree(TreeNode root) {
    // predecessor is a Morris predecessor. 
    // In the 'loop' cases it could be equal to the node itself predecessor == root.
    // pred is a 'true' predecessor, 
    // the previous node in the inorder traversal.
    TreeNode x = null, y = null, pred = null, predecessor = null;

    while (root != null) {
      // If there is a left child
      // then compute the predecessor.
      // If there is no link predecessor.right = root --> set it.
      // If there is a link predecessor.right = root --> break it.
      if (root.left != null) {
        // Predecessor node is one step left 
        // and then right till you can.
        predecessor = root.left;
        while (predecessor.right != null && predecessor.right != root)
          predecessor = predecessor.right;

        // set link predecessor.right = root
        // and go to explore left subtree
        if (predecessor.right == null) {
          predecessor.right = root;
          root = root.left;
        }
        // break link predecessor.right = root
        // link is broken : time to change subtree and go right
        else {
          // check for the swapped nodes
          if (pred != null && root.val < pred.val) {
            y = root;
            if (x == null) x = pred;
          }
          pred = root;

          predecessor.right = null;
          root = root.right;
        }
      }
      // If there is no left child
      // then just go right.
      else {
        // check for the swapped nodes
        if (pred != null && root.val < pred.val) {
          y = root;
          if (x == null) x = pred;
        }
        pred = root;

        root = root.right;
      }
    }
    swap(x, y);
  }
}
```

**Complexity Analysis**

- Time complexity : \mathcal{O}(N)O(*N*) since we visit each node up to two times.
- Space complexity : \mathcal{O}(1)O(1).