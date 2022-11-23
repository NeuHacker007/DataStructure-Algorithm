/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-22-2022 20:00:44
 * LastEditTime: 11-22-2022 20:06:00
 * FilePath: \CSharpLeetCodeSolution\Solution\L.24.Swap.Nodes.In.Pairs.Medium\LeetCode24.cs
 * Description: 
 */

namespace TwoPointerSolution
{
    public class LeetCode24ListNode
    {
        public int val;
        public LeetCode24ListNode next;
        public LeetCode24ListNode(int val = 0, LeetCode24ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class LeetCode24
    {
        public static LeetCode24ListNode SwapPairs(LeetCode24ListNode head)
        {
            if (head == null) return null;

            LeetCode24ListNode result = head;
            LeetCode24ListNode slow = head;
            LeetCode24ListNode fast = head.next;

            while (fast != null)
            {
                int temp = slow.val;
                slow.val = fast.val;
                fast.val = temp;

                if (fast.next == null || slow.next.next == null)
                {
                    break;
                }

                fast = fast.next.next;
                slow = slow.next.next;
            }

            return result;
        }
    }

}