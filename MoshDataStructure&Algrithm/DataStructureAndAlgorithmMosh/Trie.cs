using System;
using System.Collections.Generic;

namespace TrieDemo {
    public enum TraverseOrder {
        PreOrder,
        PostOrder
    }
    public class Trie {
        private class Node {
            public char Value;
            public Dictionary<char, Node> Children = new Dictionary<char, Node> ();
            public bool IsEndOfWord;

            public Node (char value) {
                this.Value = value;
            }
            public bool HasChild (char ch) {
                return Children.ContainsKey (ch);
            }

            public void AddChild (char ch) {
                Children.Add (ch, new Node (ch));
            }

            public Node GetChild (char ch) {
                return Children[ch];
            }
            public Node[] GetChildren () {

                var result = new List<Node> (Children.Values);
                return result.ToArray ();
            }

            public bool HasChildren () {
                return Children.Count != 0;
            }
            public void RemoveChild (char ch) {
                Children.Remove (ch);
            }
            public override string ToString () {
                return "Value=" + Value;
            }

        }

        private Node _root = new Node (' ');

        public void Insert (string word) {
            var current = _root;

            foreach (var ch in word) {
                if (!current.HasChild (ch)) {
                    current.AddChild (ch);
                }
                current = current.GetChild (ch);
            }

            current.IsEndOfWord = true;

        }

        public bool Contains (string word) {

            if (string.IsNullOrWhiteSpace (word)) return false;

            var current = _root;

            foreach (var ch in word) {
                if (!current.HasChild (ch)) {
                    return false;
                } else {
                    current = current.GetChild (ch);
                }
            }
            return current.IsEndOfWord;
        }

        public bool ContainsRecursive (string word) {
            return ContainsRecursive (_root, word, 0);
        }

        private bool ContainsRecursive (Node root, string word, int index) {

            if (index == word.Length) return root.IsEndOfWord;

            if (root == null) return false;

            var ch = word[index];
            var child = root.GetChild (ch);

            if (child == null) return false;

            return ContainsRecursive (child, word, index + 1); 
        }
        public void Traverse (TraverseOrder order = TraverseOrder.PreOrder) {

            switch (order) {
                case TraverseOrder.PreOrder:
                    PreTraverse (_root);
                    break;
                case TraverseOrder.PostOrder:
                    PostTraverse (_root);
                    break;

            }

        }

        private void PreTraverse (Node root) {
            // PreOrder
            System.Console.WriteLine (root.Value);

            foreach (var child in root.GetChildren ()) {
                PreTraverse (child);
            }
        }
        private void PostTraverse (Node root) {
            // Post Order
            foreach (var child in root.GetChildren ()) {
                PostTraverse (child);
            }

            System.Console.WriteLine (root.Value);
        }

        public void RemoveWord (string word) {
            if (word == null) return;

            RemoveWord (_root, word, 0);
        }

        private void RemoveWord (Node root, string word, int index) {
            if (index < 0 || index > word.Length) throw new ArgumentOutOfRangeException ("Index is out of range");
            // if index == word.Length, this is the last charactor, we need set isendofword = false;
            if (index == word.Length) {
                root.IsEndOfWord = false;
                return;
            }
            // get the ch of the index in the word 
            var ch = word[index];
            var child = root.GetChild (ch);

            if (child == null) return;

            RemoveWord (child, word, index + 1);
            // remove the node physically 

            if (!child.HasChildren () && !child.IsEndOfWord) {
                root.RemoveChild (ch);
            }

        }

        public List<string> FindWords (string prefix) {
            var lastNode = FindLastNodeOf (prefix);
            var words = new List<string> ();
            FindWords (lastNode, prefix, words);

            return words;
        }

        private void FindWords (Node root, string prefix, List<string> words) {
            if (root == null) return;
            if (root.IsEndOfWord) {
                words.Add (prefix);
            }

            foreach (var child in root.GetChildren ()) {
                FindWords (child, prefix + child.Value, words);
            }
        }

        private Node FindLastNodeOf (string prefix) {
            if (prefix == null) return null;
            var current = _root;

            foreach (var ch in prefix) {
                var child = current.GetChild (ch);
                if (child == null) {
                    return null;
                }
                current = child;
            }
            return current;
        }
    }
}