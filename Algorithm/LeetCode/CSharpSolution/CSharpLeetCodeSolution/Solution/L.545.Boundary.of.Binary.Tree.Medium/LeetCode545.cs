/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 05-12-2021 08:43:39
 * LastEditTime: 05-12-2021 09:03:13
 * FilePath: \CSharpLeetCodeSolution\Solution\L.545.Boundary.of.Binary.Tree.Medium\LeetCode545.cs
 * Description: 
 */

using System;
using System.Collections.Generic;

namespace Solution
{
    public class LeetCode545TreeNode
    {
        public int val;
        public LeetCode545TreeNode left;
        public LeetCode545TreeNode right;
        public LeetCode545TreeNode(int val = 0, LeetCode545TreeNode left = null, LeetCode545TreeNode right = null)
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

    public class LeetCode545
    {
        public static IList<int> BoundaryOfBinaryTree(LeetCode545TreeNode root)
        {
            var res = new List<int>();
            if (root == null) return res;
            if (!root.IsLeaf())
            {
                res.Add(root.val);
            }
            var temp = root.left;
            while (temp != null)
            {
                if (!temp.IsLeaf())
                {
                    res.Add(temp.val);
                }
                if (temp.left != null)
                {
                    temp = temp.left;
                }
                else
                {
                    temp = temp.right;
                }
            }

            AddLeaves(res, root);

            var stack = new Stack<int>();
            temp = root.right;

            while (temp != null)
            {
                if (!temp.IsLeaf())
                {
                    stack.Push(temp.val);
                }
                if (temp.right != null)
                {
                    temp = temp.right;
                }
                else
                {
                    temp = temp.left;

                }
            }

            while (stack.Count != 0)
            {
                res.Add(stack.Pop());
            }

            return res;
        }

        public static void AddLeaves(IList<int> res, LeetCode545TreeNode root)
        {
            if (root.IsLeaf())
            {
                res.Add(root.val);
            }
            else
            {
                if (root.left != null)
                {
                    AddLeaves(res, root.left);
                }
                if (root.right != null)
                {
                    AddLeaves(res, root.right);
                }
            }
        }
    }

}
