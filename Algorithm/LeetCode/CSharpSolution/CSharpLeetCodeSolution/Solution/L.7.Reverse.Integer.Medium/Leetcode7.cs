/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 09-10-2022 09:21:54
 * LastEditTime: 09-10-2022 09:27:42
 * FilePath: \CSharpLeetCodeSolution\Solution\L.7.Reverse.Integer.Medium\Leetcode7.cs
 * Description: 
 */
namespace GenericSolution
{
    public class LeetCode7
    {
        public static int ReverseInt(int x)
        {
            int result = 0;

            while (x != 0)
            {
                int pop = x % 10;
                x /= 10;

                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && pop > 7))
                    return 0;
                if (result < int.MinValue / 10 || (result == int.MinValue / 10 && pop < -8))
                    return 0;
                result = result * 10 + pop;
            }

            return result;
        }
    }
}