// Project: Solution
// Author:yfeva
// Date: 05/05/2024 09:05
// Created: 05/05/2024 09:05
// FileName: LeetCode2095.cs
// Description:

namespace Solution.L._2095.DeleteTheMiddleNodeOfALinkedList.Medium;

public class LeetCode2095
{
    public class LeetCode2095ListNode
    {
        public int val;
        public LeetCode2095ListNode next;

        public LeetCode2095ListNode(int val = 0, LeetCode2095ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static LeetCode2095ListNode DeleteMiddle(LeetCode2095ListNode head)
    {
        if (head.next == null) {
            return null;
        }

        int count  =0; 
        LeetCode2095ListNode p1 = head, p2 = head;

        while (p1 != null) {
            count++;
            p1 = p1.next;
        }

        int middlePosition = count /2;

        for (int i = 0; i < middlePosition -1; i++) {
            p2 = p2.next;
        }
        p2.next = p2.next.next;
        return head;
    }
    
    
    public static LeetCode2095ListNode DeleteMiddle2(LeetCode2095ListNode head)
    {
        if (head.next == null)
            return null;
        
        // Initialize two pointers, 'slow' and 'fast'.
        LeetCode2095ListNode slow = head, fast = head.next.next;
        
        // Let 'fast' move forward by 2 nodes, 'slow' move forward by 1 node each step.
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }
        
        // When 'fast' reaches the end, remove the next node of 'slow' and return 'head'.
        slow.next = slow.next.next;
        return head;
    }
}