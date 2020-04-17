﻿using QueueDemo;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            ArrayCircularQueue queue = new ArrayCircularQueue (5);
            queue.Enqueue (10);
            queue.Enqueue (20);
            queue.Enqueue (30);
            System.Console.WriteLine (queue);

            System.Console.WriteLine (queue.Dequeue ());
            System.Console.WriteLine (queue);
            System.Console.WriteLine (queue.Dequeue ());
            System.Console.WriteLine (queue);
            queue.Enqueue (40);
            queue.Enqueue (50);
            queue.Enqueue (60);
            queue.Enqueue (70);
            //queue.Enqueue (80);
            System.Console.WriteLine (queue);

        }
    }
}