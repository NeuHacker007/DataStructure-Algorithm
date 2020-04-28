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
            Balance (root);
            return root;
        }
        private void Balance (Node root) {
            if (IsLeftHeavy (root)) {
                if (GetBalanceFactor (root.Left) < 0) {
                    System.Console.WriteLine ($"Left Rotation - {root.Left.Value}");
                }
                System.Console.WriteLine ($"Right Rotation - {root.Value}");
            } else if (IsRighHeavy (root)) {
                if (GetBalanceFactor (root.Right) > 0) {
                    System.Console.WriteLine ($"Right Rotation - {root.Right.Value}");
                }
                System.Console.WriteLine ($"Left Rotation - {root.Value}");
            }
        }
        private bool IsLeftHeavy (Node root) {
            return GetBalanceFactor (root) > 1;
        }

        private bool IsRighHeavy (Node root) {
            return GetBalanceFactor (root) < -1;
        }

        private int GetBalanceFactor (Node root) {
            return (root == null) ? 0 : GetHeight (root.Left) - GetHeight (root.Right);
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