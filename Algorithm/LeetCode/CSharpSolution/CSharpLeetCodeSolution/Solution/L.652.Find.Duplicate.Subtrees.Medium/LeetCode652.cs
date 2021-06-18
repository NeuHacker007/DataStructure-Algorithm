/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 06-18-2021 09:05:49
 * LastEditTime: 06-18-2021 15:07:23
 * FilePath: \CSharpLeetCodeSolution\Solution\L.652.Find.Duplicate.Subtrees.Medium\LeetCode652.cs
 * Description: 
 */
using System.Collections.Generic;
using System.Text;
namespace LcTreeSolution
{
    public class LeetCode652TreeNode
    {
        public int val;
        public LeetCode652TreeNode left;
        public LeetCode652TreeNode right;
        public LeetCode652TreeNode(int val = 0, LeetCode652TreeNode left = null, LeetCode652TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode652
    {
        private static List<LeetCode652TreeNode> result = new List<LeetCode652TreeNode>();

        private static Dictionary<string, int> _trees = new Dictionary<string, int>();
        public static IList<LeetCode652TreeNode> FindDuplicateSubtrees(LeetCode652TreeNode root)
        {
            if (root == null) return new List<LeetCode652TreeNode>();
            Save(root);
            return result;
        }
        private static string Save(LeetCode652TreeNode root)
        {
            var s = new StringBuilder();
            s.Append(root.val.ToString());

            if (root.left != null)
            {
                s.Append(" ");
                s.Append(Save(root.left));
            }
            else
            {
                s.Append(" null");
            }

            if (root.right != null)
            {
                s.Append(" ");
                s.Append(Save(root.right));
            }
            else
            {
                s.Append(" null");
            }

            var tree = s.ToString();

            if (_trees.ContainsKey(tree))
            {
                if (_trees[tree] == 1)
                {
                    result.Add(root);
                }
                _trees[tree]++;
            }
            else
            {
                _trees.Add(tree, 1);
            }

            return tree;
        }
    }

}