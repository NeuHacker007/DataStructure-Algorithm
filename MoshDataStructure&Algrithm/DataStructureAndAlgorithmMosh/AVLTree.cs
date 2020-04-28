using System;
using System.Collections.Generic;
namespace AVLTreeDemo {
    public class AVLTree {
        private Node Root;

        public void Insert (int value) {
            var newNode = new Node (value);
            if (Root == null) {
                Root = newNode;
                return;
            }
            var current = Root;

            while (true) {
                if (current.Value < value) {
                    if (current.Right == null) {
                        current.Right = newNode;
                        break;
                    }
                    current = current.Right;
                } else if (current.Value > value) {
                    if (current.Left == null) {
                        current.Left = newNode;
                        break;
                    }

                    current = current.Left;
                }
            }

        }

        public void InsertRecursion (int value) {
            Root = InsertRecursion (Root, value);
        }

        private Node InsertRecursion (Node root, int value) {
            if (root == null) {
                return new Node (value);
            }
            if (root.Value < value) {
                root.Right = InsertRecursion (root.Right, value);
            } else if (root.Value > value) {
                root.Left = InsertRecursion (root.Left, value);
            }
            root.Height = Math.Max (GetHeight (root.Left), GetHeight (root.Right)) + 1;
            var balanceFactor = GetHeight (root.Left) - GetHeight (root.Right);
            if (balanceFactor > 1) {
                System.Console.WriteLine ($"{root.Value} is heavy");
            } else if (balanceFactor < -1) {
                System.Console.WriteLine ($"{root.Value} is heavy");
            }
            return root;
        }

        private int GetHeight (Node root) {
            return (root == null) ? -1 : root.Height;
        }

        private class Node {
            public int Value;
            public Node Left;
            public Node Right;

            public int Height;

            public Node (int value) {
                this.Value = value;
            }

            public override string ToString () {
                return "Node=" + Value;
            }

        }
    }
}