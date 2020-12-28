/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-28-2020 18:11:41
 * LastEditTime: 12-28-2020 18:24:59
 * FilePath: \CSharpLeetCodeSolution\Solution\L.285.Inorder.Successor.In.BST.Medium\LeetCode285.cs
 * Description: 
 */

using System.Collections.Generic;

namespace Solution
{
    public class LeetCode285TreeNode
    {
        public int val;
        public LeetCode285TreeNode left;
        public LeetCode285TreeNode right;
        public LeetCode285TreeNode(int x) { val = x; }
    }

    public class LeetCode285
    {
        static List<LeetCode285TreeNode> list = new List<LeetCode285TreeNode>();
        public static LeetCode285TreeNode InorderSuccessor(LeetCode285TreeNode root, LeetCode285TreeNode p)
        {
            if (root == null || p == null) return null;
            Helper(root);

            var index = list.FindIndex(x => x.val == p.val);

            return index >= 0 && (index + 1 < list.Count) ? list[index + 1] : null;

        }

        private static void Helper(LeetCode285TreeNode root)
        {
            if (root == null) return;
            Helper(root.left);
            list.Add(root);
            Helper(root.right);
        }
    }

}