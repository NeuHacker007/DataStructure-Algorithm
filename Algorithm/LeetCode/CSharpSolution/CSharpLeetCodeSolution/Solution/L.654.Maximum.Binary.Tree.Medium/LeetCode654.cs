/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 05-18-2021 11:08:47
 * LastEditTime: 05-26-2021 15:25:20
 * FilePath: \CSharpLeetCodeSolution\Solution\L.654.Maximum.Binary.Tree.Medium\LeetCode654.cs
 * Description: 
 */
using System;
namespace LcTreeSolution
{
    public class LeetCode654TreeNode
    {
        public int val;
        public LeetCode654TreeNode left;
        public LeetCode654TreeNode right;
        public LeetCode654TreeNode(int val = 0, LeetCode654TreeNode left = null, LeetCode654TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class LeetCode654
    {
        public static LeetCode654TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return Build(nums, 0, nums.Length - 1);
        }

        // return [lo .. hi] tree 
        private static LeetCode654TreeNode Build(int[] nums, int lo, int hi)
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

            var root = new LeetCode654TreeNode(max);

            root.left = Build(nums, lo, index - 1);
            root.right = Build(nums, index + 1, hi);
            return root;
        }

    }

}