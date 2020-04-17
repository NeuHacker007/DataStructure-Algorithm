using System;
using StackExcercise;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {

            MoshMinImplementation stack = new MoshMinImplementation ();

            stack.Push (5);
            stack.Push (2);
            stack.Push (1);
            stack.Push (10);
            System.Console.WriteLine (stack.Min ());
            stack.Pop ();
            System.Console.WriteLine (stack.Min ());

        }
    }
}