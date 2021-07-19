### Solution

----

#### Approach 1: Iteration

**Intuition**

Let's start from the simplest but not optimal solution to discuss the idea.

Binary tree could be considered as a number of slots to fulfill. At the start there is just one slot available for a number or null node. Both number and null node take one slot to be placed. For the null node the story ends up here, whereas the number will add into the tree two slots for the child nodes. Each child node could be, again, a number or a null.

> The idea is straightforward : take the nodes one by one from preorder traversal, and compute the number of available slots. If at the end all available slots are used up, the preorder traversal represents the valid serialization.

- In the beginning there is one available slot.
- Each number or null consumes one slot.
- Null node adds no slots, whereas each number adds two slots for the child nodes.

![](img/rules.png)

**Algorithm**

- Initiate the number of available slots: `slots = 1`.
- Split preorder traversal by comma, and iterate over the resulting array. At each step :
  - Both a number or a null node take one slot : `slots = slot - 1`.
  - If the number of available slots is negative, the preorder traversal is invalid, return False.
  - Non-empty node `node != '#'` creates two more available slots: `slots = slots + 2`.
- Preorder traversal is valid if all available slots are used up : return `slots == 0`.

**Implementation**

```java
class Solution {
  public boolean isValidSerialization(String preorder) {
    // number of available slots
    int slots = 1;

    for(String node : preorder.split(",")) {
      // one node takes one slot
      --slots;

      // no more slots available
      if (slots < 0) return false;

      // non-empty node creates two children slots
      if (!node.equals("#")) slots += 2;
    }

    // all slots should be used up
    return slots == 0;
  }
}
```

**Complexity Analysis**

- Time complexity : \mathcal{O}(N)O(*N*) to iterate over the string of length N.
- Space complexity : \mathcal{O}(N)O(*N*) to keep split array in memory.

----

#### Approach 2: One pass

**Intuition**

Approach 1 uses \mathcal{O}(N)O(*N*) space to keep split array in memory, and for sure that should be optimised. The idea is to iterate over the string itself and not over the array of nodes.

During the iteration, one has to update the number of available slots at each comma character. First, one should decrease the number of slots by one, because both empty and non-empty node take one slot. Second, if the node is a non-empty one, i.e. the character just before the comma is not equal to `#`, one should add two more slots for the child nodes.

The last node should be considered separately, since there is no comma after it.



**Algorithm**

- Initiate the number of available slots: `slots = 1`.
- Iterate over the string. At each comma :
  - Both a number or a null node take one slot : `slots = slot - 1`.
  - If the number of available slots is negative, the preorder traversal is invalid, return False.
  - Non-empty node, detected by non-`#` character before comma, creates two more available slots: `slots = slots + 2`.
- The last node should be considered separately, since there is no comma after it.
- Preorder traversal is valid if all available slots are used up : return `slots == 0`.

```java
class Solution {
  public boolean isValidSerialization(String preorder) {
    // number of available slots
    int slots = 1;

    int n = preorder.length();
    for(int i = 0; i < n; ++i) {
      if (preorder.charAt(i) == ',') {
        // one node takes one slot
        --slots;

        // no more slots available
        if (slots < 0) return false;

        // non-empty node creates two children slots
        if (preorder.charAt(i - 1) != '#') slots += 2;
      }
    }

    // the last node
    slots = (preorder.charAt(n - 1) == '#') ? slots - 1 : slots + 1;
    // all slots should be used up
    return slots == 0;
  }
}
```



**Complexity Analysis**

- Time complexity : \mathcal{O}(N)O(*N*) to iterate over the string of length N.
- Space complexity : \mathcal{O}(1)O(1), it's a constant space solution.