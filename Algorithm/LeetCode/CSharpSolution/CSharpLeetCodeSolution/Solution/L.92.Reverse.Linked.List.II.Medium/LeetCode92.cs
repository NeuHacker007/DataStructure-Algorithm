/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 06-03-2021 15:08:39
 * LastEditTime: 06-03-2021 15:17:21
 * FilePath: \CSharpLeetCodeSolution\Solution\L.92.Reverse.Linked.List.II.Medium\LeetCode92.cs
 * Description: 
 */


namespace LcLinkedListSolution
{
    public class LeetCode92ListNode
    {
        public int val;
        public LeetCode92ListNode next;
        public LeetCode92ListNode(int val = 0, LeetCode92ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class LeetCode92
    {
        private static LeetCode92ListNode Successor = null;
        public static LeetCode92ListNode ReverseBetween(LeetCode92ListNode head, int left, int right)
        {
            if (left == 1)
            {
                return ReverseN(head, right);
            }

            head.next = ReverseBetween(head.next, left - 1, right - 1);

            return head;

        }

        private static LeetCode92ListNode ReverseN(LeetCode92ListNode head, int n)
        {
            if (n == 1)
            {
                Successor = head.next;
                return head;
            }

            var last = ReverseN(head.next, n - 1);

            head.next.next = last;
            head.next = Successor;

            return last;
        }


    }

}