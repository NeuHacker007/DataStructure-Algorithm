/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 08-16-2021 14:18:36
 * LastEditTime: 08-16-2021 14:36:19
 * FilePath: \CSharpLeetCodeSolution\Solution\L.662.MaximumWidthofBinaryTree.Medium\LeetCode662.cs
 * Description: 
 */
using System;
using System.Collections.Generic;
namespace TreeSolution
{
    public class LeetCode662TreeNode
    {
        public int val;
        public LeetCode662TreeNode left;
        public LeetCode662TreeNode right;
        public LeetCode662TreeNode(int val = 0, LeetCode662TreeNode left = null, LeetCode662TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode662
    {
        public static int WidthOfBinaryTree(LeetCode662TreeNode root)
        {
            int maxWidth = 0;
            if (root == null) return maxWidth;
            var queue = new Queue<KeyValuePair<LeetCode662TreeNode, int>>();

            queue.Enqueue(new KeyValuePair<LeetCode662TreeNode, int>(root, 0));

            while (queue.Count > 0)
            {
                var first = queue.Peek();
                var currLevelSize = queue.Count;

                var current = new KeyValuePair<LeetCode662TreeNode, int>();

                while (currLevelSize-- > 0)
                {
                    current = queue.Dequeue();
                    var node = current.Key;
                    var index = current.Value;

                    if (node.left != null)
                    {
                        queue.Enqueue(new KeyValuePair<LeetCode662TreeNode, int>(node.left, 2 * index));
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(new KeyValuePair<LeetCode662TreeNode, int>(node.right, 2 * index + 1));
                    }

                }

                maxWidth = Math.Max(maxWidth, current.Value - first.Value + 1);
            }
            return maxWidth;
        }
    }

}
