namespace Solution {

    public class LeetCode938Node {
        public int val;
        public LeetCode938Node left;
        public LeetCode938Node right;
        public LeetCode938Node (int val = 0, LeetCode938Node left = null, LeetCode938Node right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class LeetCode938 {
        static int ans;
        public static int RangeSumBST (LeetCode938Node root, int L, int R) {
            ans = 0;
            Dfs (root, L, R);
            return ans;
        }

        private static void Dfs (LeetCode938Node root, int L, int R) {
            if (root == null) return;

            if (root.val >= L && root.val <= R) {
                ans += root.val;
            }

            if (root.val > L) {
                Dfs (root.left, L, R);
            }

            if (root.val < R) {
                Dfs (root.right, L, R);
            }
        }
    }
}