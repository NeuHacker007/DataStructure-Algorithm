using System.Collections;
using System.Text;
namespace StackDemo {
    public class StringReverse {
        public static string ReverseString (string originStr) {
            Stack stack = new Stack ();
            foreach (var item in originStr) {
                stack.Push (item);
            }

            string result = string.Empty;
            for (int i = 0; i < originStr.Length; i++) {
                result += stack.Pop ();
            }
            return result;
        }
        public static string ReverseString2 (string originStr) {
            Stack stack = new Stack ();
            foreach (var item in originStr) {
                stack.Push (item);
            }

            StringBuilder sb  = new StringBuilder();
            while(stack.Count != 0) {
                sb.Append(stack.Pop());
            }
            return sb.ToString();
        }

    }
}