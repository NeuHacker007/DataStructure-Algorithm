namespace LcTreeSolution
{
    public class LeetCode606TreeNode
    {
        public int val;
        public LeetCode606TreeNode left;
        public LeetCode606TreeNode right;
        public LeetCode606TreeNode(int val = 0, LeetCode606TreeNode left = null, LeetCode606TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public bool IsLeafNode()
        {
            return left == null && right == null;
        }
        public bool HasRightChild()
        {
            return right != null;
        }
    }

    public class LeetCode606
    {
        public static string Tree2Str(LeetCode606TreeNode root)
        {
            if (root == null) return string.Empty;
            if (root.IsLeafNode()) return root.val + "";
            if (!root.HasRightChild()) return $"{root.val}({Tree2Str(root.left)})";
            // since this is the binary tree, so if it has right child it must have left child
            return $"{root.val}({Tree2Str(root.left)})({Tree2Str(root.right)})";
        }
    }

}