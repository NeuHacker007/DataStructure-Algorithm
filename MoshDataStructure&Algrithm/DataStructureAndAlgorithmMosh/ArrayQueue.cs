using System;
using System.Text;

namespace QueueDemo {
    public class ArrayQueue {
        private int[] items;
        private int front;
        private int rear;

        public ArrayQueue (int capacity) {
            if (capacity <= 0) throw new ArgumentOutOfRangeException ("Invalid Capacity");

            items = new int[capacity];
            front = 0;
            rear = 0;
        }

        public void Enqueue (int item) {
            if (IsFull ()) throw new Exception ("Queue is full");
            items[rear++] = item;
        }

        public int Dequeue () {
            if (IsEmpty ()) throw new Exception ("Queue is Empty");
            return items[front++];
        }

        public bool IsFull () {
            return rear == items.Length;
        }

        public bool IsEmpty () {
            return rear == 0;
        }

        public override string ToString () {
            StringBuilder sb = new StringBuilder ();
            sb.Append ("[");
            for (int i = 0; i < rear; i++) {
                sb.Append ($"{items[i]} ");
            }
            sb.Append ("]");
            return sb.ToString ();
        }
    }
}