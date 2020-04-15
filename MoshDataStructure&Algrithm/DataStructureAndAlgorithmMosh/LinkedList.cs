using System;
namespace LinkedListDemo {

    public class LinkedList {
        private Node Head;
        private Node Tail;

        public void AddFirst (int item) {
            var node = new Node (item);
            if (this.isEmpty ()) {
                this.Head = this.Tail = node;
            } else {
                node.Next = this.Head;
                this.Head = node;
            }

        }

        public void AddLast (int item) {
            var node = new Node (item);
            // this node is the first element in the linked list
            if (this.isEmpty ()) {
                this.Head = node;
                this.Tail = node;
            } else {
                this.Tail.Next = node;
                this.Tail = node;
            }
        }

        public int DeleteFirst () {
            Node result = this.Head;
            if (this.Head == this.Tail) {
                this.Head = this.Tail = null;
                return result.Data;
            }
            if (!this.isEmpty ()) {
                this.Head = this.Head.Next;
                result.Next = null;
            } else {
                throw new Exception ("List is empty");
            }

            return result.Data;
        }

        public int DeleteLast () {
            Node result = this.Tail;

            if (isEmpty ()) {
                throw new Exception ("List is empty");
            }
            // processing the only one item in the list
            if (this.Head == this.Tail) {
                this.Head = this.Tail = null;
            }

            var current = this.Head;
            while (current != null) {
                if (current.Next == this.Tail) {
                    break;
                } else {
                    current = current.Next;
                }
            }
            // shorten the list
            this.Tail = current;
            // remove the reference in order GC can collect it.
            current.Next = null;

            return result.Data;
        }

        public bool Contains (int item) {
            // var current = this.Head;
            // while (current != null) {
            //     if (current.Data == item) {
            //         return true;
            //     } else {
            //         current = current.Next;
            //     }
            // }
            // return false;
            return this.IndexOf (item) != -1;
        }

        public int IndexOf (int item) {
            int index = 0;
            var current = this.Head;
            while (current != null) {
                if (current.Data == item) {
                    return index;
                } else {
                    current = current.Next;
                    index++;
                }
            }
            return -1;
        }

        private bool isEmpty () {
            return this.Head == null;
        }

        private class Node {
            public int Data;
            public Node Next;

            public Node (int Data) {
                this.Data = Data;
            }
        }
    }

}