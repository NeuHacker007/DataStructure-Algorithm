using System;
using StackExcercise;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            TwoStacksInOneArray array = new TwoStacksInOneArray (10);

            array.Push1 (10);
            array.Push1 (20);
            array.Push1 (30);
            // System.Console.WriteLine (array.isFull1 ());
            // System.Console.WriteLine (array.isFull2 ());
            // array.Push2 (40);
            // array.Push2 (50);
            System.Console.WriteLine (array.Pop1 ());
            // System.Console.WriteLine (array.Pop2 ());
            System.Console.WriteLine(array.isEmpty2());
            System.Console.WriteLine(array.isFull2());

        }
    }
}