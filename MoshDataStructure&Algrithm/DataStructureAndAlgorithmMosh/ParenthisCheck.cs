using System;
using System.Collections.Generic;
namespace StackDemo {
    public class ValidateParenthis {
        private static readonly List<char> leftBrakets = new List<char> () { '(', '<', '[', '{' };
        private static readonly List<char> rightBrakets = new List<char> () { ')', '>', ']', '}' };
        public static bool isValid (string input) {
            if (string.IsNullOrWhiteSpace (input)) throw new ArgumentException ("input string is null or empty");
            Stack<char> stack = new Stack<char> ();

            foreach (var ch in input) {
                if (ch == '(' || ch == '<' || ch == '[' || ch == '{') {
                    stack.Push (ch);
                }
                if (ch == ')' || ch == '>' || ch == ']' || ch == '}') {
                    if (stack.Count == 0) return false;
                    char temp = stack.Pop ();
                    if (
                        ch == ')' && temp != '(' ||
                        ch == ']' && temp != '[' ||
                        ch == '>' && temp != '<' ||
                        ch == '}' && temp != '{'

                    ) {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
        public static bool isValid2 (string input) {
            if (string.IsNullOrWhiteSpace (input)) throw new ArgumentException ("input string is null or empty");

            Stack<char> stack = new Stack<char> ();

            foreach (var ch in input) {
                if (isLeftBracket (ch)) {
                    stack.Push (ch);
                }
                if (isRightBracket (ch)) {
                    if (stack.Count == 0) return false;

                    char temp = stack.Pop ();
                    if (isMatchBracket (ch, temp)) {
                        return true;
                    }
                }
            }

            return stack.Count == 0;
        }

        private static bool isLeftBracket (char ch) {
            return leftBrakets.Contains (ch);
        }
        private static bool isRightBracket (char ch) {
            return rightBrakets.Contains (ch);
        }
        private static bool isMatchBracket (char left, char right) {
            // this optimization has a hide requirement that the same element in both left brackets
            // and right brackets list has the same index. If one of them are not ordered properly, 
            // this logic will fail.
            // return leftBrakets.IndexOf (left) == rightBrakets.IndexOf (right);
            return left == '(' && right == ')' ||
                left == '[' && right == ']' ||
                left == '<' && right == '>' ||
                left == '{' && right == '}';

        }
    }
}