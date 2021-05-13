/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 05-13-2021 13:40:02
 * LastEditTime: 05-13-2021 13:44:38
 * FilePath: \CSharpLeetCodeSolution\Solution\L.538.Convert.BST.To.Greater.Tree.Medium\LeetCode538.cs
 * Description: 
 */
namespace Solution
{


    public class LeetCode538TreeNode
    {
        public int val;
        public LeetCode538TreeNode left;
        public LeetCode538TreeNode right;
        public LeetCode538TreeNode(int val = 0, LeetCode538TreeNode left = null, LeetCode538TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode538
    {
        private static int sum = 0;
        public static LeetCode538TreeNode ConvertGreaterBST(LeetCode538TreeNode root)
        {
            if (root != null)
            {
                ConvertGreaterBST(root.right);
                sum += root.val;
                root.val = sum;
                ConvertGreaterBST(root.left);
            }
            return root;
        }
    }
}