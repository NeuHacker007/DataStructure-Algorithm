// Project: Solution
// Author:yfeva
// Date: 05/05/2024 18:05
// Created: 05/05/2024 18:05
// FileName: LeetCode328.cs
// Description:

namespace Solution.L._328.OddEvenLinkedList.Medium;

public class LeetCode328ListNode
{
    public int val;
    public LeetCode328ListNode next;

    public LeetCode328ListNode(int val = 0, LeetCode328ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class LeetCode328
{
    public static LeetCode328ListNode OddEvenList(LeetCode328ListNode head)
    {
        if (head is null) return head;

        LeetCode328ListNode odd = head;
        LeetCode328ListNode even = head.next;

        LeetCode328ListNode evenHead = even;

        while (even != null && even.next != null)
        {
            odd.next = odd.next.next;
            odd = odd.next;

            even.next = even.next.next;

            even = even.next;
        }

        odd.next = evenHead;

        return head;
    }
}