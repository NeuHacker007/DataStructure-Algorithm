/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-03-2020 20:45:09
 * LastEditTime: 12-03-2020 20:53:29
 * FilePath: \CSharpLeetCodeSolution\Solution\L.95.Unique.Binary.Search.Trees.II.Medium\LeetCode95.cs
 * Description: 
 */
using System.Collections.Generic;
namespace Solution
{
    public class LeetCode95TreeNode
    {
        public int val;
        public LeetCode95TreeNode left;
        public LeetCode95TreeNode right;
        public LeetCode95TreeNode(int val = 0, LeetCode95TreeNode left = null, LeetCode95TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode95
    {
        public static IList<LeetCode95TreeNode> GenerateTrees(int n)
        {
            if (n == 0) return new List<LeetCode95TreeNode>();
            return BuildTree(1, n);
        }

        private static IList<LeetCode95TreeNode> BuildTree(int start, int end)
        {
            var trees = new List<LeetCode95TreeNode>();
            if (start > end)
            {
                trees.Add(null);
                return trees;
            }

            for (int i = start; i <= end; i++)
            {
                var leftTrees = BuildTree(start, i);
                var rightTrees = BuildTree(i + 1, end);
                foreach (var left in leftTrees)
                {
                    foreach (var right in rightTrees)
                    {
                        var currentTree = new LeetCode95TreeNode(i);
                        currentTree.left = left;
                        currentTree.right = right;

                        trees.Add(currentTree);
                    }
                }
            }
            return trees;
        }
    }

}