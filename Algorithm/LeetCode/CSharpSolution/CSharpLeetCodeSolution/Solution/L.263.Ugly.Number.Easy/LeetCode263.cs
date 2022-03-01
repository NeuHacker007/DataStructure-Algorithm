/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 02-28-2022 20:43:05
 * LastEditTime: 02-28-2022 20:46:17
 * FilePath: \CSharpLeetCodeSolution\Solution\L.263.Ugly.Number.Easy\LeetCode263.cs
 * Description: 
 */

namespace MathSolution
{
    public class LeetCode263
    {
        public static bool IsUglyNumber(int n)
        {
            if (n < 1) return false;

            while (n > 1)
            {
                if (n % 2 == 0)
                {
                    n /= 2;
                }
                else if (n % 3 == 0)
                {
                    n /= 3;
                }
                else if (n % 5 == 0)
                {
                    n /= 5;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }

}