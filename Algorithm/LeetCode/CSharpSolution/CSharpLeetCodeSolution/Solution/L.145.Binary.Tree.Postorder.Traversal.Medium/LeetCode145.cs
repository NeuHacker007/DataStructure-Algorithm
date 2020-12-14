/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-14-2020 16:32:28
 * LastEditTime: 12-14-2020 16:44:39
 * FilePath: \CSharpLeetCodeSolution\Solution\L.145.Binary.Tree.Postorder.Traversal.Medium\LeetCode145.cs
 * Description: 
 */

using System.Collections.Generic;
namespace Solution
{
    public class LeetCode145TreeNode
    {
        public int val;
        public LeetCode145TreeNode left;
        public LeetCode145TreeNode right;
        public LeetCode145TreeNode(int val = 0, LeetCode145TreeNode left = null, LeetCode145TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode145
    {
        public static IList<int> PostorderTraversal(LeetCode145TreeNode root)
        {
            var ans = new List<int>();
            var stack = new Stack<LeetCode145TreeNode>();

            while (root != null || stack.Count > 0)
            {
                while (root != null)
                {
                    if (root.right != null) stack.Push(root.right);
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();

                if (stack.Count > 0 && root.right == stack.Peek())
                {
                    stack.Pop();
                    stack.Push(root);
                    root = root.right;
                }
                else
                {
                    ans.Add(root.val);
                    root = null;
                }
            }
            return ans;
        }
    }
}