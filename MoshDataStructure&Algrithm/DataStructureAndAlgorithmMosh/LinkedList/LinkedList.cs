/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-12-2021 20:56:25
 * LastEditTime: 10-12-2021 21:38:10
 * FilePath: \DataStructureAndAlgorithmMosh\LinkedList\LinkedList.cs
 * Description: 
 */
namespace DataStructure
{
    public class LinkedList
    {
        private class Node
        {
            public int Val;
            public Node Next;

            public Node()
            {

            }
            public Node(int value)
            {
                Val = value;
                Next = null;
            }
        }

        private Node Head;
        private Node Tail;
        public LinkedList()
        {

        }
        // Add Node
        public void AddFirst(int val)
        {
            var node = new Node(val);

            if (IsListEmpty())
            {
                Head = Tail = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }
        }

        public void AddLast(int val)
        {
            var node = new Node(val);
            if (IsListEmpty())
            {
                Head = Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
        }
        // Remove Node

        public void RemoveFirst()
        {
            // edge case check
            if (IsListEmpty()) throw new System.Exception();

            if (Head == Tail)
            {
                // if only 1 item in the list
                Head = Tail = null;
                return;
            }
            var second = Head.Next;
            Head.Next = null;
            Head = second;
        }

        public void RemoveLast()
        {
            if (IsListEmpty()) throw new System.Exception();

            if (Head == Tail)
            {
                // if only 1 item in the list
                Head = Tail = null;
                return;
            }

            var pre = GetPreviousNode(Tail);
            Tail = pre;
            Tail.Next = null;
        }

        private Node GetPreviousNode(Node node)
        {

            var current = Head;

            while (current != null)
            {
                if (current.Next == node) return current;
                current = current.Next;
            }
            return null;
        }

        // Contains
        // Index of

        public int IndexOf(int item)
        {
            var index = 0;

            var current = Head;

            while (current != null)
            {
                if (current.Val == item) return index;

                current = current.Next;
                index++;
            }
            return -1;
        }

        public bool Contains(int item)
        {
            return IndexOf(item) != -1;
        }

        private bool IsListEmpty() => Head == null;
    }
}