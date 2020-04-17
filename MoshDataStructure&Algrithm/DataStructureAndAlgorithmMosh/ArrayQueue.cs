using System;
using System.Text;

namespace QueueDemo {
    public class ArrayQueue {
        private int[] items;
        private int front;
        private int rear;
        private int count;

        public ArrayQueue (int capacity) {
            if (capacity <= 0) throw new ArgumentOutOfRangeException ("Invalid Capacity");

            items = new int[capacity];
            front = 0;
            rear = 0;
            count = 0;
        }

        public void Enqueue (int item) {
            if (IsFull ()) throw new Exception ("Queue is full");
            items[rear++] = item;
            count++;
        }

        public int Dequeue () {
            if (IsEmpty ()) throw new Exception ("Queue is Empty");
            int result = items[front];
            items[front++] = 0;
            count--;
            return result;
        }

        public bool IsFull () {
            return count == items.Length;
        }

        public bool IsEmpty () {
            return count == 0;
        }

        public override string ToString () {
            StringBuilder sb = new StringBuilder ();
            sb.Append ("[");
            for (int i = 0; i < items.Length; i++) {
                sb.Append ($"{items[i]} ");
            }
            sb.Append ("]");
            return sb.ToString ();
        }
    }

    public class ArrayCircularQueue {
        private int[] items;
        private int front;
        private int rear;
        private int count;

        public ArrayCircularQueue (int capacity) {
            if (capacity <= 0) throw new ArgumentOutOfRangeException ("Invalid Capacity");

            items = new int[capacity];
            front = 0;
            rear = 0;
            count = 0;
        }

        public void Enqueue (int item) {
            if (IsFull ()) throw new Exception ("Queue is full");
            items[rear] = item;
            rear = (rear + 1) % items.Length;
            count++;
        }

        public int Dequeue () {
            if (IsEmpty ()) throw new Exception ("Queue is Empty");
            int result = items[front];
            items[front] = 0;
            front = (front + 1) % items.Length;
            count--;
            return result;
        }

        public bool IsFull () {
            return count == items.Length;
        }

        public bool IsEmpty () {
            return count == 0;
        }

        public override string ToString () {
            StringBuilder sb = new StringBuilder ();
            sb.Append ("[");
            for (int i = 0; i < items.Length; i++) {
                sb.Append ($"{items[i]} ");
            }
            sb.Append ("]");
            return sb.ToString ();
        }
    }
}
