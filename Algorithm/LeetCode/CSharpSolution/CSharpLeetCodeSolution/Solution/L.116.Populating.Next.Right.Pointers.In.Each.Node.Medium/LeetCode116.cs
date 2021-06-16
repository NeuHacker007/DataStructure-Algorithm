/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-11-2020 14:23:13
 * LastEditTime: 06-15-2021 20:49:35
 * FilePath: \CSharpLeetCodeSolution\Solution\L.116.Populating.Next.Right.Pointers.In.Each.Node.Medium\LeetCode116.cs
 * Description: 
 */
using System.Collections.Generic;

namespace LcTreeSolution
{
    public class LeetCode116Node
    {
        public int val;
        public LeetCode116Node left;
        public LeetCode116Node right;
        public LeetCode116Node next;

        public LeetCode116Node() { }

        public LeetCode116Node(int _val)
        {
            val = _val;
        }

        public LeetCode116Node(int _val, LeetCode116Node _left, LeetCode116Node _right, LeetCode116Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

    public class LeetCode116
    {
        public static LeetCode116Node Connection(LeetCode116Node root)
        {
            if (root == null) return root;
            var queue = new Queue<LeetCode116Node>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var size = queue.Count;

                for (var i = 0; i < size; i++)
                {
                    var tempNode = queue.Dequeue();
                    if (i < size - 1)
                    {
                        tempNode.next = queue.Peek();
                    }

                    if (tempNode.left != null) queue.Enqueue(tempNode.left);
                    if (tempNode.right != null) queue.Enqueue(tempNode.right);
                }
            }
            return root;
        }
    }
}
