namespace Solution {
    public class LeetCode437Node {
        public int val;
        public LeetCode437Node left;
        public LeetCode437Node right;
        public LeetCode437Node (int val = 0, LeetCode437Node left = null, LeetCode437Node right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class LeetCode437 {
        public static int PathSum (LeetCode437Node root, int sum) {
            if (root == null) return 0;
            var pathLeadingCount = Count (root, sum);

            var leftPathSum = PathSum (root.left, sum);

            var rightPathSum = PathSum (root.right, sum);

            return pathLeadingCount + leftPathSum + rightPathSum;
        }

        private static int Count (LeetCode437Node root, int sum) {
            if (root == null) return 0;

            var baseVal = root.val == sum ? 1 : 0;

            var left = Count (root.left, sum - root.val);
            var right = Count (root.right, sum - root.val);

            return baseVal + left + right;
        }
    }
}