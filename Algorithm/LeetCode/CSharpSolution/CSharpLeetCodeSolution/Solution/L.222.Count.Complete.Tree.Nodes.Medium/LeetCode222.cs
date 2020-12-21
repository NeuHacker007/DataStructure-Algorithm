/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-21-2020 14:44:40
 * LastEditTime: 12-21-2020 14:48:44
 * FilePath: \CSharpLeetCodeSolution\Solution\L.222.Count.Complete.Tree.Nodes.Medium\LeetCode222.cs
 * Description: 
 */


namespace Solution
{
    public class LeetCode222TreeNode
    {
        public int val;
        public LeetCode222TreeNode left;
        public LeetCode222TreeNode right;
        public LeetCode222TreeNode(int val = 0, LeetCode222TreeNode left = null, LeetCode222TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode222
    {
        private static int _count = 0;
        public static int CountNodes(LeetCode222TreeNode root)
        {
            Helper(root);
            return _count;
        }

        private static void Helper(LeetCode222TreeNode root)
        {
            if (root == null) return;
            _count++;
            Helper(root.left);
            Helper(root.right);
        }
    }

}