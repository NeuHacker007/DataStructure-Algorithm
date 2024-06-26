### Solution

---

#### Approach #1 (Brute force) [Time Limit Exceeded]

**Intuition**

The problem could be modeled as the following optimization problem : \min_{x} \sum_{i=0}^{n - 1} x_i \\ \text{subject to} \sum_{i=0}^{n - 1} x_i*c_i = Smin*x*∑*i*=0*n*−1*x**i*subject to∑*i*=0*n*−1*x**i*∗*c**i*=*S*

, where S*S* is the amount, c_i*c**i* is the coin denominations, x_i*x**i* is the number of coins with denominations c_i*c**i* used in change of amount S*S*. We could easily see that x_i = [{0, \frac{S}{c_i}}]*x**i*=[0,*c**i**S*].

A trivial solution is to enumerate all subsets of coin frequencies [x_0\dots x_{n - 1}][*x*0…*x**n*−1] that satisfy the constraints above, compute their sums and return the minimum among them.

**Algorithm**

To apply this idea, the algorithm uses backtracking technique to generate all combinations of coin frequencies [x_0\dots x_{n-1}][*x*0…*x**n*−1] in the range ([{0, \frac{S}{c_i}}])([0,*c**i**S*]) which satisfy the constraints above. It makes a sum of the combinations and returns their minimum or -1−1 in case there is no acceptable combination.



```java
public class Solution {

  public int coinChange(int[] coins, int amount) {
    return coinChange(0, coins, amount);
  }

  private int coinChange(int idxCoin, int[] coins, int amount) {
    if (amount == 0)
      return 0;
    if (idxCoin < coins.length && amount > 0) {
      int maxVal = amount/coins[idxCoin];
      int minCost = Integer.MAX_VALUE;
      for (int x = 0; x <= maxVal; x++) {
        if (amount >= x * coins[idxCoin]) {
          int res = coinChange(idxCoin + 1, coins, amount - x * coins[idxCoin]);
          if (res != -1)
            minCost = Math.min(minCost, res + x);
        }
      }
      return (minCost == Integer.MAX_VALUE)? -1: minCost;
    }
    return -1;
  }
}

// Time Limit Exceeded
```

![](img/2021-11-10_7-56-58.png)

----

#### Approach #2 (Dynamic programming - Top down) [Accepted]

**Intuition**

Could we improve the exponential solution above? Definitely! The problem could be solved with polynomial time using Dynamic programming technique. First, let's define:

> F(S)*F*(*S*) - minimum number of coins needed to make change for amount S*S* using coin denominations [{c_0\ldots c_{n-1}}][*c*0…*c**n*−1]

We note that this problem has an optimal substructure property, which is the key piece in solving any Dynamic Programming problems. In other words, the optimal solution can be constructed from optimal solutions of its subproblems. How to split the problem into subproblems? Let's assume that we know F(S)*F*(*S*) where some change val_1, val_2, \ldots*v**a**l*1,*v**a**l*2,… for S*S* which is optimal and the last coin's denomination is C*C*. Then the following equation should be true because of optimal substructure of the problem:

F(S) = F(S - C) + 1*F*(*S*)=*F*(*S*−*C*)+1

But we don't know which is the denomination of the last coin C*C*. We compute F(S - c_i)*F*(*S*−*c**i*) for each possible denomination c_0, c_1, c_2 \ldots c_{n -1}*c*0,*c*1,*c*2…*c**n*−1 and choose the minimum among them. The following recurrence relation holds:

F(S) = \min_{i=0 ... n-1} { F(S - c_i) } + 1 \\ \text{subject to} \ S-c_i \geq 0 \\*F*(*S*)=min*i*=0...*n*−1*F*(*S*−*c**i*)+1subject to *S*−*c**i*≥0

F(S) = 0 , \text{when} S = 0 \\ F(S) = -1 , \text{when} n = 0*F*(*S*)=0,when*S*=0*F*(*S*)=−1,when*n*=0

![](img/322_coin_change_tree.png)

In the recursion tree above, we could see that a lot of subproblems were calculated multiple times. For example the problem F(1)*F*(1) was calculated 1313 times. Therefore we should cache the solutions to the subproblems in a table and access them in constant time when necessary

**Algorithm**

The idea of the algorithm is to build the solution of the problem from top to bottom. It applies the idea described above. It use backtracking and cut the partial solutions in the recursive tree, which doesn't lead to a viable solution. Тhis happens when we try to make a change of a coin with a value greater than the amount *S\*S**. To improve time complexity we should store the solutions of the already calculated subproblems in a table.

```java
public class Solution {

  public int coinChange(int[] coins, int amount) {
    if (amount < 1) return 0;
    return coinChange(coins, amount, new int[amount]);
  }

  private int coinChange(int[] coins, int rem, int[] count) {
    if (rem < 0) return -1;
    if (rem == 0) return 0;
    if (count[rem - 1] != 0) return count[rem - 1];
    int min = Integer.MAX_VALUE;
    for (int coin : coins) {
      int res = coinChange(coins, rem - coin, count);
      if (res >= 0 && res < min)
        min = 1 + res;
    }
    count[rem - 1] = (min == Integer.MAX_VALUE) ? -1 : min;
    return count[rem - 1];
  }
}
```

**Complexity Analysis**

- Time complexity : O(S*n)*O*(*S*∗*n*). where S is the amount, n is denomination count. In the worst case the recursive tree of the algorithm has height of S*S* and the algorithm solves only S*S* subproblems because it caches precalculated solutions in a table. Each subproblem is computed with n*n* iterations, one by coin denomination. Therefore there is O(S*n)*O*(*S*∗*n*) time complexity.
- Space complexity : O(S)*O*(*S*), where S*S* is the amount to change We use extra space for the memoization table.

------

#### Approach #3 (Dynamic programming - Bottom up) [Accepted]

**Algorithm**

For the iterative solution, we think in bottom-up manner. Before calculating *F(i)\*F*(\*i*)*, we have to compute all minimum counts for amounts up to i*i*. On each iteration i*i* of the algorithm *F(i)\*F*(\*i*)* is computed as \min_{j=0 \ldots n-1}{F(i -c_j)} + 1min*j*=0…*n*−1*F*(*i*−*c**j*)+1

![](img/322_coin_change_table.png)

In the example above you can see that:

\begin{aligned} F(3) &= \min\{{F(3- c_1), F(3-c_2), F(3-c_3)}\} + 1 \\ &= \min\{{F(3- 1), F(3-2), F(3-3)}\} + 1 \\ &= \min\{{F(2), F(1), F(0)}\} + 1 \\ &= \min\{{1, 1, 0}\} + 1 \\ &= 1 \end{aligned}*F*(3)=min{*F*(3−*c*1),*F*(3−*c*2),*F*(3−*c*3)}+1=min{*F*(3−1),*F*(3−2),*F*(3−3)}+1=min{*F*(2),*F*(1),*F*(0)}+1=min{1,1,0}+1=1



```java
public class Solution {
  public int coinChange(int[] coins, int amount) {
    int max = amount + 1;
    int[] dp = new int[amount + 1];
    Arrays.fill(dp, max);
    dp[0] = 0;
    for (int i = 1; i <= amount; i++) {
      for (int j = 0; j < coins.length; j++) {
        if (coins[j] <= i) {
          dp[i] = Math.min(dp[i], dp[i - coins[j]] + 1);
        }
      }
    }
    return dp[amount] > amount ? -1 : dp[amount];
  }
}
```

**Complexity Analysis**

- Time complexity : O(S*n)*O*(*S*∗*n*). On each step the algorithm finds the next *F(i)\*F*(\*i*)* in n*n* iterations, where 1\leq i \leq S1≤*i*≤*S*. Therefore in total the iterations are S*n*S*∗*n*.
- Space complexity : O(S)*O*(*S*). We use extra space for the memoization table.

