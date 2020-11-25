using TrieDemo;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {

            Trie trie = new Trie ();
            trie.Insert ("car");
            trie.Insert ("care");
            trie.RemoveWord ("care");
            trie.RemoveWord ("car");

            System.Console.WriteLine (trie.Contains ("car"));
            System.Console.WriteLine (trie.Contains ("care"));
        }

    }
}