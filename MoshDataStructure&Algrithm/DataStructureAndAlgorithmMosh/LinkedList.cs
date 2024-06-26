using System;
namespace LinkedListDemo {

    public class LinkedList {
        private Node Head;
        private Node Tail;

        private int Size = 0;

        public void AddFirst (int item) {
            var node = new Node (item);
            if (this.IsEmpty ()) {
                this.Head = this.Tail = node;
            } else {
                node.Next = this.Head;
                this.Head = node;
            }

            this.Size++;

        }

        public void AddLast (int item) {
            var node = new Node (item);
            // this node is the first element in the linked list
            if (this.IsEmpty ()) {
                this.Head = node;
                this.Tail = node;
            } else {
                this.Tail.Next = node;
                this.Tail = node;
            }
            this.Size++;

        }

        public int DeleteFirst () {
            Node result = this.Head;
            if (this.Head == this.Tail) {
                this.Head = this.Tail = null;
                this.Size--;
                return result.Data;
            }
            if (!this.IsEmpty ()) {
                this.Head = this.Head.Next;
                result.Next = null;
                this.Size--;
            } else {
                throw new Exception ("List is empty");
            }

            return result.Data;
        }

        public int DeleteLast () {
            Node result = this.Tail;

            if (IsEmpty ()) {
                throw new Exception ("List is empty");
            }
            // processing the only one item in the list
            if (this.Head == this.Tail) {
                this.Head = this.Tail = null;
            }

            // shorten the list
            this.Tail = this.getPreviousNode (this.Tail);
            // remove the reference in order GC can collect it.
            this.Tail.Next = null;
            this.Size--;
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

        public int getSize () {
            return this.Size;
        }

        public int[] ToArray () {
            int[] result = new int[this.Size];
            int index = 0;
            var current = this.Head;
            while (current != null) {
                result[index++] = current.Data;
                current = current.Next;
            }

            return result;
        }

        public void Reverse () {
            if (IsEmpty ()) return;
            // var current = this.Head;
            // while (current != null) {
            //     var next = current.Next;
            //     next.Next = current;
            //     current = current.Next;
            // }
            var previous = this.Head;
            var current = this.Head.Next;
            while (current != null) {
                var next = current.Next;
                // [10 -> 20]
                //  p      c    n
                // [10 <- 20]
                //        p    c  n
                current.Next = previous;
                previous = current;
                // keep the loop work
                current = next;
            }
            this.Tail = this.Head;
            this.Tail.Next = null;
            this.Head = previous;
        }

        public int getKthNodeFromEnd (int k) {
            //         5     4    3      2     1
            //       [10 -> 20 -> 30 -> 40 -> 50]
            // K = 0                              out return
            // K = 1                          out
            // K = 2                    out
            // K = 3              out
            // ...
            // K = 5  out
            // K = 6  return

            // here if K < 1 judgement is not necessary it might be over defensive since without this 
            // even we input k =0, k = -1, program will return the first element in the list when counting from end
            if (k < 1 || k > this.Size) {
                throw new Exception ("Invalid K number. out of range");
            }
            if (IsEmpty ()) throw new Exception ("List is empty");

            // var first = this.Head;
            // var second = this.Head;
            // int index = 0;
            // while (second != null) {
            //     if (index == k) {
            //         first = first.Next;                    Wrong Implementation
            //     } else {
            //         index++;
            //     }
            //     second = second.Next;

            // }

            var first = this.Head;
            var second = this.Head;
            // First find the right distance between first and second pointer
            for (int i = 0; i < k - 1; i++) {
                second = second.Next;
                // An alternative way of checking given K is larger then the size 
                // if (b == null) throw new Exception ("Invalid K number. out of range");
            }
            // when distance is determined, then loop both pointer
            // untile the second one reaches the end
            while (second != this.Tail) {
                first = first.Next;
                second = second.Next;
            }

            return first.Data;
        }

        /*
         * Find the middle of a linked list in one pass. if the list has an even number of nodes, there would 
         * be two middlenodes (Assume that you don't know the size of the list ahead of time)
         */
        public int[] FintItemsInMiddle () {
            int[] result = new int[2];

            // [10 -> 20 -> 30 -> 40 -> 50]                    [10 -> 20 -> 30 -> 40 -> 50 -> 60]
            //  fs                                              fs
            //        f     s                                         f            s
            //              f           s                                    f    f.next      s
            //            middle                                          middle middle
            var first = this.Head;
            var second = this.Head;

            while (second != this.Tail && second.Next != this.Tail) {
                first = first.Next;
                second = second.Next.Next;
            }

            if (second == this.Tail) {
                result[0] = first.Data;
            } else {
                result[0] = first.Data;
                result[1] = first.Next.Data;
            }

            return result;
        }

        public bool FindLoop () {

            var fast = this.Head;
            var slow = this.Head;

            while (fast != null && fast.Next != null) {
                if (fast == slow) {
                    return true;
                }
                fast = fast.Next.Next;
                slow = slow.Next;
            }

            return false;
        }

        private bool IsEmpty () {
            return this.Head == null;
        }

        private Node getPreviousNode (Node item) {
            var current = this.Head;
            while (current != null) {
                if (current.Next == this.Tail) {
                    return current;
                } else {
                    current = current.Next;
                }
            }
            return null;
        }

        public class Node {
            public int Data;
            public Node Next;

            public Node (int Data) {
                this.Data = Data;
            }
        }
    }

}