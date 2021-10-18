using System;
using TrieDemo;
using HeapDemo;

namespace DataStructureAndAlgorithmMosh
{
    class Program
    {
        static void Main(string[] args)
        {
            // var nums = new int[] {5, 3, 10, 1, 4, 2};

            //HeapSort.ShowHeapSortAsc(numbers);
            //HeapSort.ShowHeapSortDesc(numbers);

            //var nums = new int[] {5, 3, 8, 4, 1, 2};

           // //var nums = new int[]{};

           // // ArrayMaxHeaplify.MaxHeaplify(nums);

           // // Console.WriteLine(HeapJudger.IsMaxHeap<int>(nums));
           // //  Console.WriteLine(nums.PrintArray());
            
           // queue = new MinHeapBasedPriorityQueue();
           // queue.Add("Ivan", 5);
           // queue.Add("Eva", 3);
           // queue.Add("Guopin", 10);
           // queue.Add("Tom", 1);
           // queue.Add("jack", 4);
           // queue.Add("Baby", 2);
           // //Console.WriteLine(queue);
           // //queue.Remove();
           // //Console.WriteLine(queue);
           // //queue.Remove();
           // //Console.WriteLine(queue);
           //var tuple = queue.Remove();
           //Console.WriteLine($"Value: {tuple.Item1}; Priority:{tuple.Item2}");
           //// Console.WriteLine(queue);
           ///
           MinHeap<int> minHeap = new MinHeap<int>();

           minHeap.Add(5);
           minHeap.Add(3);
           minHeap.Add(8);
           minHeap.Add(4);
           minHeap.Add(1);
           minHeap.Add(2);
           Console.WriteLine(minHeap);
           minHeap.Remove();
           Console.WriteLine(minHeap);
           minHeap.Remove();
           Console.WriteLine(minHeap);
           minHeap.Remove();
           Console.WriteLine(minHeap);
           minHeap.Remove();
           Console.WriteLine(minHeap);
           minHeap.Remove();
           Console.WriteLine(minHeap);
           minHeap.Remove();
           Console.WriteLine(minHeap);
            Console.ReadLine();


        }

    }
}