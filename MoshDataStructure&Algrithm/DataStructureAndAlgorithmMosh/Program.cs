using AVLTreeDemo;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            AVLTree tree = new AVLTree ();
            tree.InsertRecursion (5);
            tree.InsertRecursion (7);
            tree.InsertRecursion (3);
            tree.InsertRecursion (4);
            tree.InsertRecursion (2);
            tree.InsertRecursion (8);
            tree.InsertRecursion (10);
            System.Console.WriteLine (tree);

        }
    }

}