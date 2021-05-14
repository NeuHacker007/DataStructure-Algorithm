/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 05-14-2021 14:42:52
 * LastEditTime: 05-14-2021 14:50:28
 * FilePath: \CSharpLeetCodeSolution\Solution\L.66.Plus.One.Easy\LeetCode66.cs
 * Description: 
 */


namespace LcArraySolution
{
    public class LeetCode66
    {
        public static int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] == 9)
                {
                    digits[i] = 0;
                }
                else
                {
                    digits[i]++;
                    return digits;
                }
            }

            var res = new int[digits.Length + 1];
            res[0] = 1;

            return res;
        }
    }

}