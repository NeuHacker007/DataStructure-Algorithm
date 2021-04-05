/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 04-05-2021 09:31:41
 * LastEditTime: 04-05-2021 09:44:25
 * FilePath: \CSharpLeetCodeSolution\Solution\L.450.Delete.Node.In.A.BST.Medium\LeetCode450.cs
 * Description: 
 */

namespace Solution
{
    public class LeetCode450TreeNode
    {
        public int val;
        public LeetCode450TreeNode left;
        public LeetCode450TreeNode right;
        public LeetCode450TreeNode(int val = 0, LeetCode450TreeNode left = null, LeetCode450TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public bool IsLeaf()
        {
            return this.left == null && this.right == null;
        }

        public bool HasLeftChild()
        {
            return this.left != null;
        }

        public bool HasRightChild()
        {
            return this.right != null;
        }
    }

    public class LeetCode450
    {
        public static LeetCode450TreeNode DeleteNode(LeetCode450TreeNode root, int key)
        {
            if (root == null) return null;

            if (key > root.val)
            {
                root.right = DeleteNode(root.right, key);
            }
            else if (key < root.val)
            {
                root.left = DeleteNode(root.left, key);
            }
            else
            {
                if (!root.IsLeaf())
                {
                    root = null;
                }
                else if (root.HasRightChild())
                {
                    root.val = Successor(root);
                    root.right = DeleteNode(root.right, root.val);
                }
                else
                {
                    root.val = Predecessor(root);
                    root.left = DeleteNode(root.left, root.val);
                }
            }
            return root;

        }

        private static int Successor(LeetCode450TreeNode root)
        {
            root = root.right;
            while (root.left != null) root = root.left;

            return root.val;
        }

        private static int Predecessor(LeetCode450TreeNode root)
        {
            root = root.left;
            while (root.right != null) root = root.right;

            return root.val;
        }
    }

}