using System;
using System.Collections.Generic;

namespace QueueDemo {

    public class QueueWithTwoStacks {
        // used for enqueue operation
        private Stack<int> stack1 = new Stack<int> ();
        // used for dequeue operation
        private Stack<int> stack2 = new Stack<int> ();

        public void Enqueue (int item) {
            stack1.Push (item);
        }

        public int Dequeue () {
            if (IsStackEmpty ()) throw new Exception ("stack is empty");

            MoveItemsFromStack1ToStack2 ();

            return stack2.Pop ();
        }

        public int Peek () {
            if (IsStackEmpty ()) throw new Exception ("stack is empty");

            MoveItemsFromStack1ToStack2 ();

            return stack2.Peek ();
        }
        private void MoveItemsFromStack1ToStack2 () {
            if (IsStack2Empty ()) {

                while (!IsStack1Empty ()) {
                    stack2.Push (stack1.Pop ());
                }
            }
        }

        private bool IsStackEmpty () {
            return stack1.Count == 0 && stack2.Count == 0;
        }

        private bool IsStack1Empty () {
            return stack1.Count == 0;
        }

        private bool IsStack2Empty () {
            return stack2.Count == 0;
        }

    }
}