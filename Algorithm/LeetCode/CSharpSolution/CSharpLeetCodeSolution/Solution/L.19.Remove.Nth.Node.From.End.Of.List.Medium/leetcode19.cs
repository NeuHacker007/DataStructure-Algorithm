/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-21-2022 19:15:34
 * LastEditTime: 10-21-2022 20:13:16
 * FilePath: \CSharpLeetCodeSolution\Solution\L.19.Remove.Nth.Node.From.End.Of.List.Medium\leetcode19.cs
 * Description: 
 */
using System;
using System.Text;
namespace LinkedListSolution
{
    public class LeetCode19ListNode
    {
        public int val;
        public LeetCode19ListNode next;
        public LeetCode19ListNode(int val = 0, LeetCode19ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class TestListData
    {
        private LeetCode19ListNode _data;

        public TestListData()
        {
            
        }

        public void Add(int val)
        {
            var newNode = new LeetCode19ListNode(val);
            if (_data == null)
            {
                _data = newNode;
                return;
            }
            var lastNode = GetLastNode();
            
            lastNode.next = newNode;
        }

        private LeetCode19ListNode GetLastNode()
        {
            var temp = _data;
            while (temp.next != null)
            {
                temp = temp.next;
            }

            return temp;
        }

        public string PrintElements {
            get {
                var head = this._data;
                StringBuilder sb = new StringBuilder();
                while (head.next != null)
                {
                    sb.Append(head.val.ToString());
                    head = head.next;
                }
                sb.Append(head.val.ToString());
                return sb.ToString();
            }
        }
    }
    public class Leetcode19
    {
        public static LeetCode19ListNode RemoveNthFromEnd(LeetCode19ListNode head, int n)
        {
            LeetCode19ListNode dummy = new LeetCode19ListNode(0);
            dummy.next = head;

            LeetCode19ListNode fast = dummy;
            LeetCode19ListNode slow = dummy;


            for (int i = 1; i <= n + 1; i++)
            {
                fast = fast.next;
            }

            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            slow.next = slow.next.next;

            return dummy.next;
        }
    }
}

