/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-27-2021 13:56:49
 * LastEditTime: 10-27-2021 14:03:22
 * FilePath: \CSharpLeetCodeSolution\Solution\L.203.Remove.Linked.List.Elements.Easy\LeetCode203.cs
 * Description: 
 */


namespace LinkedListSolution
{
    //TODO: finish the solution.MD and Problem.MD
    
    public class LeetCode203ListNode
    {
        public int val;
        public LeetCode203ListNode next;
        public LeetCode203ListNode(int val = 0, LeetCode203ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class LeetCode203
    {
        public static LeetCode203ListNode RemovElements(LeetCode203ListNode root, int val)
        {
            if (root == null) return null;

            var tmp = RemovElements(root.next, val);

            if (root.val == val) return tmp;
            root.next = tmp;

            return root;
        }
    }
}