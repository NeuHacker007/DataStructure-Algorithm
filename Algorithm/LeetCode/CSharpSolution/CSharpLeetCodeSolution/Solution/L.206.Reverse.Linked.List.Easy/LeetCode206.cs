/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-20-2021 22:51:29
 * LastEditTime: 10-20-2021 22:57:21
 * FilePath: \CSharpLeetCodeSolution\Solution\L.206.Reverse.Linked.List.Easy\LeetCode206.cs
 * Description: 
 */

namespace LinkedListSolution
{
    public class LeetCode206Node
    {
        public int val;
        public LeetCode206Node next;
        public LeetCode206Node(int val = 0, LeetCode206Node next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class LeetCode206
    {
        //TODO: Add Problem.MD/Solution.MD
        public static LeetCode206Node ReverseLinkedList(LeetCode206Node head)
        {
            LeetCode206Node pre = null;
            var curr = head;

            while (curr != null)
            {
                var tmp = curr.next;
                curr.next = pre;
                pre = curr;
                curr = tmp;
            }

            return pre;
        }
    }

}
