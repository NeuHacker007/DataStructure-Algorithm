using System;
using System.Collections.Generic;
using System.Text;

namespace Solution {
    public class LeetCode142Node {
        public int val;
        public LeetCode142Node next;
        public LeetCode142Node (int x) {
            val = x;
            next = null;
        }
    }
    public class LeetCode142 {

        public static LeetCode142Node DetectCircleByTwoPointer (LeetCode142Node head) {
            if (head?.next == null) return null;

            var slow = head;
            var fast = head;

            while (fast?.next != null) {
                fast = fast.next.next;
                slow = slow.next;

                if (fast == slow) {
                    slow = head;

                    while (slow != fast) {
                        slow = slow.next;
                        fast = fast.next;
                    }

                    return slow;
                }
            }

            return null;
        }

        public static LeetCode142Node DetectCircleHashMap (LeetCode142Node head) {

            var hashMap = new HashSet<LeetCode142Node> ();

            while (head != null) {
                if (!hashMap.Contains (head)) {
                    hashMap.Add (head);
                    head = head.next;
                } else {
                    return head;
                }

            }

            return null;
        }
    }
}