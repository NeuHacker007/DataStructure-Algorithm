using System;
using System.Collections.Generic;
namespace StackExcercise {
    public class MinValueStack {
        private int[] items;
        private int count;
        public MinValueStack (int capacity) {
            if (capacity <= 0) throw new ArgumentOutOfRangeException ("Invalid Capacity");

            items = new int[capacity];
            count = 0;
        }

        public void Push (int item) {
            if (isFull ()) throw new Exception ("Stack is full");

            items[count++] = item;
        }

        public int Pop () {
            if (isEmpty ()) throw new Exception ("Stack is empty");
            return items[count--];
        }

        public int Min () {
            int min = Int32.MaxValue;
            // O(n)
            for (int i = 0; i < count; i++) {
                if (items[i] < min) {
                    min = items[i];
                }
            }
            return min;
        }

        public bool isFull () {
            return count == items.Length;
        }

        public bool isEmpty () {
            return count == 0;
        }

    }
    public class MoshMinImplementation {
        private Stack<int> stack = new Stack<int> ();
        private Stack<int> minStack = new Stack<int> ();

        public void Push (int item) {
            stack.Push (item);

            if (minStack.Count == 0) {
                minStack.Push (item);
            } else if (item < minStack.Peek ()) {
                // current item should alwasy compare with the minStack top value. 
                // here it's easy to make mistake that take stack.peek() which is wrong
                minStack.Push (item);
            }
        }

        public int Pop () {
            if (stack.Count == 0) throw new Exception ("stack is empty");
            var top = stack.Pop ();

            if (minStack.Peek () == top) {
                minStack.Pop ();
            }
            return top;
        }

        public int Min () {
            return minStack.Peek ();
        }
    }
}