/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-19-2021 12:48:52
 * LastEditTime: 10-19-2021 21:43:42
 * FilePath: \CSharpLeetCodeSolution\Solution\L.1804.Implement.Trie.II.Medium\LeetCode1804.cs
 * Description: 
 */
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace TrieSolution
{
    public class Trie
    {

        private class Node
        {
            public char Value;
            private Dictionary<char, Node> _children;
            public bool IsWordEnd = false;

            public Node(char value)
            {
                _children = new Dictionary<char, Node>();
                this.Value = value;
            }

            public bool HasChild(char ch)
            {
                return _children.ContainsKey(ch);
            }

            public void AddChild(char ch)
            {
                _children.Add(ch, new Node(ch));
            }

            public Node GetChild(char ch)
            {
                return _children[ch];
            }
        }
        public Trie()
        {

        }

        private Node _root = new Node(' ');
        // used to count the word frequency
        // Key -> word Value -> Frequency 
        private Dictionary<string, int> wordCountMap = new Dictionary<string, int>();
        public void Insert(string word)
        {

            var current = _root;
            var sb = new StringBuilder();
            foreach (var ch in word)
            {
                if (!current.HasChild(ch))
                {
                    current.AddChild(ch);
                }
                sb.Append(ch);
                current = current.GetChild(ch);
            }
            if (!wordCountMap.ContainsKey(sb.ToString()))
            {
                wordCountMap.Add(sb.ToString(), 1);
            }
            else
            {
                wordCountMap[sb.ToString()]++;
            }
            current.IsWordEnd = true;
        }



        public int CountWordsEqualTo(string word)
        {
            // return 0 when words not in the dictionary
            if (!wordCountMap.ContainsKey(word)) return 0;
            return wordCountMap[word];
        }

        public int CountWordsStartingWith(string prefix)
        {
            // filter out the word with prefix and add their frequency together
            var starWithList = wordCountMap.Where(wc => wc.Key.StartsWith(prefix));
            var count = 0;
            foreach (var item in starWithList)
            {
                count += item.Value;
            }
            return count;
        }


        public void Erase(string word)
        {
            //TODO: Didn't realy remove the word from trie. 
            if (wordCountMap.ContainsKey(word)) wordCountMap[word]--;
            if (wordCountMap[word] == 0)
            {
                wordCountMap.Remove(word);
            }
        }
    }
}
