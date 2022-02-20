/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 02-18-2022 09:19:00
 * LastEditTime: 02-18-2022 09:33:43
 * FilePath: \CSharpLeetCodeSolution\Solution\L.276.Paint.Fence.Medium\LeetCode276.cs
 * Description: 
 */

namespace DPSolution
{
    public class LeetCode276
    {
        /*
        如果思考f(n)和f(n-1)的关系，那么解法就呼之欲出了．我们喷涂第ｎ个柱子，就是两种方案：和n-1的颜色一致，和n-1的颜色不一致．
        对于前者，我们必须保证n-2和n-1的颜色已经不能相同了，而对于后者，我们允许n-2和n-1的颜色相同．于是可以考虑dual status的ＤＰ方案，
        用same表示最近的两个柱子颜色一致的方案总数，diff表示最近的两个柱子颜色不一致的方案总数．

        对于n，如果想喷涂和n-1一样的颜色，那么same(n)就要更新为diff(n-1)，颜色没有选择的余地

        对于n，如果想喷涂和n-1不一样的颜色，那么diff(n)就要更新为[diff(n-1)+same(n-1)]*(k-1)，其中k-1表示颜色的选择种类．

        上述的递归公式显示，我们只要不断更新两个状态变量same和diff即可．最后的答案就是两者之和．
        

         posts: X X X X X X X X X X i
                                  
         dp[i] = the number of ways you can paint the fence for post[i]

         scenario 1. i and i -1 has the same color, i -1 and i-2 cannot have the same color 

            dp[i] = diff(n-1);

         scenario 2. i and i - 1 has diff color, i -1 and i-2 can be the same color
            dp[i] = same[i-1] * (k-1) + diff(i-1);

        */
        public static int NumWays(int n, int k)
        {
            if (n == 0) return 0;
            if (n == 1) return k;
            int same = k;
            int diff = k * (k - 1);
            for (int i = 2; i < n; i++)
            {
                int same_tmp = same;
                int diff_tmp = diff;
                diff = same_tmp * (k - 1) + diff_tmp * (k - 1);
                same = diff_tmp;
            }

            return same + diff;
        }
    }
}
