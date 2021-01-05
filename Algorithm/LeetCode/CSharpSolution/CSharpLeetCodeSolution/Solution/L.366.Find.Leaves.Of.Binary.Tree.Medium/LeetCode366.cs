/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-05-2021 14:53:43
 * LastEditTime: 01-05-2021 15:07:14
 * FilePath: \CSharpLeetCodeSolution\Solution\L.366.Find.Leaves.Of.Binary.Tree.Medium\LeetCode366.cs
 * Description: 
 */
using System;
using System.Collections.Generic;

namespace Solution
{
    public class LeetCode366TreeNode
    {
        public int val;
        public LeetCode366TreeNode left;
        public LeetCode366TreeNode right;
        public LeetCode366TreeNode(int val = 0, LeetCode366TreeNode left = null, LeetCode366TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode366
    {
        static IList<IList<int>> ans = new List<IList<int>>();

        public static IList<IList<int>> FindLeaves(LeetCode366TreeNode root)
        {
            Helper(root);
            return ans;
        }

        private static int Helper(LeetCode366TreeNode root)
        {
            if (root == null) return -1;

            var left = Helper(root.left);
            var right = Helper(root.right);

            var curr = Math.Max(left, right) + 1;
            if (ans.Count == curr)
            {
                ans.Add(new List<int>());
            }

            ans[curr].Add(root.val);

            return curr;

        }
    }
}