using AVLTreeExcercise;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            Tree tree = new Tree ();
            tree.Insert (20);
            tree.Insert (10);
            tree.Insert (30);

            System.Console.WriteLine (tree.IsBalanced (tree));
            System.Console.WriteLine ("done");

        }
    }

}