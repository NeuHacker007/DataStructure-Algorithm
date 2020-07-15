using TrieDemo;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {

            Trie trie = new Trie ();
            trie.Insert ("canada");
            //System.Console.WriteLine(trie.Contains("Canada"));
            trie.Traverse ();
            System.Console.WriteLine ("===========================");
            trie.Traverse (TraverseOrder.PostOrder);
            System.Console.WriteLine ("Done");
        }
    }

}