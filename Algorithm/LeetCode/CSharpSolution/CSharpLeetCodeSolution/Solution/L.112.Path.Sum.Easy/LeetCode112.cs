/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-28-2020 21:21:52
 * LastEditTime: 11-28-2020 21:29:44
 * FilePath: \CSharpLeetCodeSolution\Solution\L.112.Path.Sum.Easy\LeetCode112.cs
 * Description: 
 */

namespace Solution
{

    public class LeetCode112TreeNode
    {
        public int val;
        public LeetCode112TreeNode left;
        public LeetCode112TreeNode right;
        public LeetCode112TreeNode(int val = 0, LeetCode112TreeNode left = null, LeetCode112TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode112
    {
        public static bool HasPathSum(LeetCode112TreeNode root, int sum)
        {
            if (root == null) return false;
            sum -= root.val;
            if (root.left == null && root.right == null) return sum == 0;

            return HasPathSum(root.left, sum) || HasPathSum(root.right, sum);
        }
    }
}
