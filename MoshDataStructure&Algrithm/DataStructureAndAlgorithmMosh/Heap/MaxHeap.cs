using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DataStructureAndAlgorithmMosh.Heap
{
    public class MaxHeap<T>
    {
        private readonly int _capacity;
        private readonly T[] _elements;
        private int _count;
        public int Count => _count;
        public MaxHeap(int capacity)
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
            var index = _count - 1;
            //  var parentIndex = GetParentIndex(index);
            while (index > 0 &&
                   Comparer<T>
                       .Default
                       .Compare(_elements[index],
                           _elements[GetParentIndex(index)]) > 0)
            {
                Swap(GetParentIndex(index), index);

                index = GetParentIndex(index);
            }
        }

        private static int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private void Swap(int parentIndex, int index)
        {
            var temp = _elements[parentIndex];
            _elements[parentIndex] = _elements[index];
            _elements[index] = temp;
        }

        public T Remove()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is empty");
            }

            var result = _elements[0];

            _elements[0] = _elements[--_count];

            BubbleDown();

            return result;
        }

        private void BubbleDown()
        {
            var index = 0;

            while (index <= _count && !IsValidParent(index))
            {
                var largeChildIndex = GetLargeChildIndex(index);

                Swap(index, largeChildIndex);
                index = largeChildIndex;
            }
        }

        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= _count;
        }

        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= _count;
        }
        private int GetLargeChildIndex(int index)
        {
            if (!HasLeftChild(index)) return index;
            if (!HasRightChild(index)) return LeftChildIndex(index);
            return Comparer<T>.Default.Compare(GetLeftChild(index), GetRightChild(index)) > 0
                ? LeftChildIndex(index)
                : RightChildIndex(index);
        }

        /// <summary>
        /// we need consider the edge cases no children only 1 children.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index)) return true;
            if (!HasRightChild(index)) return Comparer<T>.Default.Compare(_elements[index], GetLeftChild(index)) >= 0;

            return Comparer<T>.Default.Compare(_elements[index], GetLeftChild(index)) >= 0
                   && Comparer<T>.Default.Compare(_elements[index], GetRightChild(index)) >= 0;
        }
        private T GetLeftChild(int index)
        {
            return _elements[LeftChildIndex(index)];
        }

        private T GetRightChild(int index)
        {
            return _elements[RightChildIndex(index)];
        }
        private static int RightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private static int LeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public bool IsFull()
        {
            return _count == _capacity;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("[");

            for (var i = 0; i < _elements.Length; i++)
            {
                sb.Append(_elements[i]);

                if (i == _elements.Length - 1) break;
                sb.Append(",");
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}
