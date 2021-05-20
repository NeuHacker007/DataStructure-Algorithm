/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 05-18-2021 11:08:47
 * LastEditTime: 05-18-2021 12:37:17
 * FilePath: \CSharpLeetCodeSolution\Solution\L.654.Maximum.Binary.Tree.Medium\LeetCode654.cs
 * Description: 
 */
using System;
namespace LcTreeSolution
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class LeetCode654
    {
        public static TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return Build(nums, 0, nums.Length - 1);
        }

        // return [lo .. hi] tree 
        private static TreeNode Build(int[] nums, int lo, int hi)
        {
            if (lo > hi) return null;

            var index = 0;
            var max = int.MinValue;

            for (int i = lo; i <= hi; i++)
            {
                if (max < nums[i])
                {
                    max = nums[i];
                    index = i;
                }
            }

            var root = new TreeNode(max);

            root.left = Build(nums, lo, index - 1);
            root.right = Build(nums, index + 1, hi);
            return root;
        }

    }

}