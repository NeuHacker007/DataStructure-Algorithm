/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 04-01-2021 16:17:05
 * LastEditTime: 04-01-2021 16:49:33
 * FilePath: \CSharpLeetCodeSolution\Solution\L.449.Serialize.And.Deserialize.BST.Medium\LeetCode449.cs
 * Description: 
 */
using System.Text;
using System.Collections.Generic;
namespace Solution
{
    public class LeetCode449TreeNode
    {
        public int val;
        public LeetCode449TreeNode left;
        public LeetCode449TreeNode right;
        public LeetCode449TreeNode(int x) { val = x; }
    }


    public class LeetCode449
    {
        public static string Serialize(LeetCode449TreeNode root)
        {
            var sb = PostOrderTraversal(root, new StringBuilder());
            // remove the extra trailer delimiter
            if (sb.Length > 0) sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public static LeetCode449TreeNode Deserialize(string data)
        {
            if (string.IsNullOrWhiteSpace(data)) return null;

            var nums = new List<int>();

            foreach (var v in data.Split(' '))
            {
                nums.Add(int.Parse(v));
            }

            return BuildTree(int.MinValue, int.MaxValue, nums);
        }


        private static LeetCode449TreeNode BuildTree(int lower, int upper, IList<int> nums)
        {
            if (nums.Count == 0) return null;

            var val = nums[nums.Count - 1];
            // make sure this matches the BST definition
            if (val < lower || val > upper)
                return null;
            // keep processing from the end of list
            nums.RemoveAt(nums.Count - 1);

            var root = new LeetCode449TreeNode(val);
            root.right = BuildTree(val, upper, nums);
            root.left = BuildTree(lower, val, nums);

            return root;

        }

        private static StringBuilder PostOrderTraversal(LeetCode449TreeNode root, StringBuilder sb)
        {
            if (root == null) return sb;

            PostOrderTraversal(root.left, sb);
            PostOrderTraversal(root.right, sb);

            sb.Append(root.val);
            sb.Append(' ');
            return sb;
        }
    }

}