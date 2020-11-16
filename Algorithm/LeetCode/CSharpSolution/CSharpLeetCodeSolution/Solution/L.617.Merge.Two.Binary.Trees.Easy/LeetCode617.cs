namespace Solution {

    public class LeetCode617Node {
        public int val;
        public LeetCode617Node left;
        public LeetCode617Node right;
        public LeetCode617Node (int val = 0, LeetCode617Node left = null, LeetCode617Node right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public override string ToString () {
            return $"Value = {val}";
        }
    }
    public class LeetCode617 {
        public static LeetCode617Node MergeTrees (LeetCode617Node t1, LeetCode617Node t2) {
            if (t1 == null) return t2;
            if (t2 == null) return t1;

            var root = new LeetCode617Node (t1.val + t2.val);
            root.left = MergeTrees (t1.left, t2.left);
            root.right = MergeTrees (t1.right, t2.right);
            return root;
        }
    }

}