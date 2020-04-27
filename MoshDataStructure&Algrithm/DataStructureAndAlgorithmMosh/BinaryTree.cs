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
            if (IsLeaf (root)) return 0;
            // post-order traversal
            return 1 + Math.Max (Height (root.Left), Height (root.Right));
        }

        public int FindMinValue () {
            return FindMinValue (Root);
        }

        private int FindMinValue (Node root) {
            if (root == null) return int.MaxValue;
            var res = root.value;
            // post-order traversal
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

        public void LevelOrderTraversal () {
            for (int i = 0; i < Height (); i++) {
                var list = GetNodesAtKDistance (i);
                foreach (var item in list) {
                    System.Console.WriteLine (item);
                }
            }
        }

        public int GetSize () {
            return GetSize (Root);
        }

        private int GetSize (Node root) {
            if (root == null) return 0;
            if (IsLeaf (root)) return 1;

            return 1 + GetSize (root.Left) + GetSize (root.Right);
        }

        public int CountLeafs () {
            return CountLeafs (Root);
        }

        private int CountLeafs (Node root) {
            if (root == null) return 0;
            if (IsLeaf (root)) return 1;

            return CountLeafs (root.Left) + CountLeafs (root.Right);
        }

        public int Max () {
            return Max (Root);
        }

        private int Max (Node root) {
            if (root == null) return int.MinValue;
            var res = root.value;
            var maxLeft = Max (root.Left);
            var maxRight = Max (root.Right);

            if (res < maxLeft) {
                res = maxLeft;
            }
            if (res < maxRight) {
                res = maxRight;
            }
            return res;
        }

        public int MaxInBinaryTree () {
            return MaxInBinaryTree (Root);
        }

        private int MaxInBinaryTree (Node root) {
            if (root.Right == null) return root.value;

            return MaxInBinaryTree (root.Right);
        }

        public bool Contains (int value) {
            return Contains (Root, value);
        }

        private bool Contains (Node root, int value) {
            if (root == null) return false;
            if (root.value == value) return true;

            return Contains (root.Left, value) || Contains (root.Right, value);
        }

        public bool IsSibling (int first, int second) {
            return IsSibling (Root, first, second);
        }

        private bool IsSibling (Node root, int first, int second) {
            if (root == null) return false;
            var areSibling = false;
            if (IsLeaf (root)) {
                areSibling = (root.Left.value == first && root.Right.value == second) ||
                    (root.Right.value == first && root.Left.value == second);
            }
            return areSibling || IsSibling (root.Left, first, second) || IsSibling (root.Right, first, second);
        }

        public List<int> GetAncestors (int value) {
            List<int> list = new List<int> ();
            GetAncestors (Root, value, list);
            return list;
        }

        private bool GetAncestors (Node root, int value, List<int> list) {
            if (root == null) return false;
            if (root.value == value) return true;

            if (
                GetAncestors (root.Left, value, list) ||
                GetAncestors (root.Right, value, list)
            ) {
                list.Add (root.value);
                return true;
            }
            return false;
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