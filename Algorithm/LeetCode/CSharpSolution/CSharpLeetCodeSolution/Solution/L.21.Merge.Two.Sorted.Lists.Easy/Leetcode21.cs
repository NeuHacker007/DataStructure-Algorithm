using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public class ListNodeLc21
    {
        public int Value;
        public ListNodeLc21 Next;

        public ListNodeLc21(int Value, ListNodeLc21 node = null)
        {
            this.Value = Value;
            Next = node;
        }
    }

    public class Leetcode21
    {
        //Merge two sorted linked lists and return it as a new list.The new list should be made by splicing together the nodes of the first two lists.

        //    Example:

        //Input: 1->2->4, 1->3->4
        //Output: 1->1->2->3->4->4

        // time complexity (O(M x N))
        // space complexity (O(M x N)) because the both recursive call need to reach the end
        public static ListNodeLc21 MergeTwoList(ListNodeLc21 list1, ListNodeLc21 list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;


            if (list1.Value < list2.Value)
            {
                list1.Next = MergeTwoList(list1.Next, list2);
                return list1;
            }

            list2.Next = MergeTwoList(list1, list2.Next);
            return list2;
        }

        // time complexity (O(M x N))
        // space complexity (O(1)) because The iterative approach only allocates
        // a few pointers, so it has a constant overall memory footprint.
        public static ListNodeLc21 MergeTwoListV2(ListNodeLc21 list1, ListNodeLc21 list2)
        {

            //ListNodeLc21 dummyHead = new ListNodeLc21(-1);

            //var prev = dummyHead;

            //while (list1 != null && list2 != null)
            //{
            //    if (list1.Value <= list2.Value)
            //    {
            //        prev.Next = list1;
            //        list1 = list1.Next;
            //    }
            //    else
            //    {
            //        prev.Next = list2;
            //        list2 = list2.Next;
            //    }

            //    prev = prev.Next;
            //}

            //prev.Next = list1 == null ? list2 : list1;

            //return prev.Next;

            ListNodeLc21 prehead = new ListNodeLc21(-1);

            ListNodeLc21 prev = prehead;
            while (list1 != null && list2 != null)
            {
                if (list1.Value <= list2.Value)
                {
                    prev.Next = list1;
                    list1 = list1.Next;
                }
                else
                {
                    prev.Next = list2;
                    list2 = list2.Next;
                }

                prev = prev.Next;
            }

            // exactly one of list1 and list2 can be non-null at this point, so connect
            // the non-null list to the end of the merged list.
            prev.Next = list1 ?? list2;

            return prehead.Next;
        }



    }
}
