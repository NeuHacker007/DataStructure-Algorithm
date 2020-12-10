/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-09-2020 20:56:56
 * LastEditTime: 12-09-2020 21:15:11
 * FilePath: \CSharpLeetCodeSolution\Solution\L.105.Construct.Binary.Tree.From.Preorder.and.Inoder.Traversal.Medium\LeetCode105.cs
 * Description: 
 */

using System.Collections.Generic;
namespace Solution
{

    public class LeetCode105TreeNode
    {
        public int val;
        public LeetCode105TreeNode left;
        public LeetCode105TreeNode right;
        public LeetCode105TreeNode(int val = 0, LeetCode105TreeNode left = null, LeetCode105TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode105
    {
        static int pre_idx = 0;
        static int[] preOrder;
        static int[] inOrder;
        static Dictionary<int, int> idx_map = new Dictionary<int, int>();
        public static LeetCode105TreeNode BuildTree(int[] preoder, int[] inorder)
        {
            preOrder = preoder;
            inOrder = inorder;

            var index = 0;
            foreach (var item in inOrder)
            {
                idx_map.Add(item, index++);
            }

            return Helper(0, inOrder.Length);
        }

        private static LeetCode105TreeNode Helper(int left, int right)
        {
            if (left == right) return null;

            var root_val = preOrder[pre_idx];

            var root = new LeetCode105TreeNode(root_val);
            var index = idx_map[root_val];
            pre_idx++;

            root.left = Helper(left, index);
            root.right = Helper(index + 1, right);
            return root;
        }
    }
}