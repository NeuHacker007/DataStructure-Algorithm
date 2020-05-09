using System;
namespace HeapDemo {
    public class Heap {
        private int[] data;
        private int Size;

        public Heap (int capacity) {
            data = new int[capacity];
        }

        // parent = leftindex + rightindex
        public void Insert (int item) {
            if (IsFull () ) throw new Exception ("Array is Full");
            data[Size++] = item;
            BubuleUp ();
        }

        public void Remove () {

        }
        public bool IsFull () {
            return Size == data.Length;
        }
        private void BubuleUp () {

            var index = Size - 1;
            while (index > 0 && data[index] > data[Parent (index)]) {
                Swap (index, Parent (index));
                index = Parent (index);
            }
        }
        private int Parent (int index) {
            return (index - 1) / 2;
        }

        private void Swap (int first, int second) {
            var temp = data[first];
            data[first] = data[second];
            data[second] = temp;
        }
    }
}