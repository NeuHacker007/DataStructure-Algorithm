/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-16-2022 20:53:38
 * LastEditTime: 10-16-2022 21:10:09
 * FilePath: \CSharpLeetCodeSolution\Solution\L.9.Palindrome.Number.Easy\LeetCode9.cs
 * Description: 
 */
namespace Solution
{
    public class LeetCode9
    {
        public static bool Solution1(int x)
        {
            string s = x.ToString();
            int begin = 0;
            int end = s.Length - 1;

            while (begin != end && begin < s.Length - 1 && end > 0)
            {
                if (s[begin] != s[end])
                {
                    return false;
                }
                else
                {
                    begin++;
                    end--;
                }
            }
            return true;
        }

        public static bool Solution2(int x)
        {
            if (x < 0) return false;
            if (x < 10) return true;
            string s = x.ToString();
            int begin = 0;
            int end = s.Length - 1;

            while (begin != end && begin < s.Length - 1 && end > 0)
            {
                if (s[begin] != s[end])
                {
                    return false;
                }
                else
                {
                    begin++;
                    end--;
                }
            }
            return true;
        }

        public static bool Solution3(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }
            if (x < 10) return true;

            int revtNumber = 0;

            while (x > revtNumber)
            {
                revtNumber = revtNumber * 10 + x % 10;
                x /= 10;
            }

            return x == revtNumber || x == revtNumber / 10;
        }
    }
}