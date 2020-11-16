using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Solution
{
    /*
     *
     * You are given two non-empty linked lists representing two non-negative integers.
     * The digits are stored in reverse order and each of their nodes contain a single digit.
     * Add the two numbers and return it as a linked list.
     * You may assume the two numbers do not contain any leading zero, except the number 0 itself.

            Example:

            Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
            Output: 7 -> 0 -> 8
            Explanation: 342 + 465 = 807.

     */

    public class ListNodeLc2
    {
        public int Value;
        public ListNodeLc2 Next;

        public ListNodeLc2(int value, ListNodeLc2 next = null)
        {
            this.Value = value;
            this.Next = next;
        }

    }

    public class LeetCode2
    {
        public static ListNodeLc2 AddTwoNumbers(ListNodeLc2 list1, ListNodeLc2 list2)
        {
            //1. Initialize current node to dummy head of the returning list

            ListNodeLc2 dummyHead = new ListNodeLc2(0);
            var curr = dummyHead;

            //2. Initialize carry to 0.
            int carry = 0;

            //4. Loop through lists list1 and list2 until you reach both ends.
            while (list1 != null || list2 != null)
            {
                // Set x to node list1's value. If list1 has reached the end of list1, set to 0.
                int x = list1?.Value ?? 0;
                // Set y to node list2's value. If list2 has reached the end of list2, set to 0.
                int y = list2?.Value ?? 0;
                // Set sum = x + y + carrysum = x + y + carrysum = x + y + carry.
                int sum = x + y + carry;
                // Update carry = sum / 10.
                carry = sum / 10;
                // Create a new node with the digit value of(sum mod 10)
                curr.Next = new ListNodeLc2(sum % 10);
                // and set it to current node's next, then advance current node to next.
                curr = curr.Next;
                // Advance both list1 and list2.

                list1 = list1?.Next;
                list2 = list2?.Next;



            }

            //5.  Check if carry=1,
            //    if so append a new node with digit  to the returning list
            if (carry > 0)
            {
                curr.Next = new ListNodeLc2(carry);
            }
            // return dummyhead.next;
            return dummyHead.Next;

        }


    }
}
