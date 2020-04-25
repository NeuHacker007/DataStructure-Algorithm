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
            System.Console.WriteLine (tree.FindMinValue ());
            System.Console.WriteLine (tree.FindMinValueInBinarySearchTree ());
            System.Console.WriteLine ("done");
            BinaryTree tree1 = new BinaryTree ();
            tree1.Insert (5);
            tree1.Insert (7);
            tree1.Insert (3);
            tree1.Insert (2);
            tree1.Insert (8);
            tree1.Insert (10);

            System.Console.WriteLine (tree.Equals (tree1));
        }
    }

}