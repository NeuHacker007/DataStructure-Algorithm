/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 07-17-2021 02:00:09
 * LastEditTime: 07-18-2021 21:34:19
 * FilePath: \CSharpLeetCodeSolution\Solution\L.314.Binary.Tree.Vertical.Order.Traversal.Medium\LeetCode314.cs
 * Description: 
 */
using System.Collections.Generic;
using System.Linq;

namespace LcTreeSolution
{
    public class LeetCode314TreeNode
    {
        public int val;
        public LeetCode314TreeNode left;
        public LeetCode314TreeNode right;
        public LeetCode314TreeNode(int val = 0, LeetCode314TreeNode left = null, LeetCode314TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }


    public class LeetCode314
    {
        public static IList<IList<int>> VerticalOrder(LeetCode314TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;
            var columnTable = new Dictionary<int, List<int>>();
            var queue = new Queue<Dictionary<LeetCode314TreeNode, int>>();

            var column = 0;

            queue.Enqueue(new Dictionary<LeetCode314TreeNode, int>() { { root, column } });

            while (queue.Count != 0)
            {
                var p = queue.Dequeue();
                root = p.Keys.First();
                column = p.Values.First();
                if (root != null)
                {
                    if (!columnTable.ContainsKey(column))
                    {
                        columnTable.Add(column, new List<int>());
                    }

                    columnTable[column].Add(root.val);

                    if (root.left != null)
                    {
                        queue.Enqueue(new Dictionary<LeetCode314TreeNode, int>() { { root.left, column - 1 } });
                    }

                    if (root.right != null)
                    {
                        queue.Enqueue(new Dictionary<LeetCode314TreeNode, int>() { { root.right, column + 1 } });
                    }
                }
            }


            var sorted = columnTable.OrderBy(x => x.Key);
            foreach (var item in sorted)
            {
                result.Add(item.Value);
            }
            return result;
        }
    }

}