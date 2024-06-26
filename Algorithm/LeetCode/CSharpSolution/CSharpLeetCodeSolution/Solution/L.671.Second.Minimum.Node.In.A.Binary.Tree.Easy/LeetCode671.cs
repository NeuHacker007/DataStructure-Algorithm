/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-27-2020 20:41:40
 * LastEditTime: 11-27-2020 21:27:57
 * FilePath: \CSharpLeetCodeSolution\Solution\L.671.Second.Minimum.Node.In.A.Binary.Tree.Easy\LeetCode671.cs
 * Description: 
 */
using System;
namespace Solution
{
    public class LeetCode671TreeNode
    {
        public int val;
        public LeetCode671TreeNode left;
        public LeetCode671TreeNode right;
        public LeetCode671TreeNode(int val = 0, LeetCode671TreeNode left = null, LeetCode671TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode671
    {
        public static int FindSecondMinimumValue(LeetCode671TreeNode root)
        {
            if (root == null || root.left == null) return -1;

            var left = Helper(root.left, root.val);
            var right = Helper(root.right, root.val);

            if (left == -1) return right;

            if (right == -1) return left;

            return Math.Min(left, right);
        }
        public static int Helper(LeetCode671TreeNode root, int min)
        {
            if (root.val != min)
            {
                return root.val;
            }
            if (root.left == null) return -1;

            var left = Helper(root.left, root.val);
            var right = Helper(root.right, root.val);

            if (left == -1) return right;

            if (right == -1) return left;

            return Math.Min(left, right);
        }

        #region Version 2
        public static int FindSecondMinimumValueV2(LeetCode671TreeNode root)
        {
            return Dfs(root, root.val);
        }

        public static int Dfs(LeetCode671TreeNode root, int min)
        {
            if (root == null) return -1;
            if (root.val > min) return root.val;

            var left = Dfs(root.left, min);
            var right = Dfs(root.right, min);

            if (left != -1 || right != -1)
            {
                if (left == -1) return right;
                if (right == -1) return left;

                return Math.Min(left, right);
            }

            return -1;
        }
        #endregion

    }

}

