using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgorithmMosh.PriorityQueue
{
    public class ArrayPriorityQueue<T>
    {
        private T[] _items;
        private int _count;

        public ArrayPriorityQueue(int capacity)
        {
            _items = new T[capacity];
        }
        /// <summary>
        /// O (n) in worst case
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (IsFull())
            {
                throw new Exception("queue is full");
            }

            var positionToInsert = ShiftItemsForInsert(item);

            _items[positionToInsert] = item;
            _count++;

        }

        private int ShiftItemsForInsert(T item)
        {
            int i;
            for (i = _count - 1; i >= 0; i--)
            {
                if (Comparer<T>.Default.Compare(_items[i], item) > 0)
                {
                    _items[i + 1] = _items[i];
                }
                else
                {
                    break;
                }
            }

            return i + 1;
        }
        /// <summary>
        /// O(1)
        /// </summary>
        /// <returns></returns>
        public T Remove()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is empty");
            }
            return _items[--_count];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public bool IsFull()
        {
            return _count == _items.Length;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("[");

            for (var i = 0; i < _items.Length; i++)
            {
                sb.Append(_items[i]);

                if (i == _items.Length - 1) break;
                sb.Append(",");
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}
