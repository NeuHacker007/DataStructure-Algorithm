/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 02-15-2022 12:57:42
 * LastEditTime: 02-15-2022 14:05:08
 * FilePath: \CSharpLeetCodeSolution\Solution\L.232.Implement.Queue.Using.Stacks.Easy\LeetCode232.cs
 * Description: 
 */
using System.Collections.Generic;
namespace QueueStackSolution
{
    public interface IQueue
    {
        void Push(int x);
        int Pop();
        int Peek();
        bool Empty();
    }
    public class LeetCode232 : IQueue
    {
        private Stack<int> s1 = new Stack<int>();
        private Stack<int> s2 = new Stack<int>();

        int front;
        public bool Empty()
        {
            return s1.Count == 0 && s2.Count == 0;
        }

        public int Peek()
        {
            if (s2.Count != 0)
            {
                return s2.Peek();
            }

            return front;
        }

        public int Pop()
        {
            if (s2.Count == 0)
            {
                if (s1.Count != 0)
                {
                    s2.Push(s1.Pop());
                }
            }
            return s2.Pop();
        }

        public void Push(int x)
        {
            if (s1.Count == 0)
            {
                front = x;
            }

            s1.Push(x);

        }
    }
}