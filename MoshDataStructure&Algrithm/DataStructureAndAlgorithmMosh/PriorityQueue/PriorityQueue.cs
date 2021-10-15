using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgorithmMosh.PriorityQueue
{
    public class PriorityQueue<T>
    {
        private T[] _items;
        private int _count;

        public PriorityQueue(int capacity)
        {
            _items = new T[capacity];
        }
        public void Add(T item)
        {
            int i;
            for ( i = _count -1; i >=0; i--)
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

            _items[i + 1] = item;
            _count++;

        }

        public T Remove()
        {
            return _items[--_count];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("[");
            foreach (var item in _items)
            {
                sb.Append(item);
                sb.Append(",");
            }

            sb.Append("]");

            return sb.ToString().TrimEnd(',');
        }
    }
}
