using QueueDemo;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            ArrayQueue queue = new ArrayQueue (10);
            queue.Enqueue (10);
            queue.Enqueue (20);
            queue.Enqueue (30);
            System.Console.WriteLine (queue);

            System.Console.WriteLine (queue.Dequeue ());
            System.Console.WriteLine (queue);
            System.Console.WriteLine (queue.Dequeue ());
            System.Console.WriteLine (queue);

        }
    }
}