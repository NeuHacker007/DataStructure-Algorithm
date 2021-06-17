namespace LcTreeSolution
{
    public class LeetCode623TreeNode
    {
        public int val;
        public LeetCode623TreeNode left;
        public LeetCode623TreeNode right;

        public LeetCode623TreeNode(int val = 0, LeetCode623TreeNode left = null, LeetCode623TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode623
    {
        public static LeetCode623TreeNode AddOneRow(LeetCode623TreeNode root, int val, int depth)
        {
            if (depth == 1)
            {
                var temp = new LeetCode623TreeNode(val);
                temp.left = root;
                return temp;
            }

            InsertNode(val, root, 1, depth);
            return root;
        }

        private static void InsertNode(int val, LeetCode623TreeNode node, int height, int depth)
        {
            if (node == null) return;

            if (height == depth - 1)
            {
                var temp = node.left;
                node.left = new LeetCode623TreeNode(val);
                node.left.left = temp;

                temp = node.right;
                node.right = new LeetCode623TreeNode(val);
                node.right.right = temp;
            }
            else
            {
                InsertNode(val, node.left, height + 1, depth);
                InsertNode(val, node.right, height + 1, depth);
            }
        }

    }
}