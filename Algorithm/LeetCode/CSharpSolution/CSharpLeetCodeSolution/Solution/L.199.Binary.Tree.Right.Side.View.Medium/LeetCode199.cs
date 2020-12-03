/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-03-2020 16:14:44
 * LastEditTime: 12-03-2020 16:22:24
 * FilePath: \CSharpLeetCodeSolution\Solution\L.199.Binary.Tree.Right.Side.View.Medium\LeetCode199.cs
 * Description: 
 */
using System.Collections.Generic;
namespace Solution
{
    public class LeetCode199TreeNode
    {
        public int val;
        public LeetCode199TreeNode left;
        public LeetCode199TreeNode right;
        public LeetCode199TreeNode(int val = 0, LeetCode199TreeNode left = null, LeetCode199TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode199
    {
        static IList<int> rightSideNodes = new List<int>();
        public static IList<int> RightSideView(LeetCode199TreeNode root)
        {
            Helper(root, 0);
            return rightSideNodes;
        }

        private static void Helper(LeetCode199TreeNode root, int level)
        {
            if (root == null) return;

            if (level == rightSideNodes.Count) rightSideNodes.Add(root.val);

            if (root.right != null) Helper(root.right, level + 1);
            if (root.left != null) Helper(root.left, level + 1);

        }
    }

}