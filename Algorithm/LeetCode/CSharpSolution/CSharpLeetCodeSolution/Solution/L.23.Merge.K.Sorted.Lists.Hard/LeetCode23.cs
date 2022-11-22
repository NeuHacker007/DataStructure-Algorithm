/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-21-2022 19:58:03
 * LastEditTime: 11-22-2022 09:38:26
 * FilePath: \CSharpLeetCodeSolution\Solution\L.23.Merge.K.Sorted.Lists.Hard\LeetCode23.cs
 * Description: 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace LinkedListSolution
{
    public class LeetCode23ListNode
    {
        public int val;
        public LeetCode23ListNode next;
        public LeetCode23ListNode(int val = 0, LeetCode23ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }


    public class LeetCode23
    {
        public LeetCode23ListNode MergeKLists(LeetCode23ListNode[] lists)
        {
            if (lists?.Any() == false) return null;
            return Merge(lists, 0, lists.Length - 1);
        }

        private LeetCode23ListNode Merge(LeetCode23ListNode[] lists, int start, int end)
        {
            if (start == end)
            {
                return lists[start];
            }

            int mid = start + (end - start) / 2;

            LeetCode23ListNode left = Merge(lists, start, mid);
            LeetCode23ListNode right = Merge(lists, mid + 1, end);
            return Merge(left, right);
        }

        private LeetCode23ListNode Merge(LeetCode23ListNode list1, LeetCode23ListNode list2)
        {
            LeetCode23ListNode dummy = new LeetCode23ListNode(0);
            LeetCode23ListNode current = dummy;

            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }

                current = current.next;
            }

            if (list1 != null)
            {
                current.next = list1;
            }

            if (list2 != null)
            {
                current.next = list2;
            }

            return dummy.next;
        }
    }
}