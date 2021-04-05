/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 04-05-2021 14:30:39
 * LastEditTime: 04-05-2021 14:40:45
 * FilePath: \CSharpLeetCodeSolution\Solution\L.508.Most.Frequent.Subtree.Sum.Medium\LeetCode508.cs
 * Description: 
 */
using System.Collections.Generic;
using System.Linq;
namespace Solution
{

    public class LeetCode508TreeNode
    {
        public int val;
        public LeetCode508TreeNode left;
        public LeetCode508TreeNode right;
        public LeetCode508TreeNode(int val = 0, LeetCode508TreeNode left = null, LeetCode508TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode508
    {
        static Dictionary<int, int> map = new Dictionary<int, int>();
        public static int[] FindFrequentTreeSum(LeetCode508TreeNode root)
        {
            if (root == null) return new int[0];
            var maxSumValue = map.Max(msv => msv.Value);
            var ans = new List<int>();

            foreach (var item in map)
            {
                if (maxSumValue == item.Value)
                {
                    ans.Add(item.Key);
                }
            }

            return ans.ToArray();

        }

        private static int Helper(LeetCode508TreeNode root)
        {
            if (root == null) return 0;

            var left = Helper(root.left);
            var right = Helper(root.right);

            var sum = 0;
            sum = root.val + left + right;

            // this condition means we found the duplicate summary num
            if (!map.TryAdd(sum, 1))
            {
                // Frequent + 1
                map[sum]++;
            }

            return sum;
        }
    }
}