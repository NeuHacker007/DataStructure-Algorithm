using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureAndAlgorithmMosh.Tries
{
    public class DictionaryBasedTrie
    {
        private class Node
        {
            private readonly char _value;
            public bool isWordEnd = false;
            public char Value => _value;
            private Dictionary<char, Node> _children = new Dictionary<char, Node>();
            public Node(char value)
            {
                _value = value;
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

            public Node[] GetChildren()
            {
                return _children.Values.ToArray();
            }

            public bool HasChildren()
            {
                return _children.Count != 0;
            }

            public void Remove(char ch)
            {
                _children.Remove(ch);
            }

            public override string ToString()
            {
                return $"Value:{_value}; IsWordEnd:{isWordEnd}";
            }
        }

        private Node _root = new Node(' ');

        public void Add(string word)
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

            current.isWordEnd = true;
        }

        public bool Contains(string word)
        {
            if (word == null)
            {
                return false;
            }
            var current = _root;
            foreach (var ch in word)
            {
                if (!current.HasChild(ch))
                {
                    return false;
                }

                current = current.GetChild(ch);
            }

            return current.isWordEnd;
        }

        public void Traverse()
        {
            var stack = new Stack<Node>();
            stack.Push(_root);
            //TODO: If add two words this solution will not work, need to figure out
            while (stack.Count != 0)
            {
                var item = stack.Pop();

                var children = item.GetChildren();

                foreach (var child in children)
                {
                    stack.Push(child);
                    Console.WriteLine(child.Value);
                }
            }

        }

        public void TraverseRecursive()
        {
            RecursiveHelper(_root);
        }


        private void RecursiveHelper(Node root)
        {
            if (root == null) return;
            //var current = root;
            Console.WriteLine(root.Value);
            foreach (var child in root.GetChildren())
            {
                RecursiveHelper(child);
            }
        }

        public void Remove(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return;
            Remove(_root, word,0);
        }

        private void Remove(Node root, string word, int index)
        {
            if (index == word.Length)
            {
                root.isWordEnd = false;
                return;
            }
            var ch = word[index];
            var child = root.GetChild(ch);

            if (child == null) return;

            Remove(child, word, index + 1);

            if (!root.HasChildren() && !root.isWordEnd)
            {
                root.Remove(ch);
            }
        }
    }
}
