using System.Collections.Generic;
using BinaryTreeDemo;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            BinaryTree tree = new BinaryTree ();
            tree.Insert (5);
            tree.Insert (7);
            tree.Insert (3);
            tree.Insert (2);
            tree.Insert (8);
            tree.Insert (10);
            tree.PrintNodesAtKDistance (2);
            var list = tree.GetNodesAtKDistance (2);

            foreach (var item in list) {
                System.Console.WriteLine (item);
            }
        }
    }

}