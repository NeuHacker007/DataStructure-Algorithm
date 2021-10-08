using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public class LeetCode642
    {
        //TODO: Add the problem.MD and Solution.MD
        public class TrieNode : IComparable<TrieNode>
        {
            public TrieNode[] children;
            public string sentence;
            public int times;
            public List<TrieNode> hotList;
            public TrieNode()
            {
                children = new TrieNode[128];
                sentence = "";
                times = 0;
                hotList = new List<TrieNode>();
            }
            /// <summary>
            /// Maintain the hot list
            /// </summary>
            /// <param name="node"></param>
            public void Update(TrieNode node)
            {
                if (!hotList.Contains(node))
                {
                    hotList.Add(node);
                }

                hotList.Sort();

                if (hotList.Count > 3)
                {
                    hotList.RemoveAt(hotList.Count -1);
                }

            }
            // implement the sorting order
            // 1. if times are equal then we use ASCII to compare trie node
            public int CompareTo(TrieNode other)
            {
                if (this.times == other.times)
                {
                    return string.Compare(this.sentence, other.sentence, StringComparison.CurrentCulture);
                }

                return other.times - this.times;
            }
        }

        private TrieNode root;
        private TrieNode curr;
        private StringBuilder sb; //used to preserve the sentence in each trie branch

        public LeetCode642(string[] sentences, int[] times)
        {
            root = new TrieNode();
            curr = root;

            sb = new StringBuilder();

            // 1. init the trie
            for (int i = 0; i < times.Length; i++)
            {
                Add(sentences[i], times[i]);
            }

        }
        /// <summary>
        /// Add each character of a sentence in to the Trie 
        /// </summary>
        /// <param name="sentence"></param>
        /// <param name="t"></param>
        public void Add(string sentence, int t)
        {
            TrieNode tmp = root;

            List<TrieNode> list = new List<TrieNode>();
            foreach (var ch in sentence)
            {
                if (tmp.children[ch] == null)
                {
                    tmp.children[ch] = new TrieNode();
                }

                tmp = tmp.children[ch];
                list.Add(tmp);
            }
            // sentence end;
            tmp.sentence = sentence;
            tmp.times += t;

            foreach (var node in list)  
            {
                node.Update(tmp);
            }
        }
    
        public IList<string> Input(char c)
        {
            var result = new List<string>();
            if (c == '#')
            {
                Add(sb.ToString(), 1);
                // reset
                sb.Clear();
                curr = root;
                return result;
            }

            sb.Append(c);

            if (curr != null)
            {
                curr = curr.children[c];
            }
            else
            {
                return result;
            }

            foreach (var node in curr.hotList)
            {
                result.Add(node.sentence);
            }

            return result;

        }
    }
}
