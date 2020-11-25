using System;
using System.Text;
namespace QueueDemo {
    public class PriorityQueue {
        private int[] items;
        private int count;

        public PriorityQueue (int Capacity) {
            if (Capacity <= 0) throw new ArgumentOutOfRangeException ();

            items = new int[Capacity];
            count = 0;
        }

        public void Enqueue (int item) {
            if (isFull ()) throw new Exception ("Queue is Full");
            var indexToInsert = ShiftItemsToInsert (item);
            items[indexToInsert] = item;
            count++;
        }

        public int Dequeue () {
            if (isEmpty ()) throw new Exception ("Queue is Empty");

            var result = items[count - 1];
            items[--count] = 0;

            return result;
        }

        private int ShiftItemsToInsert (int item) {
            int i;
            for (i = count - 1; i >= 0; i--) {
                if (items[i] > item) {
                    items[i + 1] = items[i];
                } else {
                    break;
                }
            }

            return i + 1;
        }

        public bool isFull () {
            return count == items.Length;
        }

        public bool isEmpty () {
            return count == 0;
        }

        public override string ToString () {
            StringBuilder sb = new StringBuilder ();
            sb.Append ("[");
            for (int i = 0; i < count; i++) {
                sb.Append ($"{items[i]} ");
            }
            sb.Append ("]");

            return sb.ToString ();
        }
    }
}