using System;
namespace AVLTreeExcercise {
    public class Tree {

        private Node Root;

        public void Insert (int value) {
            Root = Insert (Root, value);
        }

        private Node Insert (Node root, int value) {
            if (root == null) {
                return new Node (value);
            }

            if (value < root.Value) {
                root.Left = Insert (root.Left, value);
            } else if (value > root.Value) {
                root.Right = Insert (root.Right, value);
            }
            SetHeight (root);
            return root;
        }

        public bool IsBalanced (Tree tree) {
            return IsBalanced (tree.Root);
        }

        private bool IsBalanced (Node root) {
            if (root == null) return true;

            if (IsLeftHeavy (root) || IsRightHeavy (root)) {
                return false;
            }

            return IsBalanced (root.Left) && IsBalanced (root.Right);

        }

        private bool IsLeftHeavy (Node root) {
            return GetBalanceFactor (root) > 1;
        }

        private bool IsRightHeavy (Node root) {
            return GetBalanceFactor (root) < -1;
        }

        private int GetBalanceFactor (Node root) {
            return GetHeight (root.Left) - GetHeight (root.Right);
        }

        private int GetHeight (Node root) {
            return (root == null) ? -1 : root.Height;
        }

        private void SetHeight (Node root) {
            root.Height = Math.Max (GetHeight (root.Left), GetHeight (root.Right)) + 1;
        }

        // TODO: Tree is perfect

        private class Node {
            public int Value;
            public int Height;
            public Node Left;
            public Node Right;

            public Node (int value) {
                this.Value = value;
            }

            public override string ToString () {
                return $"Node={Value}";
            }
        }
    }
}