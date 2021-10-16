using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;

namespace DataStructureAndAlgorithmMosh.Heap
{
    public class MinHeap<T>
    {
        private readonly int _capacity;
        private T[] _elements;
        private int _count;

        public int Count => _count;

        public MinHeap(int capacity)
        {
            _capacity = capacity;
            _elements = new T[capacity];
        }

        public void Add(T element)
        {
            if (IsFull()) throw new Exception("Min Heap is full");
            _elements[_count++] = element;

            var index = _count - 1;

            while (index > 0
                   && IsCurrentLessThanParent(index))
            {
                Swap(index, GetParentIndex(index));

                index = GetParentIndex(index);
            }
        }

        private bool IsCurrentLessThanParent(int index)
        {
            return Comparer<T>
                .Default
                .Compare(_elements[index], _elements[GetParentIndex(index)]) < 0;
        }

        private void Swap(int first, int second)
        {
            var temp = _elements[first];

            _elements[first] = _elements[second];
            _elements[second] = temp;
        }

        public T Remove()
        {
            if (IsEmpty()) throw new Exception("Heap is empty");

            T result = _elements[0];

            _elements[0] = _elements[--_count];
           

            BubbleDown();


            return result;
        }

        private void BubbleDown()
        {
            var index = 0;

            while (index <= _count && !IsValidParent(index))
            {
                var smallerChildIndex = GetSmallerChildIndex(index);

                Swap(index, smallerChildIndex);

                index = smallerChildIndex;
            }
        }

        private int GetSmallerChildIndex(int index)
        {
            if (!HasLeftChild(index))
            {
                return index;
            }

            if (!HasRightChild(index))
            {
                return GetLeftChildIndex(index);
            }

            return Comparer<T>.Default.Compare(GetLeftChild(index), GetRightChild(index)) > 0
                ? GetRightChildIndex(index)
                : GetLeftChildIndex(index);
        }

        private bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) <= _count;
        }

        private bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) <= _count;
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
            {
                return true;
            }

            if (!HasRightChild(index))
            {
                return  Comparer<T>.Default.Compare(_elements[index], GetLeftChild(index)) <= 0;
            }
            return Comparer<T>.Default.Compare(_elements[index], GetLeftChild(index)) <= 0
                   && Comparer<T>.Default.Compare(_elements[index], GetRightChild(index)) <= 0;
        }
        private T GetRightChild(int index)
        {
            return _elements[GetRightChildIndex(index)];
        }
        private T GetLeftChild(int index)
        {
            return _elements[GetLeftChildIndex(index)];
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
        public bool IsFull()
        {
            return _count == _capacity;
        }

        public bool IsEmpty()
        {
            return _count == 0;
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
}
