/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-10-2020 20:39:29
 * LastEditTime: 12-10-2020 20:46:58
 * FilePath: \CSharpLeetCodeSolution\Solution\L.114.Flatten.Binary.Tree.To.Linked.List.Medium\LeetCode114.cs
 * Description: 
 */

namespace Solution
{

    public class LeetCode114TreeNode
    {
        public int val;
        public LeetCode114TreeNode left;
        public LeetCode114TreeNode right;
        public LeetCode114TreeNode(int val = 0, LeetCode114TreeNode left = null, LeetCode114TreeNode right = null)
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

    public class LeetCode114
    {
        public static void FlattenBinaryTree(LeetCode114TreeNode root)
        {
            Helper(root);
        }

        private static LeetCode114TreeNode Helper(LeetCode114TreeNode root)
        {
            if (root == null) return null;
            if (root.IsLeaf()) return root;

            var left = Helper(root.left);
            var right = Helper(root.right);

            if (left != null)
            {
                left.right = root.right;
                root.right = root.left;
                root.left = null;
            }

            return right == null ? left : right;
        }
    }
}