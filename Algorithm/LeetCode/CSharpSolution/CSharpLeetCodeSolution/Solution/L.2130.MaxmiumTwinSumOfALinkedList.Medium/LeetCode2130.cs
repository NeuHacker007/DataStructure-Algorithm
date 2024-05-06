// Project: Solution
// Author:yfeva
// Date: 05/05/2024 19:05
// Created: 05/05/2024 19:05
// FileName: LeetCode2130.cs
// Description:

using System;

namespace Solution.L._2130.MaxmiumTwinSumOfALinkedList.Medium;

public class LeetCode2130
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }


    public static int PairSum(ListNode head)
    {
        if (head is null) return 0;

        ListNode slow = head;
        ListNode fast = head;

        ListNode prev = null;
        while (fast is not null && fast.next != null)
        {
            fast = fast.next.next;
            // reverse the left part from the middle
            ListNode temp = slow.next;
            slow.next = prev;
            prev = slow;
            slow = temp;
        }

        int result = 0;
        // prev start point from left part
        // slow is start point from right part 
        while (slow != null)
        {
            result = Math.Max(result, prev!.val + slow.val);
            prev = prev.next;
            slow = slow.next;
        }

        return result;
    }
}