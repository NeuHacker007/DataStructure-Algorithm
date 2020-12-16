/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-15-2020 21:46:52
 * LastEditTime: 12-15-2020 21:55:05
 * FilePath: \CSharpLeetCodeSolution\Solution\L.173.Binary.Search.Tree.Iterator.Medium\LeetCode173.cs
 * Description: 
 */

using System.Collections.Generic;
namespace Solution
{

    public class LeetCode173TreeNode
    {
        public int val;
        public LeetCode173TreeNode left;
        public LeetCode173TreeNode right;
        public LeetCode173TreeNode(int val = 0, LeetCode173TreeNode left = null, LeetCode173TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode173
    {
        Queue<int> inorder = new Queue<int>();
        public LeetCode173(LeetCode173TreeNode root)
        {
            Helper(root);
        }

        public int Next()
        {
            return inorder.Dequeue();
        }

        public bool HasNext()
        {
            return inorder.Count != 0;
        }

        private void Helper(LeetCode173TreeNode root)
        {
            if (root == null) return;
            Helper(root.left);
            inorder.Enqueue(root.val);
            Helper(root.right);

        }
    }
}