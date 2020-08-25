using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.L141.Linked.List.Cycle.Easy
{
    public class LeetCode141Node
    {
        public int val;
        public LeetCode141Node next;
        public LeetCode141Node(int x)
        {
            val = x;
            next = null;
        }
    }

    public class LeetCode141
    {
        public static bool HasCircle(LeetCode141Node head)
        {
            if (head == null) return false;

            var slow = head;
            var fast = head;

            while (fast != null && fast.next != null)
            {
                // fast go two steps each time
                fast = fast.next.next;
                // slow go one step each time
                slow = slow.next;

                if (fast == slow)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
