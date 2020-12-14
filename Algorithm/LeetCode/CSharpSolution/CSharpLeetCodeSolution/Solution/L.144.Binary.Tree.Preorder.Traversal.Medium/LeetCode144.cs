/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-14-2020 16:03:43
 * LastEditTime: 12-14-2020 16:08:56
 * FilePath: \CSharpLeetCodeSolution\Solution\L.144.Binary.Tree.Preorder.Traversal.Medium\LeetCode144.cs
 * Description: 
 */

using System.Collections.Generic;
namespace Solution
{

    public class LeetCode144TreeNode
    {
        public int val;
        public LeetCode144TreeNode left;
        public LeetCode144TreeNode right;
        public LeetCode144TreeNode(int val = 0, LeetCode144TreeNode left = null, LeetCode144TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode144
    {
        static IList<int> ans = new List<int>();
        public static IList<int> PreorderTraversal(LeetCode144TreeNode root)
        {
            Helper(root);
            return ans;
        }

        private static void Helper(LeetCode144TreeNode root)
        {
            if (root == null) return;
            ans.Add(root.val);

            Helper(root.left);
            Helper(root.right);
        }
    }
}