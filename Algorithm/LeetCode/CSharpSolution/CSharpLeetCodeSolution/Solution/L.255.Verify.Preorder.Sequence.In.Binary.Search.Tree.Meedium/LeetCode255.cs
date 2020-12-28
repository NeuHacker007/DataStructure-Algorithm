/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-28-2020 17:38:13
 * LastEditTime: 12-28-2020 17:43:05
 * FilePath: \CSharpLeetCodeSolution\Solution\L.255.Verify.Preorder.Sequence.In.Binary.Search.Tree.Meedium\LeetCode255.cs
 * Description: 
 */

using System.Collections.Generic;

namespace Solution
{
    public class LeetCode255
    {
        public static bool VerifyPreorder(int[] preorder)
        {
            var low = int.MinValue;

            var stack = new Stack<int>();

            foreach (var item in preorder)
            {
                if (item < low) return false;
                while (stack.Count != 0 && item > stack.Peek())
                {
                    low = stack.Pop();
                }
                stack.Push(item);
            }

            return true;
        }
    }

}