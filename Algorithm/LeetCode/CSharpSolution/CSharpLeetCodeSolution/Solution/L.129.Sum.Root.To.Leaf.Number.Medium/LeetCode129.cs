/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-11-2020 23:13:23
 * LastEditTime: 12-11-2020 23:19:03
 * FilePath: \CSharpLeetCodeSolution\Solution\L.129.Sum.Root.To.Leaf.Number.Medium\LeetCode129.cs
 * Description: 
 */

namespace Solution
{
    public class LeetCode129TreeNode
    {
        public int val;
        public LeetCode129TreeNode left;
        public LeetCode129TreeNode right;
        public LeetCode129TreeNode(int val = 0, LeetCode129TreeNode left = null, LeetCode129TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public bool IsLeaf()
        {
            return left == null && right == null;
        }
    }

    public class Leet129
    {
        static int ans = 0;
        public static int SumNumbers(LeetCode129TreeNode root)
        {
            Helper(root, 0);
            return ans;
        }

        private static void Helper(LeetCode129TreeNode root, int currSum)
        {
            if (root == null) return;

            currSum = currSum * 10 + root.val;

            if (root.IsLeaf()) ans += currSum;

            Helper(root.left, currSum);
            Helper(root.right, currSum);

        }
    }
}