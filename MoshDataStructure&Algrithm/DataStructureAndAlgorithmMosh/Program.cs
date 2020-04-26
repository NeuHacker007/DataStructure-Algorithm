using System.Collections.Generic;
using BinaryTreeDemo;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            BinaryTree tree = new BinaryTree ();
            tree.Insert (5);
            tree.Insert (7);
            tree.Insert (3);
            tree.Insert (4);
            tree.Insert (2);
            tree.Insert (8);
            tree.Insert (10);
            System.Console.WriteLine (tree.Contains(5));
            System.Console.WriteLine (tree.Contains(20));
        }
    }

}