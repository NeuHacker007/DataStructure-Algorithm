using System.Collections.Generic;
using HashTableExcercises;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            int[] tests = new int[7] { 1, 7, 5, 5, 7, 12, 2 };
            System.Console.WriteLine (HashTableExcercise.CountPairsWithKDiffByMosh (tests, 2));
            System.Console.WriteLine(HashTableExcercise.CountPairsWithKDiff(tests, 2));
        }
    }

}