/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-10-2020 20:01:48
 * LastEditTime: 12-10-2020 20:14:44
 * FilePath: \CSharpLeetCodeSolution\Solution\L.113.Path.Sum.II.Medium\LeetCode113.cs
 * Description: 
 */

 /**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-10-2020 20:01:48
 * LastEditTime: 12-10-2020 20:14:00
 * FilePath: \CSharpLeetCodeSolution\Solution\L.113.Path.Sum.II.Medium\LeetCode113.cs
 * Description: 
 */
using System.Collections.Generic;

namespace Solution
{
    public class LeetCode113TreeNode
    {
        public int val;
        public LeetCode113TreeNode left;
        public LeetCode113TreeNode right;
        public LeetCode113TreeNode(int val = 0, LeetCode113TreeNode left = null, LeetCode113TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public bool IsLeaf()
        {
            return left == null && right == null;
        }
    }

    public class LeetCode113
    {
        public static IList<IList<int>> PathSum(LeetCode113TreeNode root, int sum)
        {
            var pathNodes = new List<int>();
            var pathsList = new List<IList<int>>();

            Helper(root, sum, pathNodes, pathsList);

            return pathsList;
        }

        private static void Helper(LeetCode113TreeNode root, int sum, List<int> pathNodes, List<IList<int>> pathsList)
        {
            if (root == null) return;

            pathNodes.Add(root.val);

            if (sum == root.val && root.IsLeaf())
            {
                var temp = new List<int>(pathNodes);
                pathsList.Add(temp);
            }
            else
            {
                Helper(root.left, sum - root.val, pathNodes, pathsList);
                Helper(root.right, sum - root.val, pathNodes, pathsList);
            }

            pathNodes.RemoveAt(pathNodes.Count - 1);
        }

    }
}
