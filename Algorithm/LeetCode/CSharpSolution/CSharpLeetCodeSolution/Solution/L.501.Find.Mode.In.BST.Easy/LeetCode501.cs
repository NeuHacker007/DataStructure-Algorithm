/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-25-2020 20:54:26
 * LastEditTime: 11-25-2020 21:29:39
 * FilePath: \CSharpLeetCodeSolution\Solution\L.501.Find.Mode.In.BST.Easy\LeetCode501.cs
 * Description: Implemented the LeetCode 501
 */

using System.Collections.Generic;
namespace Solution
{
    public class LeetCode501TreeNode
    {
        public int val;
        public LeetCode501TreeNode left;
        public LeetCode501TreeNode right;
        public LeetCode501TreeNode(int val = 0, LeetCode501TreeNode left = null, LeetCode501TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode501
    {
        static int? preValue = null;
        static int counter = 1;
        static int max = 0;
        public static int[] FindMode(LeetCode501TreeNode root)
        {
            List<int> modes = new List<int>();
            Helper(root, modes);
            return modes.ToArray();
        }

        private static void Helper(LeetCode501TreeNode root, List<int> modes)
        {
            if (root == null) return;

            Helper(root.left, modes);

            if (preValue != null)
            {
                if (preValue == root.val)
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }
            }

            if (counter > max)
            {
                counter = max;
                modes.Clear();
                modes.Add(root.val);
            }
            else if (counter == max)
            {
                modes.Add(root.val);
            }
            Helper(root.right, modes);
        }
    }
}