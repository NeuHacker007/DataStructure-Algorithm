/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 04-06-2021 09:41:31
 * LastEditTime: 04-06-2021 09:50:25
 * FilePath: \CSharpLeetCodeSolution\Solution\L.513.Find.Bottom.Left.Tree.Value.Medium\LeetCode513.cs
 * Description: 
 */


namespace Solution
{
    public class LeetCode513TreeNode
    {
        public int val;
        public LeetCode513TreeNode left;
        public LeetCode513TreeNode right;
        public LeetCode513TreeNode(int val = 0, LeetCode513TreeNode left = null, LeetCode513TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public bool IsLeaf()
        {
            return this.left == null && this.right == null;
        }
    }

    public class LeetCode513
    {
        static LeetCode513TreeNode ans = null;
        static int maxLevel = int.MinValue;
        public static int FindBottomLeftValue(LeetCode513TreeNode root)
        {
            Helper(root, 0);

            return ans.val;
        }

        private static void Helper(LeetCode513TreeNode root, int level)
        {
            if (root == null) return;

            if (level > maxLevel && root.IsLeaf())
            {
                ans = root;
                maxLevel = level;
            }
            Helper(root.left, level + 1);
            Helper(root.right, level + 1);

        }

    }
}