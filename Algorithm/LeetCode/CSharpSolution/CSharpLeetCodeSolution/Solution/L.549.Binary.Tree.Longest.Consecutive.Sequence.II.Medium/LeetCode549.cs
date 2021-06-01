/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 05-26-2021 15:14:11
 * LastEditTime: 05-26-2021 15:38:48
 * FilePath: \CSharpLeetCodeSolution\Solution\L.549.Binary.Tree.Longest.Consecutive.Sequence.II.Medium\LeetCode549.cs
 * Description: 
 */
using System;
namespace LcTreeSolution
{
    public class LeetCode549TreeNode
    {
        public int val;
        public LeetCode549TreeNode left;
        public LeetCode549TreeNode right;
        public LeetCode549TreeNode(int val = 0, LeetCode549TreeNode left = null, LeetCode549TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }


    public class LeetCode549
    {
        private static int _maxVal = 0;
        public static int LongestConsecutive(LeetCode549TreeNode root)
        {
            return _maxVal;
        }

        private static int[] Helper(LeetCode549TreeNode root)
        {
            if (root == null) return new int[] { 0, 0 };
            var inr = 1;
            var dcr = 1;

            if (root.left != null)
            {
                var l = Helper(root.left);

                if (root.val == root.left.val + 1)
                {
                    dcr = l[1] + 1;
                }
                else if (root.val == root.left.val - 1)
                {
                    inr = l[0] + 1;
                }
            }

            if (root.right != null)
            {
                var r = Helper(root.right);

                if (root.val == root.right.val + 1)
                {
                    dcr = Math.Max(dcr, r[1] + 1);
                }
                else if (root.val == root.right.val - 1)
                {
                    inr = Math.Max(inr, r[0] + 1);
                }
            }
            _maxVal = Math.Max(_maxVal, dcr + inr - 1);

            return new int[] { inr, dcr };

        }
    }
}