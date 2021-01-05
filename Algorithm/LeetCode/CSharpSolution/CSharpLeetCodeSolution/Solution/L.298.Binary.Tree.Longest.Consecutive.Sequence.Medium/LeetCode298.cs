/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-29-2020 20:47:30
 * LastEditTime: 12-29-2020 20:58:22
 * FilePath: \CSharpLeetCodeSolution\Solution\L.298.Binary.Tree.Longest.Consecutive.Sequence.Medium\LeetCode298.cs
 * Description: 
 */
using System;
namespace Solution
{
    public class LeetCode298TreeNode
    {
        public int val;
        public LeetCode298TreeNode left;
        public LeetCode298TreeNode right;
        public LeetCode298TreeNode(int val = 0, LeetCode298TreeNode left = null, LeetCode298TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode298
    {
        private static int maxLength = 0;
        public static int LongestConsecutive(LeetCode298TreeNode root)
        {
            Helper(root, null, 0);
            return maxLength;
        }

        private static void Helper(LeetCode298TreeNode root, LeetCode298TreeNode parent, int length)
        {
            if (root == null) return;
            length = (parent != null && root.val == parent.val + 1) ? length++ : 1;
            maxLength = Math.Max(maxLength, length);

            Helper(root.left, root, length);
            Helper(root.right, root, length);
        }
    }

}