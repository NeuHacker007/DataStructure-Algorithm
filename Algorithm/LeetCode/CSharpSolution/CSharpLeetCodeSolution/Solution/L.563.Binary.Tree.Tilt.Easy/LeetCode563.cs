using System;
namespace Solution {
     public class LeetCode563TreeNode {
      public int val;
      public LeetCode563TreeNode left;
      public LeetCode563TreeNode right;
      public LeetCode563TreeNode(int val=0, LeetCode563TreeNode left=null, LeetCode563TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }

  public class LeetCode563 {
      
      static int ans = 0;
      public static int TiltSumInBST(LeetCode563TreeNode root) {
          
          PostOrder(root);
          return ans;
      }

      private static int PostOrder(LeetCode563TreeNode root) {
          if (root == null) return 0;

          int left = PostOrder(root.left);
          int right = PostOrder(root.right);

           ans += Math.Abs(left - right);

           return root.val + left + right;      
      }
  }
}