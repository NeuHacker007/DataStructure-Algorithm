using System;
using TrieDemo;
using DataStructureAndAlgorithmMosh.Heap;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args)
        {
            var nums = new int[] {5, 3, 10, 1, 4, 2};

            //HeapSort.ShowHeapSortAsc(numbers);
            //HeapSort.ShowHeapSortDesc(numbers);

            //var nums = new int[] {5, 3, 8, 4, 1, 2};

            //var nums = new int[]{};

           // ArrayMaxHeaplify.MaxHeaplify(nums);

            Console.WriteLine(HeapJudger.IsMaxHeap<int>(nums));
            Console.WriteLine(nums.PrintArray());
            
            Console.ReadLine();


        }

    }
}