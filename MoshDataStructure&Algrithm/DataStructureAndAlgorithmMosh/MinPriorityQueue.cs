using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HeapDemo {

    public class MinHeap<T>
    {
        private readonly int _capacity;
        private T[] _elements;
        private int _count;
        public int Count => _count;
        public bool IsFull => _count == _capacity;
        public bool IsEmpty => _count == 0;

        public MinHeap(int capacity = 10)
        {
            _capacity = capacity;
            _elements = new T[capacity];
            _count = 0;
        }


        public void Add(T element)
        {
            _elements[_count++] = element;

            BubbleUp();
        }

        private void BubbleUp()
        {
            if (IsFull)
            {
                throw new Exception("Heap is full");
            }
            var index = _count - 1;

            while (index > 0
                   && Comparer<T>
                       .Default
                       .Compare(_elements[index], _elements[GetParentIndex(index)]) < 0)
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);

                index = parentIndex;
            }
        }

        private void Swap(int first, int second)
        {
            var temp = _elements[first];
            _elements[first] = _elements[second];
            _elements[second] = temp;
        }


        public T Remove()
        {
            if (IsEmpty) throw new Exception("Heap is empty");
            var result = _elements[0];
            _elements[0] = _elements[--_count];
            BubbleDown();

            return result;
        }

        private void BubbleDown()
        {
            var index = 0;

            while (index <= _count && !IsValidChild(index))
            {
                var smallerChildIndex = GetSmallerChildIndex(index);
                Swap(index, smallerChildIndex);
                index = smallerChildIndex;
            }
        }

        private int GetSmallerChildIndex(int index)
        {
            if (!HasLeftChild(index)) return index;

            if (!HasRightChild(index)) return GetLeftChildIndex(index);

            return Comparer<T>.Default.Compare(GetLeftChild(index), GetRightChild(index)) < 0 
                ? GetLeftChildIndex(index)
                : GetRightChildIndex(index);
        }

        private T GetLeftChild(int index)
        {
            return _elements[GetLeftChildIndex(index)];
        }

        private T GetRightChild(int index)
        {
            return _elements[GetRightChildIndex(index)];
        }
        private bool IsValidChild(int index)
        {
            if (!HasLeftChild(index))
            {
                return true;
            }

            if (!HasRightChild(index))
            {
                return Comparer<T>.Default.Compare(_elements[index], _elements[GetLeftChildIndex(index)]) <= 0;
            }

            return Comparer<T>.Default.Compare(_elements[index], _elements[GetLeftChildIndex(index)]) <= 0
                   && Comparer<T>.Default.Compare(_elements[index], _elements[GetRightChildIndex(index)]) <= 0;
        }

        private bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) <= _count;
        }

        private bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) <= _count;
        }

        private int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("[");

            for (var i = 0; i < _count; i++)
            {
                sb.Append(_elements[i]);

                if (i == _count - 1) break;
                sb.Append(",");
            }

            sb.Append("]");

            return sb.ToString();
        }
    }

    public class MinHeapBasedPriorityQueue<T>
    {
        private readonly MinHeap<T> _minHeap;


        public MinHeapBasedPriorityQueue(int capacity = 10)
        {
            _minHeap = new MinHeap<T>(capacity);
        }

        public void Add(T element)
        {
            _minHeap.Add(element);
        }

        public T Remove()
        {
            return _minHeap.Remove();
        }

        public bool IsEmpty => _minHeap.IsEmpty;
        public bool IsFull => _minHeap.IsFull;
        public int Size => _minHeap.Count;

        public override string ToString()
        {
            return _minHeap.ToString();
        }
    }
}