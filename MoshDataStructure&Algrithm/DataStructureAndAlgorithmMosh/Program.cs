using System.Collections.Generic;
using HashTableExcercises;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            int[] tests = new int[7] { 1, 5, 5, 5, 5, 12, 2 };
            System.Console.WriteLine (HashTableExcercise.CountPairsWithKDiff (tests, 2));
        }
    }

}