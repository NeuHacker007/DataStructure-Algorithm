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

           var a =  trie.FindWords("care");
           foreach (var item in a)
           {
               Console.WriteLine(item);
           }
            Console.WriteLine("end");
            Console.ReadLine();


        }

    }
}