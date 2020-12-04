/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-04-2020 13:33:33
 * LastEditTime: 12-04-2020 13:41:01
 * FilePath: \CSharpLeetCodeSolution\Solution\L.98.Validate.Binary.Search.Tree.Medium\LeetCode98.cs
 * Description: 
 */

namespace Solution
{
    public class LeetCode98TreeNode
    {
        public int val;
        public LeetCode98TreeNode left;
        public LeetCode98TreeNode right;
        public LeetCode98TreeNode(int val = 0, LeetCode98TreeNode left = null, LeetCode98TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode98
    {
        public static bool IsValidBST(LeetCode98TreeNode root)
        {
            return Helper(root, null, null);
        }

        private static bool Helper(LeetCode98TreeNode root, int? lower, int? upper)
        {
            if (root == null) return true;
            if (lower != null && root.val <= lower) return false;
            if (upper != null && root.val >= upper) return false;

            if (!Helper(root.left, lower, root.val)) return false;
            if (!Helper(root.right, root.val, upper)) return false;

            return true;
        }

    }

}
