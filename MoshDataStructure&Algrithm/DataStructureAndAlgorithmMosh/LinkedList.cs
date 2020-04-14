namespace LinkedListDemo {

    public class LinkedList {
        private Node Head;
        private Node Tail;

        public void AddFirst (int item) {

        }

        public void AddLast (int item) {
            var node = new Node (item);
            // this node is the first element in the linked list
            if (this.Head == null) {
                this.Head = node;
                this.Tail = node;
            } else {
                this.Tail.Next = node;
                this.Tail = node;
            }
        }

        public int DeleteFirst () {

            return 0;
        }

        public int DeleteLast () {
            return 0;
        }

        public bool Contains (int item) {
            return false;
        }

        public int IndexOf (int item) {
            return -1;
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