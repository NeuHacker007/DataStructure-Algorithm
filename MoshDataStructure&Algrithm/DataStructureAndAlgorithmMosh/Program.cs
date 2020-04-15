using System;
using LinkedListDemo;

namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            var list = new LinkedList ();
            list.AddLast (10);
            list.AddLast (20);
            list.AddLast (30);

            // Console.WriteLine (list.IndexOf (50));
            // Console.WriteLine (list.DeleteFirst());
            Console.WriteLine (list.DeleteLast ());
            Console.WriteLine (list.DeleteLast ());

        }
    }
}