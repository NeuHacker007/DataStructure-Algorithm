using System;
using System.Collections;
using System.Collections.Generic;

namespace StackExcercise {
    public class TwoStacksInOneArray {
        private int[] array;
        private int stack1Count = 0;
        private int stack2Count = 0;
        private int stack2Index;
        public TwoStacksInOneArray (int Capacity) {
            this.array = new int[Capacity];
            this.stack2Index = Capacity - 1;
        }

        public void Push1 (int item) {
            if (this.stack1Count + this.stack2Count > array.Length) {
                throw new Exception ("No enough space");
            }
            array[stack1Count] = item;
            stack1Count++;
        }

        public void Push2 (int item) {
            if (this.stack1Count + this.stack2Count > array.Length) {
                throw new Exception ("No enough space");
            }
            // if(this.stack2Index < 0) throw new Exception("array used up");

            array[this.stack2Index] = item;
            this.stack2Index--;
            this.stack2Count++;
        }

        public int Pop1 () {
            if (isEmpty1 ()) throw new ArgumentOutOfRangeException ();
            return array[--this.stack1Count];
        }

        public int Pop2 () {
            if (isEmpty2 ()) throw new ArgumentOutOfRangeException ();
            this.stack2Count--;
            return array[++this.stack2Index];
        }

        public bool isEmpty1 () {
            return this.stack1Count == 0;
        }
        public bool isEmpty2 () {
            return this.stack2Count == 0;
        }

        public bool isFull1 () {
            return this.stack1Count + this.stack2Count == this.array.Length;
        }
        public bool isFull2 () {
            return this.stack1Count + this.stack2Count == this.array.Length;
        }
    }
    public class MoshImplementation {
        private int top1;
        private int top2;
        private int[] items;

        public MoshImplementation (int Capacity) {
            if (Capacity <= 0) throw new ArgumentOutOfRangeException ();
            items = new int[Capacity];
            top1 = -1;
            top2 = Capacity;

        }

        public void Push1 (int item) {
            if (isFull1 ()) throw new Exception ("Stack 1 is full");

            items[++top1] = item;
        }

        public void Push2 (int item) {
            if (isFull2 ()) throw new Exception ("Stack 2 is full");
            items[--top2] = item;
        }

        public int Pop1 () {
            if (isEmpty1 ()) throw new Exception ("Stack 1 is empty");

            return items[top1--];
        }
        public int Pop2 () {
            if (isEmpty2 ()) throw new Exception ("Stack 2 is empty");
            return items[top2++];
        }

        public bool isFull1 () {
            return top1 + 1 == top2;
        }

        public bool isFull2 () {
            return top2 - 1 == top1;
        }
        public bool isEmpty1 () {
            return top1 == -1;
        }
        public bool isEmpty2 () {
            return top2 == items.Length;
        }
    }
}