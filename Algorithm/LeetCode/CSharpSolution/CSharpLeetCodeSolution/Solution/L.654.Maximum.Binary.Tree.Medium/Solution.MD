### Solution

---

#### Approach 1: Recursive Solution

The current solution is very simple. We make use of a function `construct(nums, l, r)`, which returns the maximum binary tree consisting of numbers within the indices l*l* and r*r* in the given nums*n**u**m**s* array(excluding the r^{th}*r**t**h* element).

The algorithm consists of the following steps:

1. Start with the function call `construct(nums, 0, n)`. Here, n*n* refers to the number of elements in the given nums*n**u**m**s* array.

2. Find the index, max_i*m**a**x**i*, of the largest element in the current range of indices (l:r-1)(*l*:*r*−1). Make this largest element, nums[max\_i]*n**u**m**s*[*m**a**x*_*i*] as the local root node.

3. Determine the left child using `construct(nums, l, max_i)`. Doing this recursively finds the largest element in the subarray left to the current largest element.

4. Similarly, determine the right child using `construct(nums, max_i + 1, r)`.

5. Return the root node to the calling function.

   ```java
   public class Solution {
       public TreeNode constructMaximumBinaryTree(int[] nums) {
           return construct(nums, 0, nums.length);
       }
       public TreeNode construct(int[] nums, int l, int r) {
           if (l == r)
               return null;
           int max_i = max(nums, l, r);
           TreeNode root = new TreeNode(nums[max_i]);
           root.left = construct(nums, l, max_i);
           root.right = construct(nums, max_i + 1, r);
           return root;
       }
       public int max(int[] nums, int l, int r) {
           int max_i = l;
           for (int i = l; i < r; i++) {
               if (nums[max_i] < nums[i])
                   max_i = i;
           }
           return max_i;
       }
   }
   ```

   

**Complexity Analysis**

- Time complexity : O(n^2)*O*(*n*2). The function `construct` is called n*n* times. At each level of the recursive tree, we traverse over all the n*n* elements to find the maximum element. In the average case, there will be a \log nlog*n* levels leading to a complexity of O\big(n\log n\big)*O*(*n*log*n*). In the worst case, the depth of the recursive tree can grow upto n*n*, which happens in the case of a sorted nums*n**u**m**s* array, giving a complexity of O(n^2)*O*(*n*2).
- Space complexity : O(n)*O*(*n*). The size of the set*s**e**t* can grow upto n*n* in the worst case. In the average case, the size will be \log nlog*n* for n*n* elements in nums*n**u**m**s*, giving an average case complexity of O(\log n)*O*(log*n*)