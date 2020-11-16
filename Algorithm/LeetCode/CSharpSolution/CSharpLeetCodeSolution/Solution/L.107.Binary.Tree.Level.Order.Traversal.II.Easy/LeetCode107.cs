using System;
using System.Collections.Generic;

namespace Solution
{
    public class LeetCode107TreeNode
    {
        public int val;
        public LeetCode107TreeNode left;
        public LeetCode107TreeNode right;
        public LeetCode107TreeNode(int val = 0, LeetCode107TreeNode left = null, LeetCode107TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode107
    {
        static IList<IList<int>> levels = new List<IList<int>>();
        public static IList<IList<int>> LevelOrderBottom(LeetCode107TreeNode root)
        {
            Helper(root, 0);

            var ans = new List<IList<int>>();

            var stack = new Stack<IList<int>>();

            foreach (var item in levels)
            {
                stack.Push(item);
            }

            while (stack.Count != 0)
            {
                ans.Add(stack.Pop());
            }

            return ans;
        }

        private static void Helper(LeetCode107TreeNode root, int level)
        {
            if (root == null) return;

            if (levels.Count == level)
            {
                levels.Add(new List<int>());
            }

            levels[level].Add(root.val);

            if (root.left != null)
            {
                Helper(root.left, level + 1);
            }

            if (root.right != null)
            {
                Helper(root.right, level + 1);
            }
        }

    }

}