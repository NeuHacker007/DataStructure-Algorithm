### Solution

#### Approach 1: Recursive Inorder Traversal
It's a very straightforward approach with O(N) time complexity. The idea is to build an inorder traversal of BST which is an array sorted in the ascending order. Now the answer is the k - 1th element of this array.
![](img/inorder.png)

```java
class Solution {
  public ArrayList<Integer> inorder(TreeNode root, ArrayList<Integer> arr) {
    if (root == null) return arr;
    inorder(root.left, arr);
    arr.add(root.val);
    inorder(root.right, arr);
    return arr;
  }

  public int kthSmallest(TreeNode root, int k) {
    ArrayList<Integer> nums = inorder(root, new ArrayList<Integer>());
    return nums.get(k - 1);
  }
}
```
**Complexity Analysis**

* Time complexity : O(N) to build a traversal.
* Space complexity : O(N) to keep an inorder traversal.
---
#### Approach 2: Iterative Inorder Traversal
The above recursion could be converted into iteration, with the help of stack. This way one could speed up the solution because there is no need to build the entire inorder traversal, and one could stop after the kth element.

![](img/iteration.png)

Complexity Analysis

* Time complexity: O(H+k), where H is a tree height. This complexity is defined by the stack, which contains at least H + k elements, since before starting to pop out one has to go down to a leaf. This results in O(logN+k) for the balanced tree and O(N+k) for completely unbalanced tree with all the nodes in the left subtree.
* Space complexity: O(H) to keep the stack, where HH is a tree height. That makes O(N) in the worst case of the skewed tree, and O(logN) in the average case of the balanced tree.

----
#### Follow up
> What if the BST is modified (insert/delete operations) often and you need to find the kth smallest frequently? How would you optimize the kthSmallest routine?

[Insert](https://leetcode.com/articles/insert-into-a-bst/) and [delete](https://leetcode.com/articles/delete-node-in-a-bst/) in a BST were discussed last week, the time complexity of these operations is O(H), where HH is a height of binary tree, and H = log N for the balanced tree.

Hence without any optimisation insert/delete + search of kth element has O(2H+k) complexity. How to optimise that?

That's a design question, basically we're asked to implement a structure which contains a BST inside and optimises the following operations :

  * Insert

  * Delete

  * Find kth smallest

Seems like a database description, isn't it? Let's use here the same logic as for [LRU cache](https://leetcode.com/articles/lru-cache/) design, and combine an indexing structure (we could keep BST here) with a double linked list.

Such a structure would provide:

* O(H) time for the insert and delete.

* O(k) for the search of kth smallest.

![](img/linked_list2.png)

The overall time complexity for insert/delete + search of kth smallest is O(H+k) instead of O(2H+k).

**Complexity Analysis**

* Time complexity for insert/delete + search of kth smallest: O(H+k), where H is a tree height. O(logN+k) in the average case, O(N+k) in the worst case.

* Space complexity : O(N) to keep the linked list.