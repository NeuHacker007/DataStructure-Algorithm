/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 06-04-2021 22:12:05
 * LastEditTime: 06-04-2021 22:33:07
 * FilePath: \CSharpLeetCodeSolution\Solution\L.234.Palindrome.Linked.List.Easy\LeetCode234.cs
 * Description: 
 */


namespace LcLinkedListSolution
{
    public class LeetCode234ListNode
    {
        public int val;
        public LeetCode234ListNode next;
        public LeetCode234ListNode(int val = 0, LeetCode234ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class LeetCode234
    {
        public static bool IsPalindrome(LeetCode234ListNode head)
        {
            var fast = head;
            var slow = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            if (fast != null) slow = slow.next;

            slow = Reverse(slow);
            fast = head;
            while (slow != null)
            {
                if (fast.val != slow.val) return false;

                fast = fast.next;
                slow = slow.next;
            }
            fast.next = Reverse(slow);
            return true;
        }

        private static LeetCode234ListNode Reverse(LeetCode234ListNode node)
        {
            LeetCode234ListNode pre = null;
            while (node != null)
            {
                var temp = node.next;
                node.next = pre;
                pre = node;
                node = temp;
            }

            return pre;
        }
    }
}