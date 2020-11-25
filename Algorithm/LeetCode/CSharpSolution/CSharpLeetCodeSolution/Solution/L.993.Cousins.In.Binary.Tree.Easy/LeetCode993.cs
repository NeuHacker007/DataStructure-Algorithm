namespace Solution
{
    public class LeetCode993TreeNode
    {
        public int val;
        public LeetCode993TreeNode left;
        public LeetCode993TreeNode right;
        public LeetCode993TreeNode(int val = 0, LeetCode993TreeNode left = null, LeetCode993TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode993
    {
        static int depthRecorder = -1;
        static bool isCousin = false;

        public static bool IsCousin(LeetCode993TreeNode root, int x, int y)
        {
            Helper(root, x, y, 0);
            return isCousin;
        }

        private static bool Helper(LeetCode993TreeNode root, int x, int y, int depth)
        {
            if (root == null) return false;
            if (depthRecorder != -1 && depth > depthRecorder)
            {
                return false;
            }

            if (root.val == x || root.val == y)
            {
                if (depthRecorder != -1)
                {
                    depthRecorder = depth;
                }
                return depthRecorder == depth;
            }

            var left = Helper(root.left, x, y, depth + 1);
            var right = Helper(root.right, x, y, depth + 1);

            // Condition 1: They are not in the same level
            // Condition 2: They must be the value of x, y 
            if (left && right && depthRecorder != depth + 1)
            {
                isCousin = true;
            }
            return left || right;
        }
    }

}