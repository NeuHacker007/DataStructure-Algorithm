using System;

namespace TrieDemo {
    public class Trie {
        public static readonly int ALPHABET_SIZE = 26;
        private class Node {
            public char Value;
            public Node[] Children = new Node[ALPHABET_SIZE];

            public bool IsEndOfWord;

            public Node (char value) {
                this.Value = value;
            }

            public override string ToString () {
                return "Value=" + Value;
            }

        }

        private Node _root = new Node (' ');

        public void Insert (string word) {
            var current = _root;

            foreach (var ch in word) {
                var index = ch - 'a';
                if (current.Children[index] == null) {
                    current.Children[index] = new Node (ch);
                }
                current = current.Children[index];
            }

            current.IsEndOfWord = true;

        }

    }
}