using System;
using System.Collections.Generic;

namespace QueueDemo {
    public class QueueReverse {
        public static Queue<int> Reverse (Queue<int> queue) {
            Stack<int> stack = new Stack<int> ();

            while (queue.Count != 0) {
                stack.Push (queue.Dequeue ());
            }

            while (stack.Count != 0) {
                queue.Enqueue (stack.Pop ());
            }

            return queue;

        }
    }
}