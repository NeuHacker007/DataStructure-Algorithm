using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public class LeetCode227
    {
        //Implement a basic calculator to evaluate a simple expression string.

        //The expression string contains only non-negative integers, +, -, *, / operators and empty spaces.The integer division should truncate toward zero.

        //    Example 1:

        //Input: "3+2*2"
        //Output: 7

        //Example 2:

        //Input: " 3/2 "
        //Output: 1

        //Example 3:

        //Input: " 3+5 / 2 "
        //Output: 5

        //Note:

        //You may assume that the given expression is always valid.
        //    Do not use the eval built-in library function.


        public static int Calculate(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var op = '+';

            var value = 0;

            Stack<int> valStack = new Stack<int>();

            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];

                if (char.IsDigit(ch))
                {
                    value = value * 10 + (ch - '0');
                }

                if ((!char.IsDigit(ch) && ch != ' ') || i == s.Length - 1)
                {
                    switch (op)
                    {
                        case '+':
                            valStack.Push(value);
                            break;
                        case '-':
                            // here because we only have positive integers so that we can easily turn minus operation to be plus negative value;
                            valStack.Push(-value);
                            break;
                        case '*':
                            // if it is multiply, then multiply with the last element in the stack (recent pushed element)
                            valStack.Push(valStack.Pop() * value);
                            break;
                        case '/':
                            valStack.Push(valStack.Pop() / value);
                            break;

                    }
                    // update the operator to be latest operator
                    op = ch;
                    // re-start to calculate the digital value
                    value = 0;
                }
            }

            var answer = 0;
            while (valStack.Count != 0)
            {
                answer += valStack.Pop();
            }

            return answer;
        }


    }
}
