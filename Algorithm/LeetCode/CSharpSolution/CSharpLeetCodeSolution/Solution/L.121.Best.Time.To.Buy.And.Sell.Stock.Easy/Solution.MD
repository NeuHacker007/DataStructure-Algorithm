## Solution

We need to find out the maximum difference (which will be the maximum profit) between two numbers in the given array. Also, the second number (selling price) must be larger than the first one (buying price).

In formal terms, we need to find \max(\text{prices[j]} - \text{prices[i]})max(prices[j]−prices[i]), for every i*i* and j*j* such that j > i*j*>*i*.

------

#### Approach 1: Brute Force

```java
public class Solution {
    public int maxProfit(int prices[]) {
        int maxprofit = 0;
        for (int i = 0; i < prices.length - 1; i++) {
            for (int j = i + 1; j < prices.length; j++) {
                int profit = prices[j] - prices[i];
                if (profit > maxprofit)
                    maxprofit = profit;
            }
        }
        return maxprofit;
    }
}
```

**Complexity Analysis**

- Time complexity : O(n^2)*O*(*n*2). Loop runs \dfrac{n (n-1)}{2}2*n*(*n*−1) times.
- Space complexity : O(1)*O*(1). Only two variables - \text{maxprofit}maxprofit and \text{profit}profit are used.

---

#### Approach 2: One Pass

**Algorithm**

Say the given array is:

[7, 1, 5, 3, 6, 4]

If we plot the numbers of the given array on a graph, we get:

![](img/121_profit_graph.png)

The points of interest are the peaks and valleys in the given graph. We need to find the largest peak following the smallest valley. We can maintain two variables - minprice and maxprofit corresponding to the smallest valley and maximum profit (maximum difference between selling price and minprice) obtained so far respectively.



```java
public class Solution {
    public int maxProfit(int prices[]) {
        int minprice = Integer.MAX_VALUE;
        int maxprofit = 0;
        for (int i = 0; i < prices.length; i++) {
            if (prices[i] < minprice)
                minprice = prices[i];
            else if (prices[i] - minprice > maxprofit)
                maxprofit = prices[i] - minprice;
        }
        return maxprofit;
    }
}
```

**Complexity Analysis**

- Time complexity : O(n)*O*(*n*). Only a single pass is needed.
- Space complexity : O(1)*O*(1). Only two variables are used.

---

### DP Solution

[团灭 LeetCode 股票买卖问题 :: labuladong的算法小抄](https://labuladong.github.io/algo/3/24/89/)

