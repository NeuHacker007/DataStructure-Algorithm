/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-21-2020 21:42:23
 * LastEditTime: 12-21-2020 21:48:49
 * FilePath: \CSharpLeetCodeSolution\Solution\L.230.Kth.Smallest.Element.In.a.BST.Medium\LeetCode230.cs
 * Description: 
 */

using System.Collections.Generic;
namespace Solution
{
    public class LeetCode230TreeNode
    {
        public int val;
        public LeetCode230TreeNode left;
        public LeetCode230TreeNode right;
        public LeetCode230TreeNode(int val = 0, LeetCode230TreeNode left = null, LeetCode230TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode230
    {
        private static IList<int> list = new List<int>();

        public static int KthSmallestElement(LeetCode230TreeNode root, int k)
        {
            Helper(root);

            return list[k - 1];
        }

        private static void Helper(LeetCode230TreeNode root)
        {
            if (root == null) return;

            Helper(root.left);
            list.Add(root.val);
            Helper(root.right);
        }
    }

}