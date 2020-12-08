/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-08-2020 15:17:21
 * LastEditTime: 12-08-2020 15:23:51
 * FilePath: \CSharpLeetCodeSolution\Solution\L.102.Binary.Tree.Level.Order.Traversal.Medium\LeetCode102.cs
 * Description: 
 */

using System.Collections.Generic;

namespace Solution
{

    public class LeetCode102TreeNode
    {
        public int val;
        public LeetCode102TreeNode left;
        public LeetCode102TreeNode right;
        public LeetCode102TreeNode(int val = 0, LeetCode102TreeNode left = null, LeetCode102TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode102
    {
        static IList<IList<int>> ans = new List<IList<int>>();
        public static IList<IList<int>> LevelOrder(LeetCode102TreeNode root)
        {
            Helper(root, 0);
            return ans;
        }

        public static void Helper(LeetCode102TreeNode root, int level)
        {
            if (root == null) return;
            if (level == ans.Count)
            {
                ans.Add(new List<int>());
            }
            ans[level].Add(root.val);

            if (root.left != null) Helper(root.left, level + 1);
            if (root.right != null) Helper(root.right, level + 1);
        }
    }



}
