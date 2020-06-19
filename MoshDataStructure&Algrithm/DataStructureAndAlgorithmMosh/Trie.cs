using System;
using System.Collections.Generic;

namespace TrieDemo {
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

            public Node GetChild(char ch) {
                return Children[ch];
            }

            public override string ToString () {
                return "Value=" + Value;
            }

        }

        private Node _root = new Node (' ');

        public void Insert (string word) {
            var current = _root;

            foreach (var ch in word) {
                if (!current.HasChild(ch)) {
                    current.AddChild(ch);
                }
                current = current.GetChild(ch);
            }

            current.IsEndOfWord = true;

        }

    }
}