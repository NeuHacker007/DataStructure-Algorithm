using QueueDemo;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            PriorityQueue queue = new PriorityQueue(10);
            queue.Enqueue(5);
            queue.Enqueue(3);
            queue.Enqueue(6);
            queue.Enqueue(1);
            queue.Enqueue(2);
            System.Console.WriteLine(queue);

            System.Console.WriteLine(queue.Dequeue());
            System.Console.WriteLine(queue);
            System.Console.WriteLine(queue.Dequeue());
            System.Console.WriteLine(queue);

        }
    }
}