using System;
using TrieDemo;
using DataStructureAndAlgorithmMosh.Heap;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args)
        {
            MinHeap<int> minHeap = new MinHeap<int>(5);

            minHeap.Add(4);
            minHeap.Add(24);
            minHeap.Add(1);
            minHeap.Add(1);
            minHeap.Add(10);
            minHeap.Remove();
            minHeap.Remove();
            minHeap.Remove();
            minHeap.Remove();
            Console.WriteLine(minHeap.ToString());


        }

    }
}