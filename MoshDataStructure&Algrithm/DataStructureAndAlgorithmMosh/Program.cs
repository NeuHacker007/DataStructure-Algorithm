using HeapDemo;
using MaxHeapHeaplifyDemo;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            // Heap heap = new Heap (5);
            // heap.Insert (10);
            // heap.Insert (5);
            // heap.Insert (17);
            // heap.Insert (4);
            // heap.Insert (22);
            // heap.Remove ();
            // System.Console.WriteLine ("Done");
            int[] numbers = new int[] { 5, 3, 8, 4, 1, 2 };
            Maxheap.Heaplify (numbers);

            System.Console.WriteLine ("Done");
        }
    }

}