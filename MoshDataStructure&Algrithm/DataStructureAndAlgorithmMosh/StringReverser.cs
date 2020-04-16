using System.Collections;
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
    }
}