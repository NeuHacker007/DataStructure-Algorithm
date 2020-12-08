/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-08-2020 16:00:28
 * LastEditTime: 12-08-2020 16:11:32
 * FilePath: \CSharpLeetCodeSolution\Solution\L.103.Binary.Tree.Zigzag.Level.Order.Traversal.Medium\LeetCode103.cs
 * Description: 
 */
using System.Collections.Generic;
namespace Solution
{
    public class LeetCode103TreeNode
    {
        public int val;
        public LeetCode103TreeNode left;
        public LeetCode103TreeNode right;
        public LeetCode103TreeNode(int val = 0, LeetCode103TreeNode left = null, LeetCode103TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode103
    {
        static IList<IList<int>> ans = new List<IList<int>>();
        public static IList<IList<int>> ZigzagLevelOrder(LeetCode103TreeNode root)
        {
            Helper(root, 0);
            return ans;
        }

        private static void Helper(LeetCode103TreeNode root, int level)
        {
            if (root == null) return;

            if (level >= ans.Count)
            {
                var temp = new List<int>();
                temp.Add(root.val);

                ans.Add(temp);
            }
            else
            {
                if (level % 2 == 0)
                {
                    ans[level].Add(root.val);
                }
                else
                {
                    ans[level].Insert(0, root.val);
                }

            }

            if (root.left != null) Helper(root.left, level + 1);
            if (root.right != null) Helper(root.right, level + 1);
        }
    }



}