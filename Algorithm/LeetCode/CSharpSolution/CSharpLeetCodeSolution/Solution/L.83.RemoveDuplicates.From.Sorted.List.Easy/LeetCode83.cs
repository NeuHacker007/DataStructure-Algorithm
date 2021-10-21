/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-20-2021 23:08:39
 * LastEditTime: 10-20-2021 23:10:46
 * FilePath: \CSharpLeetCodeSolution\Solution\L.83.RemoveDuplicates.From.Sorted.List.Easy\LeetCode83.cs
 * Description: 
 */

namespace LinkedListSolution
{


    public class LeetCode83Node
    {
        public int val;
        public LeetCode83Node next;
        public LeetCode83Node(int val = 0, LeetCode83Node next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class LeetCode83
    {
        public static LeetCode83Node RemoveDuplicates(LeetCode83Node head)
        {
            var curr = head;

            while (curr != null && curr.next != null)
            {
                if (curr.next.val == curr.val)
                {
                    curr.next = curr.next.next;
                }
                else
                {
                    curr = curr.next;
                }
            }
            return head;
        }
    }


}