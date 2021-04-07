/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 04-07-2021 08:47:07
 * LastEditTime: 04-07-2021 08:54:19
 * FilePath: \CSharpLeetCodeSolution\Solution\L.515.Find.Largest.Value.In.Each.Tree.Row.Medium\LeetCode515.cs
 * Description: 
 */
using System.Collections.Generic;
namespace Solution
{
    public class LeetCode515TreeNode
    {
        public int val;
        public LeetCode515TreeNode left;
        public LeetCode515TreeNode right;
        public LeetCode515TreeNode(int val = 0, LeetCode515TreeNode left = null, LeetCode515TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode515
    {
        static List<int> ans = new List<int>();
        public static IList<int> FindLargestValues(LeetCode515TreeNode root)
        {
            if (root == null) return default;

            Helper(root, 0);
            return ans;
        }

        private static void Helper(LeetCode515TreeNode root, int level)
        {
            if (root == null) return;
            if (ans.Count == level)
            {
                ans.Add(root.val);
            }
            else
            {
                if (ans[level] < root.val)
                {
                    ans[level] = root.val;
                }
            }

            Helper(root.left, level + 1);
            Helper(root.right, level + 1);
        }
    }

}