### Solution

Approach 1 is the same in LeetCode #116

#### Approach 2: Using previously established next pointers

**Intuition**

We have to process all the nodes of the tree. So we can't reduce the time complexity any further. However, we can try and reduce the space complexity. The reason we need a queue here is because we don't have any idea about the structure of the tree and the kind of branches it has and we need to access all the nodes on a common level, together, and establish connections between them.

Once we are done establishing the `next` pointers between the nodes, don't they kind of represent a linked list? After the `next` connections are established, all the nodes on a particular level actually form a linked list via these `next` pointers. Based on this idea, we have the following intuition for our space efficient algorithm:

> We only move on to the level N+1 when we are done establishing the next pointers for the level N. So, since we have access to all the nodes on a particular level via the next pointers, we can use these next pointers to establish the connections for the next level or the level containing their children.

**Algorithm**

1. We start at the root node. Since there are no more nodes to process on the first level or level `0`, we can establish the next pointers on the next level i.e. level 1. An important thing to remember in this algorithm is that we establish the next pointers for a level N*N* while we are still on level N-1*N*−1 and once we are done establishing these new connections, we move on to N*N* and do the same thing for N+1*N*+1.

2. As we just said, when we go over the nodes of a particular level, their next pointers are already established. This is what helps get rid of the queue data structure from the previous approach and helps save space. To start on a particular level, we just need the `leftmost` node. From there on its just a linked list traversal.

3. Based on these ideas, our algorithm will have the following pseudocode:

   ```
    leftmost = root
    while (leftmost != null)
    {
        curr = leftmost
        prev = NULL
        while (curr != null)
        {
            → process left child
            → process right child
            → set leftmost for the next level
            curr = curr.next
        }
    }
    
   ```

4. Before we proceed with the steps in our algorithm, we need to understand some of the variables we have used above in the pseudocode since they will be important in understanding the implementation.

   1. **leftmost:** represents the corresponding variable on each level. This node is important to discover on each level since this would act as our head of the linked list and we will start our traversal of all the nodes on a level from this node onwards. Since the structure of the tree can be anything, we don't really know what the leftmost node on a level would be. Let's look at a few tree structures and the corresponding leftmost nodes on each level.

      ![](img/img6.png)

      Oh, in case you are interested in a fun problem that find out all such nodes (rightmost instead of leftmost), check out [this problem](https://leetcode.com/problems/binary-tree-right-side-view/description/).

   2. **curr:** As we can see in the pseudocode, this is just the variable we use to traverse all the nodes on the `current` level. It starts off with `leftmost` and then follows the `next` pointers all the way to the very end.

   3. **prev:** This is the pointer to the `leading` node on the `next` level. We need this pointer because whenever we update the node `curr`, we assign `prev.next` to the left child of `curr` if one exists, otherwise the right child. When we do so, we also update the `prev` pointer. Let's consider an example that highlights how the `prev` pointer is updated. Namely, the following example will highlight the 4 possible scenarios for pointer updates:

      - The first case is when the `prev` pointer is assigned a non-null value for the very first time i.e. when it is initialized. We start with a `null` value and when we find the first node on the *next* level i.e whenever we find the very first node on the current level that has at least one child, we assign the leftmost child to `prev`.

        ![](img/img7.png)

        - Next is when the node on the current level doesn't have a left child. We then point `prev` to the right child of the current node. An important thing to remember in this illustration is that the level `2, 3, 5, 9` already has their `next` pointers properly established.

          ![](img/img8.png)

        - Moving on, we have a node with no children. Here, we don't update the `prev` pointer.

          ![](img/img9.png)

          

        - And finally, we come across a node with 2 children. We first update `prev` to the left child and once the necessary processing is done, we update it to the right child.

          ![](img/img10.png)

   

5. Once we are done with the current level, we move on to the next one. One last thing that's left here to update the `leftmost` node. We need that node to start traversal on a particular level. Think of it as the head of the linked list. This is easy to do by using the `prev` pointer. Whenever we set the value for `prev` pointer for the first time corresponding to a level i.e. whenever we set it to it's first node, we also set the head or the `leftmost` to that node. So, in the following image, `leftmost` originally was `2` and now it would change to `4`.

   ![](img/img7.png)

   


```java
class Solution {
    
    Node prev, leftmost;
    
    public void processChild(Node childNode) {
        
        if (childNode != null) {
            
            // If the "prev" pointer is alread set i.e. if we
            // already found atleast one node on the next level,
            // setup its next pointer
            if (this.prev != null) {
                this.prev.next = childNode;
                    
            } else {
                
                // Else it means this child node is the first node
                // we have encountered on the next level, so, we
                // set the leftmost pointer
                this.leftmost = childNode;
            }    
                
            this.prev = childNode; 
        }
    }
        
    public Node connect(Node root) {
        
        if (root == null) {
            return root;
        }
        
        // The root node is the only node on the first level
        // and hence its the leftmost node for that level
        this.leftmost = root;
        
        // Variable to keep track of leading node on the "current" level
        Node curr = leftmost;
        
        // We have no idea about the structure of the tree,
        // so, we keep going until we do find the last level.
        // the nodes on the last level won't have any children
        while (this.leftmost != null) {
            
            // "prev" tracks the latest node on the "next" level
            // while "curr" tracks the latest node on the current
            // level.
            this.prev = null;
            curr = this.leftmost;
            
            // We reset this so that we can re-assign it to the leftmost
            // node of the next level. Also, if there isn't one, this
            // would help break us out of the outermost loop.
            this.leftmost = null;
            
            // Iterate on the nodes in the current level using
            // the next pointers already established.
            while (curr != null) {
                
                // Process both the children and update the prev
                // and leftmost pointers as necessary.
                this.processChild(curr.left);
                this.processChild(curr.right);
                
                // Move onto the next node.
                curr = curr.next;
            }
        }
                
        return root ;
    }
}
```


**Complexity Analysis**

- Time Complexity: O(N)*O*(*N*) since we process each node exactly once.
- Space Complexity: O(1)*O*(1) since we don't make use of any additional data structure for traversing nodes on a particular level like the previous approach does.