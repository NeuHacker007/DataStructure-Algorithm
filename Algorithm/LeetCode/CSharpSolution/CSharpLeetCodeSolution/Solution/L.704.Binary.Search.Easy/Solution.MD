## Solution

------

#### Approach 1: Binary Search

**Intuition**

[Binary search](https://leetcode.com/explore/learn/card/binary-search/) is a textbook algorithm based on the idea to compare the target value to the middle element of the array.

If the target value is equal to the middle element - we're done.

If the target value is smaller - continue to search on the left.

If the target value is larger - continue to search on the right.

![](img/search.png)

**Algorithm**

- Initialise left and right pointers : `left = 0`, `right = n - 1`.
- While `left <= right` :
  - Compare middle element of the array `nums[pivot]` to the target value `target`.
    - If the middle element *is* the target `target = nums[pivot]` : return `pivot`.
    - If the target is not yet found :
      - If `target < nums[pivot]`, continue the search on the left `right = pivot - 1`.
      - Else continue the search on the right `left = pivot + 1`.

```java
class Solution {
  public int search(int[] nums, int target) {
    int pivot, left = 0, right = nums.length - 1;
    while (left <= right) {
      pivot = left + (right - left) / 2;
      if (nums[pivot] == target) return pivot;
      if (target < nums[pivot]) right = pivot - 1;
      else left = pivot + 1;
    }
    return -1;
  }
}
```

**Complexity Analysis**

- Time complexity : \mathcal{O}(\log N)O(log*N*).

  Let's compute time complexity with the help of [master theorem](https://en.wikipedia.org/wiki/Master_theorem_(analysis_of_algorithms)) T(N) = aT\left(\frac{N}{b}\right) + \Theta(N^d)*T*(*N*)=*a**T*(*b**N*)+Θ(*N**d*). The equation represents dividing the problem up into a*a* subproblems of size \frac{N}{b}*b**N* in \Theta(N^d)Θ(*N**d*) time. Here at step there is only one subproblem `a = 1`, its size is a half of the initial problem `b = 2`, and all this happens in a constant time `d = 0`. That means that \log_b{a} = dlog*b**a*=*d* and hence we're dealing with [case 2](https://en.wikipedia.org/wiki/Master_theorem_(analysis_of_algorithms)#Case_2_example) that results in \mathcal{O}(n^{\log_b{a}} \log^{d + 1} N)O(*n*log*b**a*log*d*+1*N*) = \mathcal{O}(\log N)O(log*N*) time complexity.

- Space complexity : \mathcal{O}(1)O(1) since it's a constant space solution.