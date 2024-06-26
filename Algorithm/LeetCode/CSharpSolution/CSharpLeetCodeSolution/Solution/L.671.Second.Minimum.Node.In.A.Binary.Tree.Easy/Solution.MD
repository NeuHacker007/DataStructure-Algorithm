### Solution

#### Approach #1: Brute Force [Accepted]

**Intuition and Algorithm**

Traverse the tree with a depth-first search, and record every unique value in the tree using a Set structure `uniques`.

Then, we'll look through the recorded values for the second minimum. The first minimum must be root.val.

```java
class Solution {
    public void dfs(TreeNode root, Set<Integer> uniques) {
        if (root != null) {
            uniques.add(root.val);
            dfs(root.left, uniques);
            dfs(root.right, uniques);
        }
    }
    public int findSecondMinimumValue(TreeNode root) {
        Set<Integer> uniques = new HashSet<Integer>();
        dfs(root, uniques);

        int min1 = root.val;
        long ans = Long.MAX_VALUE;
        for (int v : uniques) {
            if (min1 < v && v < ans) ans = v;
        }
        return ans < Long.MAX_VALUE ? (int) ans : -1;
    }
}
```
**Complexity Analysis**

* Time Complexity: O(N), where NN is the total number of nodes in the given tree. We visit each node exactly once, and scan through the O(N) values in unique once.

* Space Complexity: O(N), the information stored in uniques.
---
#### Approach #2: Ad-Hoc [Accepted]
**Intuition and Algorithm**

Let `min1 = root.val`. When traversing the tree at some node, `node`, if `node.val > min1`, we know all values in the subtree at `node` are at least `node.val`, so there cannot be a better candidate for the second minimum in this subtree. Thus, we do not need to search this subtree.

Also, as we only care about the second minimum `ans`, we do not need to record any values that are larger than our current candidate for the second minimum, so unlike Approach #1 we can skip maintaining a Set of values(uniques) entirely.


```java
class Solution {
    int min1;
    long ans = Long.MAX_VALUE;

    public void dfs(TreeNode root) {
        if (root != null) {
            if (min1 < root.val && root.val < ans) {
                ans = root.val;
            } else if (min1 == root.val) {
                dfs(root.left);
                dfs(root.right);
            }
        }
    }
    public int findSecondMinimumValue(TreeNode root) {
        min1 = root.val;
        dfs(root);
        return ans < Long.MAX_VALUE ? (int) ans : -1;
    }
}
```
**Complexity Analysis**

* Time Complexity: O(N)O(N), where NN is the total number of nodes in the given tree. We visit each node at most once.

* Space Complexity: O(N)O(N). The information stored in \text{ans}ans and \text{min1}min1 is O(1)O(1), but our depth-first search may store up to O(h) = O(N)O(h)=O(N) information in the call stack, where hh is the height of the tree.
