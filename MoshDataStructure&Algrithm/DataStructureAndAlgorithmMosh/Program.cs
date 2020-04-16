using System;
using StackDemo;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            // System.Console.WriteLine (StringReverse.ReverseString ("abcd hello world !"));
            // System.Console.WriteLine (StringReverse.ReverseString2 ("abcd hello world !"));
            //System.Console.WriteLine (StringReverse.ReverseString2 (null));
            System.Console.WriteLine (ValidateParenthis.isValid2 ("((1+2"));
            System.Console.WriteLine (ValidateParenthis.isValid2 ("((1+2)"));
            System.Console.WriteLine (ValidateParenthis.isValid2 ("((1+2))"));
            System.Console.WriteLine (ValidateParenthis.isValid2 ("((1+2))}"));
            System.Console.WriteLine (ValidateParenthis.isValid2 ("((1+2)){}"));
            System.Console.WriteLine (ValidateParenthis.isValid2 ("((1+2))<>"));
            System.Console.WriteLine (ValidateParenthis.isValid2 (")("));

        }
    }
}