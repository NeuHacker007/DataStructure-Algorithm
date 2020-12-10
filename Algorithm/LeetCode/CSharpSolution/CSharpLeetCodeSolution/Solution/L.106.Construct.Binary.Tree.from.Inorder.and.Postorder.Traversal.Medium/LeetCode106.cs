/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-09-2020 21:28:17
 * LastEditTime: 12-09-2020 22:00:13
 * FilePath: \CSharpLeetCodeSolution\Solution\L.106.Construct.Binary.Tree.from.Inorder.and.Postorder.Traversal.Medium\LeetCode106.cs
 * Description: 
 */
using System.Collections.Generic;

namespace Solution
{
    public class LeetCode106TreeNode
    {
        public int val;
        public LeetCode106TreeNode left;
        public LeetCode106TreeNode right;
        public LeetCode106TreeNode(int val = 0, LeetCode106TreeNode left = null, LeetCode106TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode106
    {
        static int post_idx;
        static int[] inOrder;
        static int[] postOrder;
        static Dictionary<int, int> idx_map = new Dictionary<int, int>();
        public static LeetCode106TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            inOrder = inorder;
            postOrder = postorder;
            post_idx = postorder.Length - 1;

            var index = 0;

            foreach (var item in inorder)
            {
                idx_map.Add(item, index++);
            }

            return Helper(0, inorder.Length - 1);
        }

        private static LeetCode106TreeNode Helper(int left, int right)
        {
            if (left > right) return null;

            var root_val = postOrder[post_idx];
            var root = new LeetCode106TreeNode(root_val);
            var index = idx_map[root_val];

            post_idx--;

            root.right = Helper(index + 1, right);
            root.left = Helper(left, index - 1);

            return root;
        }

    }

}