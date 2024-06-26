## Summary

We have to determine the maximum profit that can be obtained by making the transactions (no limit on the number of transactions done). For this we need to find out those sets of buying and selling prices which together lead to the maximization of profit.

## Solution

------

#### Approach 1: Brute Force

In this case, we simply calculate the profit corresponding to all the possible sets of transactions and find out the maximum profit out of them.

```java
class Solution {
    public int maxProfit(int[] prices) {
        return calculate(prices, 0);
    }

    public int calculate(int prices[], int s) {
        if (s >= prices.length)
            return 0;
        int max = 0;
        for (int start = s; start < prices.length; start++) {
            int maxprofit = 0;
            for (int i = start + 1; i < prices.length; i++) {
                if (prices[start] < prices[i]) {
                    int profit = calculate(prices, i + 1) + prices[i] - prices[start];
                    if (profit > maxprofit)
                        maxprofit = profit;
                }
            }
            if (maxprofit > max)
                max = maxprofit;
        }
        return max;
    }
}
```

**Complexity Analysis**

- Time complexity : O(n^n)*O*(*n**n*). Recursive function is called n^n*n**n* times.
- Space complexity : O(n)*O*(*n*). Depth of recursion is n*n*.

---

#### Approach 2: Peak Valley Approach

**Algorithm**

Say the given array is:

[7, 1, 5, 3, 6, 4].

If we plot the numbers of the given array on a graph, we get:

![Profit Graph](https://leetcode.com/media/original_images/122_maxprofit_1.PNG)

If we analyze the graph, we notice that the points of interest are the consecutive valleys and peaks.

Mathematically speaking: Total Profit= \sum_{i}(height(peak_i)-height(valley_i))*T**o**t**a**l**P**r**o**f**i**t*=∑*i*(*h**e**i**g**h**t*(*p**e**a**k**i*)−*h**e**i**g**h**t*(*v**a**l**l**e**y**i*))

The key point is we need to consider every peak immediately following a valley to maximize the profit. In case we skip one of the peaks (trying to obtain more profit), we will end up losing the profit over one of the transactions leading to an overall lesser profit.

For example, in the above case, if we skip peak_i*p**e**a**k**i* and valley_j*v**a**l**l**e**y**j* trying to obtain more profit by considering points with more difference in heights, the net profit obtained will always be lesser than the one obtained by including them, since C*C* will always be lesser than A+B*A*+*B*.

```java
class Solution {
    public int maxProfit(int[] prices) {
        int i = 0;
        int valley = prices[0];
        int peak = prices[0];
        int maxprofit = 0;
        while (i < prices.length - 1) {
            while (i < prices.length - 1 && prices[i] >= prices[i + 1])
                i++;
            valley = prices[i];
            while (i < prices.length - 1 && prices[i] <= prices[i + 1])
                i++;
            peak = prices[i];
            maxprofit += peak - valley;
        }
        return maxprofit;
    }
}
```

**Complexity Analysis**

- Time complexity : O(n)*O*(*n*). Single pass.

- Space complexity : O(1)*O*(1). Constant space required.

  

------

#### Approach 3: Simple One Pass

**Algorithm**

This solution follows the logic used in [Approach 2](https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/solution/#approach-2-peak-valley-approach) itself, but with only a slight variation. In this case, instead of looking for every peak following a valley, we can simply go on crawling over the slope and keep on adding the profit obtained from every consecutive transaction. In the end,we will be using the peaks and valleys effectively, but we need not track the costs corresponding to the peaks and valleys along with the maximum profit, but we can directly keep on adding the difference between the consecutive numbers of the array if the second number is larger than the first one, and at the total sum we obtain will be the maximum profit. This approach will simplify the solution. This can be made clearer by taking this example:

[1, 7, 2, 3, 6, 7, 6, 7]

The graph corresponding to this array is:

![Profit Graph](https://leetcode.com/media/original_images/122_maxprofit_2.PNG)

From the above graph, we can observe that the sum A+B+C*A*+*B*+*C* is equal to the difference D*D* corresponding to the difference between the heights of the consecutive peak and valley.



```java
class Solution {
    public int maxProfit(int[] prices) {
        int maxprofit = 0;
        for (int i = 1; i < prices.length; i++) {
            if (prices[i] > prices[i - 1])
                maxprofit += prices[i] - prices[i - 1];
        }
        return maxprofit;
    }
}
```

**Complexity Analysis**

- Time complexity : O(n)*O*(*n*). Single pass.
- Space complexity: O(1)*O*(1). Constant space needed.