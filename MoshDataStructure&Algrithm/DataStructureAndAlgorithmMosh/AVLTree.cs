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

            SetHeight (root);

            return Balance (root);

        }
        private Node Balance (Node root) {
            if (IsLeftHeavy (root)) {
                if (GetBalanceFactor (root.Left) < 0) {
                    System.Console.WriteLine ($"Left Rotation - {root.Left.Value}");
                    root.Left = RotateLeft (root.Left);
                }
                System.Console.WriteLine ($"Right Rotation - {root.Value}");
                return RotateRight (root);
            } else if (IsRighHeavy (root)) {
                if (GetBalanceFactor (root.Right) > 0) {
                    System.Console.WriteLine ($"Right Rotation - {root.Right.Value}");
                    root.Right = RotateRight (root.Right);
                }
                System.Console.WriteLine ($"Left Rotation - {root.Value}");
                return RotateLeft (root);
            }

            return root;
        }
        // Left Rotation logic
        // 10 (old root)  -> heavy node       ---------------------->                10 (old root)      ----> heavy node
        //   20 (new root)                                                              20 (new root)
        //     30                                                                    15  30
        // newNode = root.Right                                                       newNode = root.right;
        // newNode.left = root                                                        root.right = newNode.left
        // recalculate the height                                                     newNode.left = root;
        //                                                                            recalculate the height
        private Node RotateLeft (Node root) {
            // doing the rotation
            var newRoot = root.Right;
            root.Right = newRoot.Left;
            newRoot.Left = root;

            SetHeight (root);
            SetHeight (newRoot);

            return newRoot;
        }

        private Node RotateRight (Node root) {
            var newRoot = root.Left;
            root.Left = newRoot.Right;
            newRoot.Right = root;

            SetHeight (root);
            SetHeight (newRoot);

            return newRoot;
        }

        private void SetHeight (Node root) {
            root.Height = Math.Max (GetHeight (root.Left), GetHeight (root.Right)) + 1;
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