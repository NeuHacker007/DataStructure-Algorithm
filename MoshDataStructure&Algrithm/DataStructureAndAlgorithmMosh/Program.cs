using System;
using System.Collections.Generic;
using QueueDemo;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            Queue<int> queue = new Queue<int> ();
            queue.Enqueue (10);
            queue.Enqueue (20);
            queue.Enqueue (30);
            var result = QueueReverse.Reverse (queue);
            System.Console.WriteLine (result.Dequeue ());
            System.Console.WriteLine (result.Dequeue ());
            System.Console.WriteLine (result.Dequeue ());
        }
    }
}