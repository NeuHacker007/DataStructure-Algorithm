/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 06-15-2021 20:51:14
 * LastEditTime: 06-15-2021 21:23:03
 * FilePath: \CSharpLeetCodeSolution\Solution\L.563.Construct.Binary.Tree.From.String.Medium\LeetCode563.cs
 * Description: 
 */
using System.Collections.Generic;
using System.Linq;
namespace LcTreeSolution
{
    public class LeetCode563TreeNode
    {
        public int val;
        public LeetCode563TreeNode left;
        public LeetCode563TreeNode right;
        public LeetCode563TreeNode(int val = 0, LeetCode563TreeNode left = null, LeetCode563TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode563
    {
        public static LeetCode563TreeNode Str2Tree(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;
            var root = new LeetCode563TreeNode();
            var stack = new Stack<LeetCode563TreeNode>();
            stack.Push(root);

            for (var i = 0; i < s.Length; ++i)
            {
                var node = stack.Pop();

                if (char.IsDigit(s[i]) || s[i] == '-')
                {
                    var numberData = GetNumber(s, i);
                    var val = numberData.Keys.FirstOrDefault();
                    i = numberData.Values.FirstOrDefault();
                    node.val = val;
                    if (i < s.Length && s[i] == '(')
                    {
                        stack.Push(node);
                        node.left = new LeetCode563TreeNode();
                        stack.Push(node.left);
                    }
                    else if (s[i] == '(' && node.left != null)
                    {
                        stack.Push(node);
                        node.right = new LeetCode563TreeNode();
                        stack.Push(node.right);
                    }
                }
            }

            return stack.Count == 0 ? root : stack.Pop();
        }

        private static Dictionary<int, int> GetNumber(string s, int index)
        {
            var isNegative = false;

            if (s[index] == '-')
            {
                isNegative = true;
                index++;
            }

            var number = 0;

            while (index < s.Length && char.IsDigit(s[index]))
            {
                number = number * 10 + (s[index] - '0');
                index++;
            }

            return new Dictionary<int, int>() { { isNegative ? -number : number, index } };
        }


    }
}