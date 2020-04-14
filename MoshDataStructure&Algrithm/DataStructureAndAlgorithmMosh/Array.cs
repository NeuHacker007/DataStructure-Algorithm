using System;

namespace ArrayDemo {
    public class Array : IArray {
        private int[] Data;
        private int Size;
        public Array (int capacity) {
            Data = new int[capacity];
            this.Size = 0;
        }
        public int indexOf (int num) {
            int result = -1;
            // O(n)
            for (int i = 0; i < Data.Length; i++) {
                if (this.Data[i] == num) {
                    result = i;
                }
            }

            return result;
        }

        public void insert (int num) {
            if (this.Size == this.Data.Length) {
                this.resize (this.Data.Length * 2);
            }
            Data[this.Size] = num;
            this.Size++;

        }

        public void removeAt (int index) {
            if (index < 0 || index >= this.Size) {
                throw new ArgumentException ("Index is no valid");
            }
            // here I prefer to use this.Size -1 to keep the i + 1 not beyond the scope of the array
            // actually if we don't use this.Size -1 it is also ok since. this.Size can never reach 
            // the length of the data array. 
            for (int i = index; i < this.Size - 1; i++) {
                this.Data[i] = this.Data[i + 1];
            }
            this.Size--;
        }

        public override string ToString () {
            string result = "[";
            for (int i = 0; i < this.Size; i++) {
                result += $" {this.Data[i]}";
            }
            result += "]";
            return result;
        }
        private void resize (int newCapacity) {
            int[] newArray = new int[newCapacity];

            for (int i = 0; i < this.Size; i++) {
                newArray[i] = this.Data[i];
            }

            this.Data = newArray;
        }
    }
}