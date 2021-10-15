using System;
using TrieDemo;
using DataStructureAndAlgorithmMosh.PriorityQueue;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args)
        {

            ArrayPriorityQueue<int> queue = new ArrayPriorityQueue<int>(5);

            queue.Add(5);
            queue.Add(1);
            Console.WriteLine(queue.ToString());
            Console.ReadLine();
        }

    }
}