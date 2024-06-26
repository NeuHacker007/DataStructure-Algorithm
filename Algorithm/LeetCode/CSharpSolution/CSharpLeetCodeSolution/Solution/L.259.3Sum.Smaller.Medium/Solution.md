### Solution
---
#### Approach 1: Brute Force

**Intuition**

Find every possible set of triplets (i, j, k)(i,j,k) such that i < j < ki<j<k and test for the condition.

**Complexity analysis**

-   Time complexity: O(n^3)O(n3). The total number of such triplets is \binom{n}{3}(3n​), which is \frac{n!}{(n - 3)! \times 3!} = \frac{n \times (n - 1) \times (n - 2)}{6}(n−3)!×3!n!​=6n×(n−1)×(n−2)​. Therefore, the time complexity of the brute force approach is O(n^3)O(n3).
    
-   Space complexity: O(1)O(1).
    

---

#### Approach 2: Binary Search

**Intuition**

Before we solve the _threeSum_ problem, solve this simpler _twoSum_ version:

> Given a numsnums array, find the number of index pairs ii, jj with 0 \leq i < j < n0≤i<j<n that satisfy the condition nums[i] + nums[j] < targetnums[i]+nums[j]<target

If we sort the array first, then we can apply binary search to find the largest index jj such that nums[i] + nums[j] < targetnums[i]+nums[j]<target for each ii. Once we have found that largest index jj, we know there must be j-ij−i pairs that satisfy the above condition with ii's value fixed.

Finally, we can now apply the _twoSum_ solution to _threeSum_ directly by wrapping an outer for-loop around it.

**Implementation**

```java
class Solution {
    public int threeSumSmaller(int[] nums, int target) {
        Arrays.sort(nums);
        int sum = 0;
        for (int i = 0; i < nums.length - 2; i++) {
            sum += twoSumSmaller(nums, i + 1, target - nums[i]);
        }
        return sum;
    }

    private int twoSumSmaller(int[] nums, int startIndex, int target) {
        int sum = 0;
        for (int i = startIndex; i < nums.length - 1; i++) {
            int j = binarySearch(nums, i, target - nums[i]);
            sum += j - i;
        }
        return sum;
    }

    private int binarySearch(int[] nums, int startIndex, int target) {
        int left = startIndex;
        int right = nums.length - 1;
        while (left < right) {
            int mid = (left + right + 1) / 2;
            if (nums[mid] < target) {
                left = mid;
            } else {
                right = mid - 1;
            }
        }
        return left;
    }
}
```
Note that in the above binary search we choose the upper middle element (\frac{left+right+1}{2})(2left+right+1​) instead of the lower middle element (\frac{left+right}{2})(2left+right​). The reason is due to the terminating condition when there are two elements left. If we chose the lower middle element and the condition nums[mid] < targetnums[mid]<target evaluates to true, then the loop would never terminate. Choosing the upper middle element will guarantee termination.

**Complexity analysis**

-   Time complexity: O(n^2 \log n)O(n2logn). The _binarySearch_ function takes O(\log n)O(logn) time, therefore the _twoSumSmaller_ takes O(n \log n)O(nlogn) time. The _threeSumSmaller_ wraps with another for-loop, and therefore is O(n^2 \log n)O(n2logn) time.
    
-   Space complexity: O(1)O(1) because no additional data structures are used.
    

---

#### Approach 3: Two Pointers

**Intuition**

Let us try sorting the array first. For example, nums = [3,5,2,8,1]nums=[3,5,2,8,1] becomes [1,2,3,5,8][1,2,3,5,8].

Let us look at an example nums = [1,2,3,5,8]nums=[1,2,3,5,8], and target = 7target=7.

```
[1, 2, 3, 5, 8]
 ↑           ↑
left       right
```

Let us initialize two indices, leftleft and rightright pointing to the first and last element respectively.

When we look at the sum of first and last element, it is 1 + 8 = 91+8=9, which is \geq target≥target. That tells us no index pair will ever contain the index rightright. So the next logical step is to move the right pointer one step to its left.

```
[1, 2, 3, 5, 8]
 ↑        ↑
left    right
```

Now the pair sum is 1 + 5 = 61+5=6, which is less than targettarget. How many pairs with one of the index = leftindex=left that satisfy the condition? You can tell by the difference between rightright and leftleft which is 33, namely (1,2), (1,3),(1,2),(1,3), and (1,5)(1,5). Therefore, we move leftleft one step to its right.

**Implementation**
```java
class Solution {
    public int threeSumSmaller(int[] nums, int target) {
        Arrays.sort(nums);
        int sum = 0;
        for (int i = 0; i < nums.length - 2; i++) {
            sum += twoSumSmaller(nums, i + 1, target - nums[i]);
        }
        return sum;
    }

    private int twoSumSmaller(int[] nums, int startIndex, int target) {
        int sum = 0;
        int left = startIndex;
        int right = nums.length - 1;
        while (left < right) {
            if (nums[left] + nums[right] < target) {
                sum += right - left;
                left++;
            } else {
                right--;
            }
        }
        return sum;
    }
}
```
**Complexity analysis**

-   Time complexity: O(n^2)O(n2). _twoSumSmaller_ takes O(n)O(n) at most since it touches each element in the array once. It's parent function, _threeSumSmaller_ takes O(n\log n)O(nlogn) to sort the array, then runs a loop that touches (n - 2)(n−2) elements, invoking _twoSumSmaller_ at each iteration. Therefore, the overall time complexity is O(n\log n + n^2)O(nlogn+n2), which boils down to O(n^2)O(n2).
    
-   Space complexity: O(1)O(1) because no additional data structures are used.