/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-23-2020 13:37:27
 * LastEditTime: 12-23-2020 13:43:49
 * FilePath: \CSharpLeetCodeSolution\Solution\L.236.Lowest.Common.Ancestor.Of.A.Binary.Tree.Medium\img\LeetCode236.cs
 * Description: 
 */


namespace Solution
{

    public class LeetCode236TreeNode
    {
        public int val;
        public LeetCode236TreeNode left;
        public LeetCode236TreeNode right;
        public LeetCode236TreeNode(int x) { val = x; }
    }

    public class LeetCode236
    {
        private static LeetCode236TreeNode ans = null;

        public static LeetCode236TreeNode LowestCommonAncestor(LeetCode236TreeNode root, LeetCode236TreeNode p, LeetCode236TreeNode q)
        {
            Helper(root, p, q);

            return ans;
        }

        private static bool Helper(LeetCode236TreeNode root, LeetCode236TreeNode p, LeetCode236TreeNode q)
        {
            if (root == null) return false;

            var left = Helper(root.left, p, q) ? 1 : 0;
            var right = Helper(root.right, p, q) ? 1 : 0;

            var mid = (root == p || root == q) ? 1 : 0;

            if ((mid + left + right) >= 2) ans = root;

            return (mid + left + right) > 0;

        }
    }

}