/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-24-2020 11:29:45
 * LastEditTime: 12-24-2020 11:39:26
 * FilePath: \CSharpLeetCodeSolution\Solution\L.250.Count.Univalue.SubTrees.Medium\LeetCode250.cs
 * Description: 
 */

namespace Solution
{

    public class LeetCode250TreeNode
    {
        public int val;
        public LeetCode250TreeNode left;
        public LeetCode250TreeNode right;
        public LeetCode250TreeNode(int val = 0, LeetCode250TreeNode left = null, LeetCode250TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode250
    {
        static int count = 0;
        public static int CountUnivalSubTree(LeetCode250TreeNode root)
        {
            Helper(root, 0);
            return count;
        }

        private static bool Helper(LeetCode250TreeNode root, int val)
        {
            if (root == null) return true;

            if (!Helper(root.left, root.val) | !Helper(root.right, root.val)) return false;

            count++;

            return root.val == val;
        }
    }

}