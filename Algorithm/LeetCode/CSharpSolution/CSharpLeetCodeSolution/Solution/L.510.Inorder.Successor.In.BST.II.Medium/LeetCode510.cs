/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 04-05-2021 10:41:06
 * LastEditTime: 04-05-2021 10:48:10
 * FilePath: \CSharpLeetCodeSolution\Solution\L.510.Inorder.Successor.In.BST.II.Medium\LeetCode510.cs
 * Description: 
 */

namespace Solution
{
    public class LeetCode510Node
    {
        public int val;
        public LeetCode510Node left;
        public LeetCode510Node right;
        public LeetCode510Node parent;
    }

    public class LeetCode510
    {
        public static LeetCode510Node InorderSuccessor(LeetCode510Node root)
        {
            if (root.right != null)
            {
                root = root.right;

                while (root.left != null) root = root.left;

                return root;
            }

            if (root.parent != null && root == root.parent.right) root = root.parent;

            return root.parent;
        }
    }

}