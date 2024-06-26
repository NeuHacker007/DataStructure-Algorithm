### Solution

---

#### Approach #1 Using Recursion(DFS) [Accepted]

If the given depth d*d* happens to be equal to 1, we can directly put the whole current tree as a left child of the newly added node. Otherwise, we need to put the new node at appropriate levels.

To do so, we make use of a recursive function `insert(val,node,depth,n)`. Here, val*v**a**l* refers to the value of the new node to be inserted, depth*d**e**p**t**h* refers to the depth of the node currently considered, node*n**o**d**e* refers to the node calling the current function for its child subtrees and n*n* refers to the height at which the new node needs to be inserted.

For inserting the new node at appropriate level, we can start by making a call to `insert` with the root node and 1 as the current level. Inside every such call, we check if we've reached one level prior to the level where the new node needs to be inserted.

From this level, we can store the roots of the left and right subtrees of the current node temporarily, and insert the new node as the new left and right subchild of the current node, with the temporarily stored left and right subtrees as the left and right subtrees of the newly inserted left or right subchildren appropriately.

But, if we haven't reached the destined level, we keep on continuing the recursive calling process with the left and right children of the current node respectively. At every such call, we also incrmenet the depth of the current level to reflect the depth change appropriately.

The animation below illustrates the process:

```java
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode addOneRow(TreeNode t, int v, int d) {
        if (d == 1) {
            TreeNode n = new TreeNode(v);
            n.left = t;
            return n;
        }
        insert(v, t, 1, d);
        return t;
    }

    public void insert(int val, TreeNode node, int depth, int n) {
        if (node == null)
            return;
        if (depth == n - 1) {
            TreeNode t = node.left;
            node.left = new TreeNode(val);
            node.left.left = t;
            t = node.right;
            node.right = new TreeNode(val);
            node.right.right = t;
        } else {
            insert(val, node.left, depth + 1, n);
            insert(val, node.right, depth + 1, n);
        }
    }
}

```

**Complexity Analysis**

- Time complexity : O(n)*O*(*n*). A total of n*n* nodes of the given tree will be considered.
- Space complexity : O(n)*O*(*n*). The depth of the recursion tree can go upto n*n* in the worst case(skewed tree).

---

#### Approach #2 Using stack(DFS) [Accepted]

**Algorithm**

We can do the same task as discussed in the last approach by making use of a stack*s**t**a**c**k* as well. But, we need to make use of a new data structure, Node*N**o**d**e* here, to keep a track of the depth of the current node along with its value.

We start by pushing the root Node*N**o**d**e* onto the stack*s**t**a**c**k*. Then, at every step we do as follows:

- Pop an element from the stack*s**t**a**c**k*.
- For every Node popped, check if its depth corresponds to one prior to the depth at which the new node needs to be inserted.
- If yes, insert the new nodes appropriately as in the last approach.
- If no, we push both the left and the right child Node(value+depth) of the current node onto the stack*s**t**a**c**k*.
- Continue the popping and pushing process till the stack*s**t**a**c**k* becomes empty.

Look at the animation below for a better understanding.

```java
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    class Node{
        Node(TreeNode n,int d){
            node=n;
            depth=d;
        }
        TreeNode node;
        int depth;
    }
    public TreeNode addOneRow(TreeNode t, int v, int d) {
        if (d == 1) {
            TreeNode n = new TreeNode(v);
            n.left = t;
            return n;
        } 
        Stack<Node> stack=new Stack<>();
        stack.push(new Node(t,1));
        while(!stack.isEmpty())
        {
            Node n=stack.pop();
            if(n.node==null)
                continue;
            if (n.depth == d - 1 ) {
                TreeNode temp = n.node.left;
                n.node.left = new TreeNode(v);
                n.node.left.left = temp;
                temp = n.node.right;
                n.node.right = new TreeNode(v);
                n.node.right.right = temp;
                
            } else{
                stack.push(new Node(n.node.left, n.depth + 1));
                stack.push(new Node(n.node.right, n.depth + 1));
            }
        }
        return t;
    }
}

```

**Complexity Analysis**

- Time complexity : O(n)*O*(*n*). A total of n*n* nodes of the given tree will be considered.
- Space complexity : O(n)*O*(*n*). The depth of the stack*s**t**a**c**k* can go upto n*n* in the worst case(skewed tree).

---

#### Approach #3 Using queue(BFS) [Accepted]

**Algorithm**

The idea of traversal in the last approach is similar to Depth First Search. In that case, we need to traverse through all the nodes of the given tree in the order of branches. Firstly we explored one branch to as much depth as possible and then continued with the other ones.

If, instead, we go for Breadth First Search, along with keeping track of the depth of the nodes being considered at any moment during the Breadth First Search, we can stop the search process as soon as all the nodes at the depth d - 1*d*−1 have been considered once.

To implement this BFS, we make use of a queue*q**u**e**u**e*. We start off by pushing the root node of the given tree at the back of the queue*q**u**e**u**e* and with the depth of the current level set as 1. Then, at every step, we do the following:

- Remove an element from the front of the queue*q**u**e**u**e* and add all its children to the back of another temporary queue, temp*t**e**m**p*.
- Keep on adding the elements to the back of the temp*t**e**m**p* till queue*q**u**e**u**e* becomes empty. (Once queue*q**u**e**u**e* becomes empty, it indicates that all the nodes at the current level have been considered and now temp*t**e**m**p* contains all the nodes lying at the next level).
- Reinitialize queue*q**u**e**u**e* with its value as temp*t**e**m**p*. Update the current value of the depth*d**e**p**t**h* to reflect the level of nodes currently being considered.
- Repeat the process till we reach the depth d - 1*d*−1.
- On hitting this depth level(d-1*d*−1), add the new nodes appropriately to all the nodes in the queue*q**u**e**u**e* currently, as done in the previous approaches.

The following animation illustrates the process.

```java
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode addOneRow(TreeNode t, int v, int d) {
        if (d == 1) {
            TreeNode n = new TreeNode(v);
            n.left = t;
            return n;
        }
        Queue < TreeNode > queue = new LinkedList < > ();
        queue.add(t);
        int depth = 1;
        while (depth < d - 1) {
            Queue < TreeNode > temp = new LinkedList < > ();
            while (!queue.isEmpty()) {
                TreeNode node = queue.remove();
                if (node.left != null) temp.add(node.left);
                if (node.right != null) temp.add(node.right);
            }
            queue = temp;
            depth++;
        }
        while (!queue.isEmpty()) {
            TreeNode node = queue.remove();
            TreeNode temp = node.left;
            node.left = new TreeNode(v);
            node.left.left = temp;
            temp = node.right;
            node.right = new TreeNode(v);
            node.right.right = temp;
        }
        return t;
    }
}
```

**Complexity Analysis**

- Time complexity : O(n)*O*(*n*). A total of n*n* nodes of the given tree will be considered in the worst case.
- Space complexity : O(x)*O*(*x*). The size of the queue*q**u**e**u**e* or temp*t**e**m**p* queue can grow upto x*x* only. Here, x*x* refers to the number of maximum number of nodes at any level in the given tree.

