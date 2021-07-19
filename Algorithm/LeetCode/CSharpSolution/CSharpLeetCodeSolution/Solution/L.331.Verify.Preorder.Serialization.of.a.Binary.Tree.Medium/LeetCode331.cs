/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 07-19-2021 15:59:40
 * LastEditTime: 07-19-2021 16:03:51
 * FilePath: \CSharpLeetCodeSolution\Solution\L.331.Verify.Preorder.Serialization.of.a.Binary.Tree.Medium\LeetCode331.cs
 * Description: 
 */

namespace LcTreeSolution
{
    public class LeetCode331
    {
        public static bool IsValidSerialization(string Preorder)
        {
            int slots = 1;

            var values = Preorder.Split(',');

            foreach (var value in values)
            {
                --slots;
                if (slots < 0) return false;

                if (!value.Equals("#"))
                {
                    slots += 2;
                }
            }

            return slots == 0;
        }
    }

}