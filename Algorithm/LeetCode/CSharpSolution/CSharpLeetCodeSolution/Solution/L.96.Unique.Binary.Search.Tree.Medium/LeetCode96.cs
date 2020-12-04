/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-04-2020 14:05:26
 * LastEditTime: 12-04-2020 14:10:39
 * FilePath: \CSharpLeetCodeSolution\Solution\L.96.Unique.Binary.Search.Tree.Medium\LeetCode96.cs
 * Description: 
 */


namespace Solution
{
    public static int NumTrees(int n) {
        in[] dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 1;

        for(int i = 2; i <= n; i++) {
            for (int j = 1; j <= i; j++) {
                dp[i] += dp[j - 1] * dp[j - i];
            }
        }

        return dp[n];
    }
    
}