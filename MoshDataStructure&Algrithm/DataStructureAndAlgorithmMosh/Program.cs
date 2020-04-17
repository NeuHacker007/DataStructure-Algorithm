using System.Collections.Generic;
using QueueExcercise;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            Queue<int> queue = new Queue<int> ();
            queue.Enqueue (10);
            queue.Enqueue (20);
            queue.Enqueue (30);
            queue.Enqueue (40);
            queue.Enqueue (50);
            System.Console.WriteLine (ReverseFirstKEleInQueue.ReverseKEleInQueue (queue, 5));
        }
    }
}