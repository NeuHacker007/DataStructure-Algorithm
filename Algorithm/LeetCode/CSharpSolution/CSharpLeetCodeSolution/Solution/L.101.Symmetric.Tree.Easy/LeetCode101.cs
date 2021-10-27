/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-27-2021 09:43:44
 * LastEditTime: 10-27-2021 09:50:01
 * FilePath: \CSharpLeetCodeSolution\Solution\L.101.Symmetric.Tree.Easy\LeetCode101.cs
 * Description: 
 */


namespace TreeSolution
{

    public class LeetCode101TreeNode
    {
        public int val;
        public LeetCode101TreeNode left;
        public LeetCode101TreeNode right;
        public LeetCode101TreeNode(int val = 0, LeetCode101TreeNode left = null, LeetCode101TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode101
    {
        public bool IsSymetric(LeetCode101TreeNode root)
        {
            return Helper(root, root);
        }

        private bool Helper(LeetCode101TreeNode tree1, LeetCode101TreeNode tree2)
        {
            if (tree1 == null && tree2 == null) return true;
            if (tree1 == null || tree2 == null) return false;

            return tree1.val == tree2.val
                && Helper(tree1.left, tree2.right)
                && Helper(tree1.right, tree2.left);
        }
    }

}
