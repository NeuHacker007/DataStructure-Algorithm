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
            if (count == items.Length) throw new Exception ("Queue is Full");
            int i;
            for (i = count - 1; i >= 0; i--) {
                if (items[i] > item) {
                    items[i + 1] = items[i];
                } else {
                    break;
                }
            }
            items[i + 1] = item;
            count++;
        }

        public int Dequeue () {
            if (count == 0) throw new Exception ("Queue is Empty");

            var result = items[count - 1];
            items[--count] = 0;

            return result;
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