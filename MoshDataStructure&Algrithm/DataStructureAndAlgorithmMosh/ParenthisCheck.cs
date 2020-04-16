using System;
using System.Collections.Generic;
namespace StackDemo {
    public class ValidateParenthis {
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
                        ch == '(' && temp != ')' ||
                        ch == '[' && temp != ']' ||
                        ch == '<' && temp != '>' ||
                        ch == '{' && temp != '}'

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
            return ch == '(' || ch == '<' || ch == '[' || ch == '{';
        }
        private static bool isRightBracket (char ch) {
            return ch == ')' || ch == '>' || ch == ']' || ch == '}';
        }
        private static bool isMatchBracket (char left, char right) {
            return left == '(' && right == ')' || left == '[' && right == ']' || left == '<' && right == '>' || left == '{' && right == '}';
        }
    }
}