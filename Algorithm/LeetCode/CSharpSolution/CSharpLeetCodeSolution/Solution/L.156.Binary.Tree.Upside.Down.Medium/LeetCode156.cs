/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 03-21-2021 21:29:35
 * LastEditTime: 03-21-2021 21:50:33
 * FilePath: \CSharpLeetCodeSolution\Solution\L.156.Binary.Tree.Upside.Down.Medium\LeetCode156.cs
 * Description: 
 */

namespace Solution
{
    public class LeetCode156TreeNode
    {
        public int val;
        public LeetCode156TreeNode left;
        public LeetCode156TreeNode right;
        public LeetCode156TreeNode(int val = 0, LeetCode156TreeNode left = null, LeetCode156TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode156
    {
        static LeetCode156TreeNode newNode = null;

        public static LeetCode156TreeNode UpsideDownBinaryTree(LeetCode156TreeNode root)
        {
            Helper(root);
            return newNode;
        }

        private static LeetCode156TreeNode Helper(LeetCode156TreeNode root)
        {
            if (root == null) return null;

            if (root.left == null)
            {
                newNode = root;
                return root;
            }

            var left = Helper(root.left);

            left.left = root.right;
            left.right = root;
            root.left = null;
            root.right = null;

            return left.right;
        }
    }
}

