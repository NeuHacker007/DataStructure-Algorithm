/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-12-2021 21:42:59
 * LastEditTime: 10-12-2021 22:41:05
 * FilePath: \AmazonOnlineOA\AmazonOA10.11.2021\Code1Solution.cs
 * Description: 
 */

namespace OASolution
{
    public class SinglyLinkedListNode
    {

        public int Data;
        public SinglyLinkedListNode Next;

        public SinglyLinkedListNode(int val)
        {
            Data = val;
        }
    }
    public class Code1Solution
    {
        private int _MaxPages = int.MinValue;
        public int GetMaxReadPages(SinglyLinkedListNode Head)
        {
            if (Head == null) return 0;

            SinglyLinkedListNode Tail = null;

            var node = Head;

            // find the tail
            while (node != null)
            {
                Tail = node;
                node = node.Next;
            }

            var first = Head;
            var last = Tail;
            while (first != last)
            {
                var count = first.Data + last.Data;
                if (count > _MaxPages)
                {
                    _MaxPages = count;
                }

                // remove first
                first = RemoveFirst(first);
                if(first == last) {
                    first = last = null;
                } else {
                    //Remove Last
                    last = RemoveLast(first, last);
                }
                
            }


            return _MaxPages;
        }

        private SinglyLinkedListNode RemoveFirst(SinglyLinkedListNode first)
        {
            var second = first.Next;
            first.Next = null;
            first = second;
            return first;
        }

        private SinglyLinkedListNode RemoveLast(SinglyLinkedListNode Head, SinglyLinkedListNode Tail)
        {
            SinglyLinkedListNode last;
            var pre = GetPreviousNode(Head, Tail);

            pre.Next = null;
            last = pre;
            return last;
        }

        private SinglyLinkedListNode GetPreviousNode(SinglyLinkedListNode Head, SinglyLinkedListNode Tail)
        {
            var current = Head;
            while (current != null)
            {

                if (current.Next == Tail) break;
                current = current.Next;
            }

            return current;
        }
    }

}
