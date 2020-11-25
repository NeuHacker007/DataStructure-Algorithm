using System;

namespace ArrayDemo {
    public class Array : IArray {
        private int[] Data;
        private int Size;
        public Array (int capacity) {
            Data = new int[capacity];
            this.Size = 0;
        }

        public int IndexOf (int num) {
            int result = -1;
            // O(n)
            for (int i = 0; i < Data.Length; i++) {
                if (this.Data[i] == num) {
                    result = i;
                }
            }

            return result;
        }

        public void Insert (int num) {
            if (this.Size == this.Data.Length) {
                this.resize (this.Data.Length * 2);
            }
            Data[this.Size] = num;
            this.Size++;

        }

        public void InsertAt (int index, int num) {
            if (index < 0 || index > this.Size) {
                throw new ArgumentException ("Insert Failed! Index is not valid");
            }
            if (this.Size == this.Data.Length) {
                this.resize (this.Data.Length * 2);
            }
            // right shift
            for (int i = this.Size - 1; i >= index; i--) {
                this.Data[i + 1] = this.Data[i];
            }
            this.Data[index] = num;
            this.Size++;
        }

        public Array Intersect (Array anotherArray) {
            // the max common is the size of smaller one. 
            // here we use this.Size to initialize the result array
            // 1. this.Data.Size > anotherArray.Length
            //    -> the max common size is anotherArray.Length, so we use this.Data.Length
            //       will not leads to the index outbound exception
            // 2. this.Data.Size < anotherArray.Length
            //    -> the max common size is this.Data.Size, 
            Array intersection = new Array (this.Size);
            // for (int i = 0; i < this.Size; i++) {
            //     for (int j = 0; j < anotherArray.Length; j++) {
            //         if (this.Data[i] == anotherArray[j]) {
            //             intersection[i] = anotherArray[j];
            //             break;
            //         }
            //     }
            // }
            foreach (int item in this.Data) {
                if (anotherArray.IndexOf (item) >= 0) {
                    intersection.Insert (item);
                }
            }
            return intersection;
        }

        public int Max () {
            int max = 0;
            foreach (var item in this.Data) {
                if (item > max) {
                    max = item;
                }
            }
            return max;
        }

        public void RemoveAt (int index) {
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

        public int[] Reverse () {
            int[] result = new int[this.Size];
            for (int i = 0; i < this.Size; i++) {
                result[i] = this.Data[this.Size - i - 1];
            }
            return result;
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