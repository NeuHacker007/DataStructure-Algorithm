/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-11-2020 16:36:17
 * LastEditTime: 12-11-2020 21:59:15
 * FilePath: \CSharpLeetCodeSolution\Solution\L.117.Populating.Next.Right.Pointers.In.Each.Node.II.Medium\LeetCode117.cs
 * Description: 
 */
using System.Collections.Generic;

namespace Solution
{
    public class LeetCode117Node
    {
        public int val;
        public LeetCode117Node left;
        public LeetCode117Node right;
        public LeetCode117Node next;

        public LeetCode117Node() { }

        public LeetCode117Node(int _val)
        {
            val = _val;
        }

        public LeetCode117Node(int _val, LeetCode117Node _left, LeetCode117Node _right, LeetCode117Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

    public class LeetCode117
    {
        public static LeetCode117Node Connection(LeetCode117Node root)
        {
            if (root == null) return root;
            var queue = new Queue<LeetCode117Node>();

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

