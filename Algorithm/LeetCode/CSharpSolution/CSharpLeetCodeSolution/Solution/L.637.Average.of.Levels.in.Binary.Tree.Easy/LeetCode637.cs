using System.Collections.Generic;

namespace Solution {
    public class LeetCode637TreeNode {
        public int val;
        public LeetCode637TreeNode left;
        public LeetCode637TreeNode right;
        public LeetCode637TreeNode (int val = 0, LeetCode637TreeNode left = null, LeetCode637TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode637 {
        #region BFS
        public static IList<double> AverageOfLevelsBFS (LeetCode637TreeNode root) {
            var results = new List<double> ();
            Bfs (root, results);
            return results;
        }

        private static void Bfs (LeetCode637TreeNode root, IList<double> results) {
            if (root == null) return;

            Queue<LeetCode637TreeNode> queue = new Queue<LeetCode637TreeNode> ();

            queue.Enqueue (root);

            while (queue.Count != 0) {
                long sum = 0; // current level sum;
                long count = 0; // get the total number in the level

                Queue<LeetCode637TreeNode> temp = new Queue<LeetCode637TreeNode> ();

                while (queue.Count != 0) {
                    var node = queue.Dequeue ();
                    sum += node.val;
                    count++;
                    // if current level the left child is not null, then add the node to the queue
                    if (node.left != null) {
                        temp.Enqueue (node.left);
                    }
                    // if current level the right child is not null, then add the node to the queue
                    if (node.right != null) {
                        temp.Enqueue (node.right);
                    }
                }

                queue = temp;
                // add the current level average to results
                results.Add (sum * 1.0 / count);
            }

        }

        #endregion
    }

}