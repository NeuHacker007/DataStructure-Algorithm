using System;
using System.Collections.Generic;
namespace BinaryTreeDemo {

    public class BinaryTree {

        private Node Root;

        public void Insert (int item) {

            var newNode = new Node (item);

            if (Root == null) {
                Root = newNode;
                return;
            }

            var current = Root;

            /*
                here we keep infinit loop to loop through the tree. 
                Unlike the linked list we use node != null to loop.
                Once we insert sucessfully then we just break out the loop
                otherwise we keep loop
            */

            while (true) {
                if (item == current.value) throw new Exception ("No Duplicate value allowed");
                if (item < current.value) {
                    // if the left leaf node is null, we can directly put the new node here
                    if (current.Left == null) {
                        current.Left = newNode;
                        break;
                    }
                    // this is used to keep search left children in the tree
                    current = current.Left;
                } else if (item > current.value) {
                    // if the right leaf node is null, we can directly put the new node here
                    if (current.Right == null) {
                        current.Right = newNode;
                        break;
                    }
                    // this is used to keep search right children in the tree
                    current = current.Right;
                }
            }
        }

        public bool Find (int item) {
            if (Root == null) return false;
            var current = Root;
            while (true) {
                if (current.value == item) return true;

                if (item < current.value) {
                    if (current.Left == null) break;
                    current = current.Left;
                } else if (item > current.value) {
                    if (current.Right == null) break;
                    current = current.Right;
                }
            }

            return false;
        }

        public bool FindByMosh (int item) {
            var current = Root;

            while (current != null) {
                if (item < current.value) {
                    current = current.Left;
                } else if (item > current.value) {
                    current = current.Right;
                } else {
                    return true;
                }
            }
            return false;
        }
        public void TraversePreOrder () {
            TraversePreOrder (Root);
        }
        private void TraversePreOrder (Node root) {
            if (root == null) return;
            System.Console.WriteLine (root.value);
            TraversePreOrder (root.Left);
            TraversePreOrder (root.Right);
        }

        public void TraverseInOrder () {
            TraverseInOrder (Root);
        }

        private void TraverseInOrder (Node root) {
            if (root == null) return;
            TraverseInOrder (root.Left);
            System.Console.WriteLine (root.value);
            TraverseInOrder (root.Right);
        }

        public void TraversePostOrder () {
            TraversePostOrder (Root);
        }

        private void TraversePostOrder (Node root) {
            if (root == null) return;

            TraversePostOrder (root.Left);
            TraversePostOrder (root.Right);
            System.Console.WriteLine (root.value);
        }

        public int Height () {
            return Height (Root);
        }
        private int Height (Node root) {
            if (root == null) return -1;

            // recursively call this Height until no leaf nodes
            // base case
            if (root.Left == null && root.Right == null) return 0;

            return 1 + Math.Max (Height (root.Left), Height (root.Right));
        }

        public int FindMinValue () {
            return FindMinValue (Root);
        }

        private int FindMinValue (Node root) {
            if (root == null) return int.MaxValue;
            var res = root.value;
            var left = FindMinValue (root.Left);
            var right = FindMinValue (root.Right);
            if (left < res)
                res = left;
            if (right < res)
                res = right;
            return res;
        }

        public int FindMinValueInBinarySearchTree () {
            return FindMinValueInBinarySearchTree (Root);
        }

        private int FindMinValueInBinarySearchTree (Node root) {
            if (root == null) throw new Exception ("Min value cannot be found!");
            var current = root.Left;
            var last = current;
            while (current != null) {
                last = current;
                current = current.Left;
            }
            return last.value;
        }

        public bool Equals (BinaryTree tree) {
            if (tree == null) return false;
            return Equals (Root, tree.Root);
        }

        private bool Equals (Node first, Node second) {
            if (first == null && second == null) return true;

            if (first != null && second != null)
                // pre-order loop
                return first.value == second.value &&
                    Equals (first.Left, second.Left) &&
                    Equals (first.Right, second.Right);

            return false;
        }

        public bool ValidateBinarySearchTree () {
            return ValidateBinarySearchTree (Root, int.MinValue, int.MaxValue);
        }

        private bool ValidateBinarySearchTree (Node root, int min, int max) {

            if (root == null) return true;
            // pre-order loop  
            if (root.value < min || root.value > max) return false;

            return ValidateBinarySearchTree (root.Left, min, root.value - 1) && ValidateBinarySearchTree (root.Right, root.value + 1, max);

        }

        public void PrintNodesAtKDistance (int distance) {
            PrintNodesAtKDistance (Root, distance);
        }

        private void PrintNodesAtKDistance (Node root, int distance) {
            if (root == null) return;
            if (distance == 0) {
                System.Console.WriteLine (root.value);
                return;
            }

            PrintNodesAtKDistance (root.Left, distance - 1);
            PrintNodesAtKDistance (root.Right, distance - 1);
        }

        public List<int> GetNodesAtKDistance (int distance) {
            List<int> list = new List<int> ();
            GetNodesAtKDistance (Root, distance, list);
            return list;
        }

        private void GetNodesAtKDistance (Node root, int distance, List<int> list) {
            if (root == null) return;

            if (distance == 0) {
                list.Add (root.value);

                return;
            }

            GetNodesAtKDistance (root.Left, distance - 1, list);
            GetNodesAtKDistance (root.Right, distance - 1, list);
        }

        private bool IsLeaf (Node node) {
            return node.Left == null && node.Right == null;
        }
        private class Node {
            public int value;
            public Node Left;

            public Node Right;

            public Node (int value) {
                this.value = value;
            }

            public override string ToString () {
                return "Node=" + value;
            }

        }
    }
}