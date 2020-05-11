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
            if (IsFull ()) throw new Exception ("Array is Full");
            data[Size++] = item;
            BubuleUp ();
        }

        public void Remove () {
            if (IsEmpty ()) throw new Exception ("Heap is Empty");

            data[0] = data[--Size];

            // if current root < its children we should bubuledown

        }
        public bool IsFull () {
            return Size == data.Length;
        }

        public bool IsEmpty () {
            return Size == 0;
        }
        private void BububleDown () {

            int index = 0;
            while (index <= Size && !IsParentValid (index)) {
                var largerChildIndex = GetLagerChildIndex (index);

                Swap (index, largerChildIndex);

                index = largerChildIndex;
            }
        }
        private int GetLagerChildIndex (int index) {
            // if no left child which means no children because we fill the tree from left to right
            if (!HasLeftChild (index)) {
                return index;
            }

            if (!HasRightChild (index)) {
                return GetLeftChildIndex (index);
            }

            return GetLeftChildValue (index) > GetRightChildValue (index) ?
                GetLeftChildIndex (index) :
                GetRightChildIndex (index);
        }

        private bool HasLeftChild (int index) {
            return GetLeftChildIndex (index) <= Size;
        }

        private bool HasRightChild (int index) {
            return GetRightChildIndex (index) <= Size;
        }

        private bool IsParentValid (int index) {
            if (!HasLeftChild (index)) {
                return true;
            }

            if (!HasRightChild (index)) {
                return data[index] >= GetLeftChildValue (index);
            }

            return data[index] >= GetLeftChildValue (index) &&
                data[index] >= GetRightChildValue (index);
        }

        private int GetLeftChildValue (int index) {
            return data[GetLeftChildIndex (index)];
        }

        private int GetRightChildValue (int index) {
            return data[GetRightChildIndex (index)];
        }

        //                          20 i= 0
        //      i=1     15                      17 i=2
        //      i=3   7   8 i=4         i=5 3        4  i= 6
        // if root is 15, index =1, then left child(7)'s index 2*1 + 1 = 3
        // if root is 15, index =1, then right child(8)'s index 2*1 + 2 = 4

        private int GetLeftChildIndex (int index) {
            return 2 * index + 1;
        }

        private int GetRightChildIndex (int index) {
            return 2 * index + 2;
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