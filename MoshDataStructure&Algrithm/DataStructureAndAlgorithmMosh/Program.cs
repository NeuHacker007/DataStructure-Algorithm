using System;
using TrieDemo;
using DataStructureAndAlgorithmMosh.Heap;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args)
        {
            var numbers = new int[] {5, 3, 10, 1, 4, 2};

            HeapSort.ShowHeapSortAsc(numbers);
            HeapSort.ShowHeapSortDesc(numbers);
            Console.ReadLine();
        }

    }
}