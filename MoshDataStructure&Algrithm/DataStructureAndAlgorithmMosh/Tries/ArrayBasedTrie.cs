using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DataStructureAndAlgorithmMosh.Tries
{
    public class ArrayBasedTrie
    {
        private static readonly int ALPHABET_SIZE = 26;
        private class Node
        {
            private char _value;
            public Node[] children = new Node[ALPHABET_SIZE];
            public bool isWordEnd = false;
            public Node(char value)
            {
                _value = value;
            }
        }

        private Node _root = new Node(' ');

        public void Insert(string word)
        {
            var current = _root;

            foreach (var ch in word)
            {
                var index = ch - 'a';
                if (current.children[index] == null)
                {
                    current.children[index] = new Node(ch);
                }

                current = current.children[index];
            }

            current.isWordEnd = true;
        }
    }
}
