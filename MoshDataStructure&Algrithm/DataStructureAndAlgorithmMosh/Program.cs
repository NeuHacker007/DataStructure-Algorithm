using System.Collections.Generic;
using HashTableExcercises;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            int[] tests = new int[7] { 1, 4, 4, 2, 2, 2, 4 };
            System.Console.WriteLine (HashTableExcercise.FindMostRepeatedEle (tests));
        }
    }

}