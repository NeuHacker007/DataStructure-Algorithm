using System;
using System.Text;
namespace HeapDemo {

    public class MinHeap {
        private class Node {
            public int Key;
            public string Value;

            public Node (int key, string value) {
                this.Key = key;
                this.Value = value;
            }
        }

        private Node[] Data;
        private int Size;

        public MinHeap (int capacity) {
            Data = new Node[capacity];
            Size = 0;
        }

        public void Insert (int key, string value) {
            if (IsFull ()) throw new Exception ("Data Array is Full");
            var newNode = new Node (key, value);

            Data[Size++] = newNode;

            BubbleUp ();

        }

        public void Remove () {
            if (IsEmpty ()) throw new Exception ("Data Array is empty");

            Data[0] = GetLastElement ();
            //Data[Data.Length - 1] = null;
            Size--;

            BubbleDown ();

        }

        public bool IsFull () {
            return Size == Data.Length;
        }

        public bool IsEmpty () {
            return Size == 0;
        }

        private void BubbleDown () {
            var index = 0;

            while (index <= Size && !IsParentValid (index)) {
                var smallerIndex = GetSmallerChildIndex (index);
                Swap (index, smallerIndex);
                index = smallerIndex;
            }

        }

        private void BubbleUp () {

            var index = Size - 1;

            while (index > 0 && GetCurrentNodeKey (index) <= GetParentNodeKey (index)) {

                Swap (index, GetParentIndex (index));
                index = GetParentIndex (index);
            }

        }

        private bool IsParentValid (int index) {
            if (!HasLeftChild (index)) return true;
            if (!HasRightChild (index)) return GetCurrentNodeKey (index) <= GetLeftChildKey (index);

            return GetCurrentNodeKey (index) <= GetLeftChildKey (index) && GetCurrentNodeKey (index) <= GetRightChildKey (index);
        }

        private int GetSmallerChildIndex (int index) {
            if (!HasLeftChild (index)) return index;
            if (!HasRightChild (index)) return GetCurrentNodeKey (index) <= GetLeftChildKey (index) ? index : GetLeftChildIndex (index);

            return GetLeftChildKey (index) <= GetRightChildKey (index) ? GetLeftChildIndex (index) : GetRighChildIndex (index);
        }

        private bool HasLeftChild (int index) {
            return GetLeftChildIndex (index) <= Size;
        }

        private bool HasRightChild (int index) {
            return GetRighChildIndex (index) <= Size;
        }

        private Node GetLastElement () {
            return Data[Data.Length - 1];
        }

        private int GetCurrentNodeKey (int index) {
            return Data[index].Key;
        }

        private int GetParentNodeKey (int index) {
            return Data[GetParentIndex (index)].Key;
        }

        private int GetLeftChildKey (int index) {
            return Data[GetLeftChildIndex (index)].Key;
        }

        private int GetRightChildKey (int index) {
            return Data[GetRighChildIndex (index)].Key;
        }

        private int GetLeftChildIndex (int index) {
            return 2 * index + 1;
        }

        private int GetRighChildIndex (int index) {
            return 2 * index + 2;
        }

        private int GetParentIndex (int index) {
            return (index - 1) / 2;
        }

        private void Swap (int first, int second) {
            var temp = Data[first];
            Data[first] = Data[second];
            Data[second] = temp;
        }

        public override string ToString () {
            StringBuilder sb = new StringBuilder ();
            sb.Append ("Min [ ");
            for (int i = 0; i < Size; i++) {
                sb.Append ($"[key={Data[i].Key}, value={Data[i].Value}],");
            }

            sb.Append ("]");
            return sb.ToString ();
        }

    }

}