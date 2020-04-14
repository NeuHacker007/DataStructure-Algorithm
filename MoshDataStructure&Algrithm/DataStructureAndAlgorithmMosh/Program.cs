using System;
using ArrayDemo;

namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            ArrayDemo.Array array = new ArrayDemo.Array (3);
            array.insert (10);
            array.insert (20);
            array.insert (30);
            array.insert (40);
            // Console.WriteLine (array);
            // array.removeAt (0);
            Console.WriteLine (array);
            array.removeAt (3);
            Console.WriteLine (array);
        }
    }
}