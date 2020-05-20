using HeapDemo;
using MaxHeapHeaplifyDemo;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            MinHeap heap = new MinHeap (6);
            heap.Insert (10, "a");
            heap.Insert (5, "b");
            heap.Insert (17, "c");
            heap.Insert (4, "d");
            heap.Insert (22, "e");
             heap.Insert (1, "e");
            heap.Remove ();
            heap.Remove ();
            heap.Remove ();
            System.Console.WriteLine (heap);
            // System.Console.WriteLine ("Done");
            //     int[] numbers = new int[] { 5, 3, 8, 4, 1, 2 };
            //  //   Maxheap.Heaplify (numbers);

            //     System.Console.WriteLine (heap.IsMaxHeap (numbers));

            System.Console.WriteLine ("Done");
        }
    }

}