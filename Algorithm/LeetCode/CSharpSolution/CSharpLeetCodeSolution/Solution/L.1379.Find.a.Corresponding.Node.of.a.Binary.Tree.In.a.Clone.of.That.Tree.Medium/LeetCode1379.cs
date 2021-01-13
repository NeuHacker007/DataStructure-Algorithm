/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-13-2021 09:41:23
 * LastEditTime: 01-13-2021 09:46:30
 * FilePath: \CSharpLeetCodeSolution\Solution\L.1379.Find.a.Corresponding.Node.of.a.Binary.Tree.In.a.Clone.of.That.Tree.Medium\LeetCode1379.cs
 * Description: 
 */

namespace Solution
{
    public class LeetCode1379TreeNode
    {
        public int val;
        public LeetCode1379TreeNode left;
        public LeetCode1379TreeNode right;
        public LeetCode1379TreeNode(int x) { val = x; }
    }

    public class LeetCode1379
    {
        static LeetCode1379TreeNode ans;
        public static LeetCode1379TreeNode GetTargetCopy(LeetCode1379TreeNode original, LeetCode1379TreeNode cloned, LeetCode1379TreeNode target)
        {
            Helper(original, cloned, target);

            return ans;
        }

        private static void Helper(LeetCode1379TreeNode o, LeetCode1379TreeNode c, LeetCode1379TreeNode t)
        {
            if (o == null) return;

            Helper(o.left, c.left, t);

            if (o == t) ans = c;

            Helper(o.right, c.right, t);
        }
    }

}