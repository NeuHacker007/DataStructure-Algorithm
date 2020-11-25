using System;
using System.Collections.Generic;
using System.Text;
namespace QueueExcercise {
    public class ReverseFirstKEleInQueue {
        public static string ReverseKEleInQueue (Queue<int> queue, int k) {
            Queue<int> result = new Queue<int> ();
            Stack<int> stack = new Stack<int> ();

            for (int i = 0; i < k; i++) {
                stack.Push (queue.Dequeue ());
            }
            while (stack.Count != 0) {
                result.Enqueue (stack.Pop ());
            }
            while (queue.Count != 0) {
                result.Enqueue (queue.Dequeue ());
            }

            var temp = result.ToArray ();
            StringBuilder sb = new StringBuilder ();
            sb.Append ("[");
            for (int i = 0; i < temp.Length; i++) {
                sb.Append ($"{temp[i] } ");
            }
            sb.Append ("]");

            return sb.ToString ();
        }
    }
}