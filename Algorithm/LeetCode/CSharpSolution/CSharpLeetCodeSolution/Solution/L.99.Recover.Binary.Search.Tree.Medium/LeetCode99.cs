/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 06-15-2021 09:23:14
 * LastEditTime: 06-15-2021 17:33:23
 * FilePath: \CSharpLeetCodeSolution\Solution\L.99.Recover.Binary.Search.Tree.Medium\LeetCode99.cs
 * Description: 
 */
using System.Collections.Generic;
using System.Linq;
namespace LcTreeSolution
{
    public class LeetCode99TreeNode
    {
        public int val;
        public LeetCode99TreeNode left;
        public LeetCode99TreeNode right;
        public LeetCode99TreeNode(int val = 0, LeetCode99TreeNode left = null, LeetCode99TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }


    public class LeetCode99
    {
        LeetCode99TreeNode x = null;
        LeetCode99TreeNode y = null;
        LeetCode99TreeNode pre = null;
        public void RecoverBSTTree(LeetCode99TreeNode root)
        {
            FindSwapElements(root);
            Swap(x, y);
        }

        private void FindSwapElements(LeetCode99TreeNode root)
        {
            if (root == null) return;

            FindSwapElements(root.left);
            if (pre != null && root.val < pre.val)
            {
                /*
                this is one of the unnecessary clevernessthat show up in code. We know
                i. x is the first number that violated the bst rule, therefore it should be the number that is greater than the subsequent value.. meaning x is always found in pred
                ii. y is the second number that violated the bst rule, therefore it should be the number that is smaller than the preceding value, meaning y is always found in root

                iii. at each step, check if x is null, then assign pred to x..if not assign root to y and break..

                that is it.

                however, the unnecessary cleverness assigns root to y every time..then assigns pred to x if x is null else breaks... We really don't need root to be assigned to y if x is null.. It is unnecessary cleverness because it is actually slowing down the performance by adding additional assignment operation

                the obvious and better (in running time) algorithm is
                if (x==null){
                x= pred
                }
                else {
                y=root;
                break;
                }
                */

                if (x == null)
                {
                    x = pre;
                }
                else
                {
                    y = root;
                    return;
                }
            }
            pre = root;
            FindSwapElements(root.right);
        }

        private void Swap(LeetCode99TreeNode x, LeetCode99TreeNode y)
        {
            int temp = x.val;
            x.val = y.val;
            y.val = temp;
        }
    }

}