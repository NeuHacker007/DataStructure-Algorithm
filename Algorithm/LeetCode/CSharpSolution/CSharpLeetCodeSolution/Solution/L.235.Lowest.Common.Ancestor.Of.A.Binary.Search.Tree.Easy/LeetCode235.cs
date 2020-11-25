namespace Solution
{
    public class LeetCode235TreeNode
    {
        public int val;
        public LeetCode235TreeNode left;
        public LeetCode235TreeNode right;
        public LeetCode235TreeNode(int x) { val = x; }
    }

    public class LeetCode235
    {
        public LeetCode235TreeNode LowestCommonAncestor(LeetCode235TreeNode root, LeetCode235TreeNode p, LeetCode235TreeNode q)
        {
            var parent = root.val;
            var pVal = p.val;
            var qVal = q.val;

            // since this is BST, so the left is always less than right
            // if p, q meet that one less than parent and another one greater than parent, then this point should be their LCA
            if (pVal > parent && qVal > parent)
            {
                return LowestCommonAncestor(root.right, p, q);
            }
            else if (pVal < parent && qVal < parent)
            {
                return LowestCommonAncestor(root.left, p, q);
            }
            else
            {
                return root;
            }
        }
    }

}