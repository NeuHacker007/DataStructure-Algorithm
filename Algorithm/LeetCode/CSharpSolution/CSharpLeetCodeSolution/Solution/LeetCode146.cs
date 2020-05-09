using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public class DLinkedDicNode
    {
        public int Key;
        public int Value;
        public DLinkedDicNode Previous;
        public DLinkedDicNode Post;

        public DLinkedDicNode(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }

    public class LeetCode146
    {
        //Design and implement a data structure for Least Recently Used(LRU) cache.
        //It should support the following operations: get and put.
        //    get(key) - Get the value(will always be positive) of the key if the key exists
        //               in the cache, otherwise return -1.
        //    put(key, value) - Set or insert the value if the key is not already
        //    present.When the cache reached its capacity,
        //    it should invalidate the least recently used item before inserting a new item.
        //    The cache is initialized with a positive capacity.
        //    Follow up:
        //Could you do both operations in O(1) time complexity?

        //Example:

        //LRUCache cache = new LRUCache(2 /* capacity */ );

        //cache.put(1, 1);
        //cache.put(2, 2);
        //cache.get(1);       // returns 1
        //cache.put(3, 3);    // evicts key 2
        //cache.get(2);       // returns -1 (not found)
        //cache.put(4, 4);    // evicts key 1
        //cache.get(1);       // returns -1 (not found)
        //cache.get(3);       // returns 3
        //cache.get(4);       // returns 4
        private Dictionary<int, DLinkedDicNode> cache = new Dictionary<int, DLinkedDicNode>();
        private int Size;
        private int Capacity;
        private DLinkedDicNode Head;
        private DLinkedDicNode Tail;

        public LeetCode146(int capacity)
        {
            Capacity = capacity;
            Size = 0;
            Head = new DLinkedDicNode(0, 0);
            Tail = new DLinkedDicNode(0, 0);

            // initialed an double linked list
            Head.Post = Tail;
            Tail.Previous = Head;
        }

        private void AddNode(DLinkedDicNode node)
        {
            // The following process is add the node in between Head node and second node
            // 1 <-> 5 now we want add 3
            // 1 <- 3
            node.Previous = Head;
            // 1 <- 3 -> 5
            node.Post = Head.Post;
            // 1 <- 3 <->5
            Head.Post.Previous = node;
            // 1 <-> 3 <-> 5
            Head.Post = node;

        }

        private void RemoveNode(DLinkedDicNode node)
        {
            // the following logic should be to remove a node in double list
            // 1 <-> 3 <-> 5, we want remove 3
            // temp1       temp2 temp1 holds previous element, temp2 holds post value
            DLinkedDicNode temp1 = node.Previous;
            DLinkedDicNode temp2 = node.Post;
            // 1<- 3 <-> 5
            // 1 ->5
            temp1.Post = temp2;
            // 1 <-> 5
            temp2.Previous = temp1;

        }

        private void MoveToHead(DLinkedDicNode node)
        {
            RemoveNode(node);
            AddNode(node);
        }

        private DLinkedDicNode PopTail()
        {
            DLinkedDicNode result = Tail.Previous;
            RemoveNode(result);

            return result;
        }



        public int Get(int key)
        {
            if (cache.ContainsKey(key))
            {
                MoveToHead(cache[key]);
                return cache[key].Value;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (!cache.ContainsKey(key))
            {
                var newNode = new DLinkedDicNode(key, value);
                
                AddNode(newNode);
                cache.Add(key, newNode);
                Size++;

                if (Size > Capacity)
                {
                    var temp = PopTail();
                    cache.Remove(temp.Key);
                    Size--;
                }

            }
            else
            {
                cache[key].Value = value;

                MoveToHead(cache[key]);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Hot[");
            while (Head != null)
            {
                sb.Append($"{Head.Value},");
                Head = Head.Post;
            }

            sb.Append("]Cold");

            return sb.ToString();
        }
    }
}
