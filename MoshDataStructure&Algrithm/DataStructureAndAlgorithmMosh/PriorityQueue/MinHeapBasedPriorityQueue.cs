using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgorithmMosh.PriorityQueue
{
    
    public class MinHeapBasedPriorityQueue
    {

        private class Node : IComparable
        {
            private readonly string _value;
            private readonly int _priority;

            public Node(string value, int priority)
            {
                _value = value;
                _priority = priority;
            } 

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;
                
                return this._priority - ((Node)obj)._priority;
            }

            public override string ToString()
            {
                return $"(value:{_value}, priority:{_priority})";
            }
        }

        private class MinHeap<T>
        {
            private readonly int _capacity;
            private T[] _elements;
            private int _count;

            public int Count => Count;
            public MinHeap(int capacity = 10)
            {
                _capacity = capacity;
                _elements = new T[capacity];
            }


            public void Add(T element)
            {
                if (IsFull) throw new Exception("Queue Is full");

                _elements[_count++] = element;

                BubbleUp();
            }

            public T Remove()
            {
                if (IsEmpty)
                {
                    throw new Exception("Queue is empty");
                }
                var result = _elements[0];

                _elements[0] = _elements[--_count];

                var index = 0;
                while (index <= _count
                      && Comparer<T>.Default.Compare(_elements[index], _elements[2 * index + 1]) >0
                      && Comparer<T>.Default.Compare(_elements[index], _elements[2 * index + 2]) >0)
                {
                    var smallerChildIndex = Comparer<T>
                        .Default
                        .Compare(_elements[2 * index + 1],  _elements[2 * index + 2]) >0
                        ? 2 * index + 2
                        : 2 * index + 1;

                    Swap(index, smallerChildIndex);

                    index = smallerChildIndex;
                }



                return result;
            }

            private void BubbleUp()
            {
                var index = _count - 1;

                while (index > 0
                       &&
                       Comparer<T>.Default.Compare(_elements[index], GetParent(index)) < 0)
                {
                    var parentIndex = GetParentIndex(index);
                    Swap(index, parentIndex);

                    index = parentIndex;
                }
            }

            private void Swap(int first, int second)
            {
                var temp = _elements[second];
                _elements[second] = _elements[first];
                _elements[first] = temp;
            }

            private T GetParent(int index)
            {
                return _elements[GetParentIndex(index)];
            }
            private int GetParentIndex(int index)
            {
                return (index - 1) / 2;
            }
            public bool IsEmpty => _count == 0;

            public bool IsFull => _count == _capacity;

            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.Append("[");

                for (var i = 0; i < _count; i++)
                {
                    sb.Append(_elements[i].ToString());

                    if (i == _count - 1) break;
                    sb.Append(",");
                }

                sb.Append("]");

                return sb.ToString();
            }
        }

        private MinHeap<Node> minHeap;
        public MinHeapBasedPriorityQueue()
        {
            minHeap = new MinHeap<Node>();
        }
        public void Add(string value, int priority)
        {
            var node = new Node(value, priority);

            minHeap.Add(node);
            Console.WriteLine(minHeap.ToString());
        }

        public void Remove()
        {
            minHeap.Remove();
            Console.WriteLine(minHeap.ToString());
        }

        public bool IsEmpty()
        {
            return minHeap.IsEmpty;
        }

        public bool IsFull()
        {
            return minHeap.IsFull;
        }

        public int Size()
        {
            return minHeap.Count;
        }



    }
}
