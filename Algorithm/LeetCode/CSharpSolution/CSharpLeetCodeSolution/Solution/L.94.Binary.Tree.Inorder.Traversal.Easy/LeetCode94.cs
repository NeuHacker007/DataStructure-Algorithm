/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-25-2021 08:49:35
 * LastEditTime: 10-25-2021 08:54:08
 * FilePath: \CSharpLeetCodeSolution\Solution\L.94.Binary.Tree.Inorder.Traversal.Easy\LeetCode94.cs
 * Description: 
 */
using System.Collections.Generic;
namespace TreeSolution
{

    public class LeetCode94TreeNode
    {
        public int val;
        public LeetCode94TreeNode left;
        public LeetCode94TreeNode right;
        public LeetCode94TreeNode(int val = 0, LeetCode94TreeNode left = null, LeetCode94TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode94
    {
        public static IList<int> InOrderTraversal(LeetCode94TreeNode root)
        {
            var result = new List<int>();
            InOrderHelper(root, result);
            return result;
        }

        private static void InOrderHelper(LeetCode94TreeNode root, IList<int> result)
        {
            if (root == null) return;
            if (root.left != null) InOrderHelper(root.left, result);
            result.Add(root.val);
            if (root.right != null) InOrderHelper(root.right, result);
        }
    }
}
