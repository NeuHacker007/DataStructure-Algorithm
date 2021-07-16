/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 07-16-2021 08:33:14
 * LastEditTime: 07-16-2021 08:46:52
 * FilePath: \CSharpLeetCodeSolution\Solution\L.109.Convert.Sorted.List.To.Binary.Search.Tree.Medium\LeetCode109.cs
 * Description: 
 */
namespace LcTreeSolution
{
    public class LeetCode109ListNode
    {
        public int val;
        public LeetCode109ListNode next;
        public LeetCode109ListNode(int val = 0, LeetCode109ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class LeetCode109TreeNode
    {
        public int val;
        public LeetCode109TreeNode left;
        public LeetCode109TreeNode right;
        public LeetCode109TreeNode(int val = 0, LeetCode109TreeNode left = null, LeetCode109TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LeetCode109
    {
        private static LeetCode109ListNode _head;
        public static LeetCode109TreeNode SortedList2BST(LeetCode109ListNode head)
        {
            //1. find the size 
            var size = FindListLength(head);
            //2. construct the BST
            _head = head;

            return ConvertList2BST(0, size - 1);
        }

        private static int FindListLength(LeetCode109ListNode head)
        {
            var size = 0;
            var ptr = head;

            while (ptr != null)
            {
                size++;
                ptr = ptr.next;
            }

            return size;
        }

        private static LeetCode109TreeNode ConvertList2BST(int left, int right)
        {
            if (left > right) return null;

            var mid = left + (right - left) / 2;
            // process the left nodes;

            var leftNode = ConvertList2BST(left, mid - 1);
            var root = new LeetCode109TreeNode(_head.val);

            root.left = leftNode;

            _head = _head.next;

            root.right = ConvertList2BST(mid + 1, right);

            return root;
        }
    }

}