/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-01-2021 19:56:04
 * LastEditTime: 12-01-2021 19:59:19
 * FilePath: \CSharpLeetCodeSolution\Solution\L.160.Intersection.of.Two.Linked.List.Easy\LeetCode160.cs
 * Description: 
 */

namespace LinkedListSolution
{
    public class LeetCode160ListNode
    {
        public int val;
        public LeetCode160ListNode next;
        public LeetCode160ListNode(int x) { val = x; }
    }


    public class LeetCode160
    {
        public static LeetCode160ListNode GetIntersectionNode(LeetCode160ListNode headA, LeetCode160ListNode headB)
        {
            var p1 = headA;
            var p2 = headB;
            while (p1 != p2)
            {
                if (p1 == null)
                {
                    p1 = headB;
                }
                else
                {
                    p1 = p1.next;
                }

                if (p2 == null)
                {
                    p2 = headA;
                }
                else
                {
                    p2 = p2.next;
                }
            }

            return p1;
        }
    }
}