/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-20-2021 09:19:13
 * LastEditTime: 10-20-2021 09:40:12
 * FilePath: \CSharpLeetCodeSolution\Solution\L.208.Implement.Trie.Medium\LeetCode208.cs
 * Description: 
 */
using System.Collections.Generic;
namespace TrieSolution
{
    public class LeetCode208
    {
        private class Node
        {
            private char _value;
            private Dictionary<char, Node> _children;
            public bool IsWordEnd;

            public Node(char value)
            {
                _value = value;
                _children = new Dictionary<char, Node>();
                IsWordEnd = false;
            }

            public void AddChild(char ch)
            {
                _children.Add(ch, new Node(ch));
            }

            public bool HasChild(char ch)
            {
                return _children.ContainsKey(ch);
            }

            public Node GetChild(char ch)
            {
                return _children[ch];
            }

            public void RemoveChild(char ch)
            {
                _children.Remove(ch);
            }

            public bool HasChildren()
            {
                return _children.Count != 0;
            }

        }
        private Node _root;
        public LeetCode208()
        {
            _root = new Node(' ');
        }
        public void InsertWord(string word)
        {
            var current = _root;

            foreach (var ch in word)
            {
                if (!current.HasChild(ch))
                {
                    current.AddChild(ch);
                }

                current = current.GetChild(ch);
            }
            current.IsWordEnd = true;
        }

        public bool Contains(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return false;

            var current = _root;

            foreach (var ch in word)
            {
                if (!current.HasChild(ch)) return false;
                current = current.GetChild(ch);
            }
            return current.IsWordEnd;
        }

        public bool StartsWith(string prefix)
        {
            if (string.IsNullOrWhiteSpace(prefix)) return false;
            var current = _root;
            foreach (var ch in prefix)
            {
                if (!current.HasChild(ch)) return false;
                current = current.GetChild(ch);
            }

            return true;
        }

        public void Remove(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return;
            Remove(_root, word, 0);
        }

        private void Remove(Node root, string word, int index)
        {
            if (index == word.Length)
            {
                root.IsWordEnd = false;
                return;
            }
            var ch = word[index];
            var child = root.GetChild(ch);

            if (child == null) return;

            Remove(root, word, index + 1);
            if (!root.HasChildren() && !root.IsWordEnd)
            {
                root.RemoveChild(ch);
            }

        }
    }

}