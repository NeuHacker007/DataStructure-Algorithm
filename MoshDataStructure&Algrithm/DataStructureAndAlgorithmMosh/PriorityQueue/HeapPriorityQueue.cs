using System;
using System.Collections.Generic;
using System.Text;
using DataStructureAndAlgorithmMosh.Heap;

namespace DataStructureAndAlgorithmMosh.PriorityQueue
{
    public class HeapPriorityQueue<T>
    {
        private MaxHeap<T> heap = new MaxHeap<T>();

        public void Add(T item)
        {
            heap.Add(item);
        }

        public T Remove()
        {
            return heap.Remove();
        }
    }
}
