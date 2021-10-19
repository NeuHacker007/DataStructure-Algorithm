using System;
using System.Text;
using DataStructureAndAlgorithmMosh.Tries;
using TrieDemo;
using HeapDemo;

namespace DataStructureAndAlgorithmMosh
{
    class Program
    {
        static void Main(string[] args)
        {

            DictionaryBasedTrie trie = new DictionaryBasedTrie();

            //trie.Add("cat");
            //trie.Add("can");
            //Console.WriteLine(trie.Contains("ca"));
            trie.Add("care");
            trie.Add("care");
            //trie.Add("Ivan");
            // trie.Traverse();
            var sb = new StringBuilder();
            sb.Append('a');
            
            trie.TraverseRecursive();
            Console.WriteLine("end");
            Console.ReadLine();


        }

    }
}